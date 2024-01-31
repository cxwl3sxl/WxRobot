using System.Collections.Concurrent;
using System.Diagnostics;
using log4net;
using Newtonsoft.Json;
using PinFun.Core.Api;
using PinFun.Core.DataBase;
using PinFun.Core.ServiceHost.WebHost;
using PinFun.Core.Utils;
using WxRobot.WebApi;

// ReSharper disable All

namespace WxRobot
{
    public partial class MainWin : Form
    {
        public static MainWin Instance { get; private set; }

        private WxWindow _wxWindow;
        private WebHost _webHost;
        private PushLog _pushLogWin;
        private DateTime _lastSendAt;
        private bool _isSending;

        private readonly string _wxProcessName;
        private readonly string _wxWinClassName;
        private readonly string _wxWinName;
        private readonly int _port;
        private readonly string _dbFile;
        private readonly ConcurrentQueue<MessageInfo> _pendingQueue = new ConcurrentQueue<MessageInfo>();
        private readonly ILog _log = LogManager.GetLogger(typeof(MainWin));
        private readonly DelayConfig _delayConfig;

        public MainWin()
        {
            InitializeComponent();
            _lastSendAt = DateTime.Now;
            _delayConfig = HostConfig.Instance.GetConfig<DelayConfig>("Delay") ?? new DelayConfig();
            Closing += MainWin_Closing;
            Closed += MainWin_Closed;
            Instance = this;
            btnStop.Enabled = false;
            _dbFile = Path.Combine(Util.GetApplicationDir(), "msg.db");
            if (!File.Exists(_dbFile))
            {
                File.WriteAllBytes(_dbFile, Properties.Resources.msg);
            }

            _log.Debug($"当前使用的数据库文件为：{_dbFile}");
            _wxProcessName = TryGetConfig("WxProcessName", "WeChat");
            _wxWinClassName = TryGetConfig("WxWinClassName", "WeChatMainWndForPC");
            _wxWinName = TryGetConfig("WxWinName", "微信");
            _log.Debug($"消息发送间隔:{timer1.Interval}ms");

            var portStr = TryGetConfig("WebPort", "8111");
            if (int.TryParse(portStr, out var p))
            {
                _port = p;
            }
            else
            {
                _port = 8111;
            }
        }

        private async void MainWin_Closed(object sender, EventArgs e)
        {
            await Shutdown();
        }

        private void MainWin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var r = MessageBox.Show(@"确定要退出程序么？
是: 退出程序
否: 不做任何处理
取消: 最小化到任务栏", "温馨提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if (r == DialogResult.Cancel)
            {
                e.Cancel = true;

                if (Visible)
                {
                    MiniToTaskBar();
                }
            }
        }

        void MiniToTaskBar()
        {
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            Visible = false;
        }

        string TryGetConfig(string name, string defaultVal)
        {
            var v = HostConfig.Instance.GetConfig<string>(name);
            return string.IsNullOrWhiteSpace(v) ? defaultVal : v;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                btnStart.Enabled = false;
                启动服务ToolStripMenuItem.Enabled = false;
                if (_wxWindow != null)
                {
                    _wxWindow.WxProcessChanged -= _wxWindow_WxProcessChanged;
                    _wxWindow.Dispose();
                }

                _wxWindow = new WxWindow(_wxProcessName, _delayConfig, _wxWinClassName, _wxWinName);
                _wxWindow.WxProcessChanged += _wxWindow_WxProcessChanged;

                _webHost?.Stop();
                _webHost?.Dispose();
                _webHost = new WebHost("wxMsgSvr", new WebHostConfig()
                {
                    Port = _port,
                    ApiConfig = new WebApiInfo()
                    {
                        ApiUrl = "/api"
                    }
                });

                await Task.Run(() => { _webHost.Start(); });

                timer1.Start();
                tslPort.Text = $"http://localhost:{_port}/api";
                tslRunningStatus.Text = "运行中";
                btnStart.Enabled = false;
                启动服务ToolStripMenuItem.Enabled = false;
                btnStop.Enabled = true;
                停止服务ToolStripMenuItem.Enabled = true;

                notifyIcon1.Text = "微信消息发送服务:已启动";

                notifyIcon1.ShowBalloonTip(5000, "启动成功", "服务启动成功，请关闭所有前置窗口，返回到桌面环境，避免进行其他操作。", ToolTipIcon.Info);

                if (Visible)
                {
                    MiniToTaskBar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"启动失败：{ex.Message}");
                btnStart.Enabled = true;
                启动服务ToolStripMenuItem.Enabled = true;
            }
        }

        void TryInvoke(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void _wxWindow_WxProcessChanged()
        {
            TryInvoke(() =>
            {
                if (_wxWindow == null)
                {
                    tslWxPid.Text = "微信状态未知";
                    return;
                }

                if (_wxWindow.IsWxRunning)
                {
                    tslWxPid.Text = $"微信进程号：{_wxWindow.Pid}";
                    return;
                }

                if (_wxWindow.HasMulti)
                {
                    tslWxPid.Text = "有多个微信";
                }
            });
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                btnStop.Enabled = false;
                停止服务ToolStripMenuItem.Enabled = false;
                timer1.Stop();
                await Shutdown();
                tslPort.Text = "";
                tslWxPid.Text = "";
                tslRunningStatus.Text = "已停止";
                btnStart.Enabled = true;
                启动服务ToolStripMenuItem.Enabled = true;
                btnStop.Enabled = false;
                停止服务ToolStripMenuItem.Enabled = false;

                notifyIcon1.Text = "微信消息发送服务:已停止";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"停止失败:{ex.Message}");
                btnStop.Enabled = true;
                停止服务ToolStripMenuItem.Enabled = true;
            }
        }

        async Task Shutdown()
        {
            _wxWindow?.Dispose();
            _wxWindow = null;
            await Task.Run(() => { _webHost?.Stop(); });
            _webHost = null;
        }

        public Db CreateDb()
        {
            return new Db(DbTypes.Sqlite, $"Data Source={_dbFile};Version=3;BinaryGUID=0", false);
        }

        public Guid SendMessage(string to, string message)
        {
            if (_wxWindow == null) throw new ApiExecuteException("服务尚未初始化");
            if (_wxWindow.HasMulti) throw new ApiExecuteException("启动了多个微信");
            if (!_wxWindow.IsWxRunning) throw new ApiExecuteException("微信尚未启动");
            var msg = new MessageInfo()
            {
                IdMsg = Guid.NewGuid(),
                To = to,
                Msg = message,
                CreateAt = DateTime.Now,
                CreateByName = "System",
                CreateId = Guid.Empty
            };

            using var db = CreateDb();
            db.Insert(msg);

            _pendingQueue.Enqueue(msg);

            return msg.IdMsg;
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (_wxWindow == null) return;
            if (!_wxWindow.IsWxRunning) return;
            if ((DateTime.Now - _lastSendAt).TotalMilliseconds <= _delayConfig.Message) return;
            if (_isSending) return;

            _isSending = true;
            if (!_pendingQueue.TryDequeue(out var msg))
            {
                _isSending = false;
                return;
            }

            tsslQueue.Text = $"发送队列:{_pendingQueue.Count}";

            try
            {
                _wxWindow.TraceMessage("正在推送消息...");
                var r = await _wxWindow.SendMessage(msg.To, msg.Msg);
                _wxWindow.TraceMessage($"推送结果:{r}");

                _log.Debug($"推送记录{msg.IdMsg} 推送结果：{r}");

                msg.IsSend = r == null;
                msg.Result = r ?? "";
            }
            catch (Exception ex)
            {
                msg.Result = $"错误:{ex.Message}";
                _log.Warn($"发送消息{msg.IdMsg}出错", ex);
            }
            finally
            {
                _isSending = false;
                msg.LastUpdateAt = _lastSendAt = DateTime.Now;
                msg.LastUpdateByName = "System";
                msg.LastUpdateId = Guid.Empty;
                UpdateMessageSendResult(msg);
            }
        }

        void UpdateMessageSendResult(MessageInfo msg)
        {
            try
            {
                using var db = CreateDb();
                db.Update(msg);
            }
            catch (Exception ex)
            {
                _log.Warn($"更新消息发送结果出错, 待更新数据详情为：{Environment.NewLine}{JsonConvert.SerializeObject(msg)}", ex);
            }
        }

        public MessageInfo CheckResult(Guid idMsg)
        {
            using var db = CreateDb();
            var msg = db.GetFirstOrDefault<MessageInfo>(new MessageInfo()
            {
                IdMsg = idMsg
            });
            return msg;
        }

        private void 启动服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStart_Click(null, e);
        }

        private void 停止服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStop_Click(null, e);
        }

        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            if (Environment.GetCommandLineArgs().Contains("start-service"))
            {
                btnStart_Click(null, null);
                MiniToTaskBar();
            }

            btnStart.Enabled = 启动服务ToolStripMenuItem.Enabled = true;
            btnStop.Enabled = 停止服务ToolStripMenuItem.Enabled = false;
        }

        private void 推送日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_pushLogWin != null)
            {
                _pushLogWin.BringToFront();
                return;
            }

            _pushLogWin = new PushLog();
            _pushLogWin.Closed += _pushLogWin_Closed;
            _pushLogWin.StartPosition = FormStartPosition.CenterScreen;
            _pushLogWin.Show();
        }

        private void _pushLogWin_Closed(object sender, EventArgs e)
        {
            _pushLogWin.Closed -= _pushLogWin_Closed;
            _pushLogWin = null;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(linkLabel1.Text);
            }
            catch
            {

            }
        }

        public async Task<WxStatus> Status()
        {
            if (_wxWindow == null) return null;

            var isLogin = await _wxWindow.CheckWxLogined();

            return new WxStatus
            {
                HasMulti = _wxWindow.HasMulti,
                IsLogin = isLogin,
                IsWxRunning = _wxWindow.IsWxRunning
            };
        }

        public int PendingQueue()
        {
            return _pendingQueue.Count;
        }

        public string Login()
        {
            return _wxWindow?.Login();
        }
    }
}
