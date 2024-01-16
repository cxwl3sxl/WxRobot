using System.Collections.Concurrent;
using log4net;
using PinFun.Core.Api;
using PinFun.Core.DataBase;
using PinFun.Core.ServiceHost.WebHost;
using PinFun.Core.Utils;
using Exception = System.Exception;

// ReSharper disable All

namespace WxRobot
{
    public partial class MainWin : Form
    {
        public static MainWin Instance { get; private set; }

        private WxWindow _wxWindow;
        private WebHost _webHost;

        private readonly string _wxProcessName;
        private readonly string _wxWinClassName;
        private readonly string _wxWinName;
        private readonly int _port;
        private readonly string _dbFile;
        private readonly ConcurrentQueue<MessageInfo> _pendingQueue = new ConcurrentQueue<MessageInfo>();
        private readonly ILog _log = LogManager.GetLogger(typeof(MainWin));

        public MainWin()
        {
            InitializeComponent();
            Instance = this;
            btnStop.Enabled = false;
            _dbFile = Path.Combine(Util.GetApplicationDir(), "msg.db");
            if (!File.Exists(_dbFile))
            {
                File.WriteAllBytes(_dbFile, Properties.Resources.msg);
            }

            _wxProcessName = TryGetConfig("WxProcessName", "WeChat");
            _wxWinClassName = TryGetConfig("WxWinClassName", "WeChatMainWndForPC");
            _wxWinName = TryGetConfig("WxWinName", "微信");

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
                if (_wxWindow != null)
                {
                    _wxWindow.WxProcessChanged -= _wxWindow_WxProcessChanged;
                    _wxWindow.Dispose();
                }

                _wxWindow = new WxWindow(_wxProcessName, _wxWinClassName, _wxWinName);
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
                btnStop.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"启动失败：{ex.Message}");
                btnStart.Enabled = true;
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
                timer1.Stop();
                await Shutdown();
                tslPort.Text = "";
                tslWxPid.Text = "";
                tslRunningStatus.Text = "已停止";
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"停止失败:{ex.Message}");
                btnStop.Enabled = true;
            }
        }

        async Task Shutdown()
        {
            _wxWindow?.Dispose();
            _wxWindow = null;
            await Task.Run(() => { _webHost?.Stop(); });
            _webHost = null;
        }

        Db CreateDb()
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
            if (!_pendingQueue.TryDequeue(out var msg)) return;

            try
            {
                var r = await _wxWindow.SendMessage(msg.To, msg.Msg);

                msg.IsSend = r == null;
                msg.Result = r ?? "";
                msg.LastUpdateAt = DateTime.Now;
                msg.LastUpdateByName = "System";
                msg.LastUpdateId = Guid.Empty;
                using var db = CreateDb();
                db.Update(msg);
            }
            catch (Exception ex)
            {
                _log.Warn($"发送消息{msg.IdMsg}出错", ex);
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
    }
}
