using System.Diagnostics;
using log4net;
using Vanara.PInvoke;
// ReSharper disable All

namespace WxRobot
{
    internal class WxWindow : IDisposable
    {
        private readonly string _processName;
        private readonly string _wxWinClassName;
        private readonly string _wxWinName;
        private readonly ILog _log = LogManager.GetLogger(typeof(WxWindow));
        private Process _wxProcess;
        private bool _exit;

        public event Action WxProcessChanged;

        public WxWindow(string processName, string wxWinClassName = "WeChatMainWndForPC", string wxWinName = "微信")
        {
            _processName = processName;
            _wxWinClassName = wxWinClassName;
            _wxWinName = wxWinName;
            _log.Info($"微信窗口助手正在启动，进程名称：{processName} 窗口类型：{_wxWinClassName} 窗口名称：{_wxWinName}");
            new Thread(KeepWx)
            {
                IsBackground = true
            }.Start();
        }

        void Scan()
        {
            IsWxRunning = false;
            HasMulti = false;

            try
            {
                var processes = Process.GetProcessesByName(_processName);
                if (!processes.Any())
                {
                    IsWxRunning = false;
                    return;
                }

                if (processes.Length == 1)
                {
                    _wxProcess = processes[0];
                    IsWxRunning = true;
                    return;
                }

                HasMulti = true;

            }
            finally
            {
                WxProcessChanged?.Invoke();
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="friendName">好友名称或群名称</param>
        /// <param name="message">消息内容</param>
        /// <returns></returns>
        public async Task<string> SendMessage(string friendName, string message)
        {
            if (_wxProcess == null) return "微信进程不存在";
            if (_wxProcess.HasExited) return "微信进程已退出";
            if (string.IsNullOrWhiteSpace(friendName)) return "好友名称不能为空";
            if (string.IsNullOrWhiteSpace(message)) return "消息内容不能为空";

            HWND mainWindowPtr = _wxProcess.MainWindowHandle;
            if (_wxProcess.MainWindowHandle == IntPtr.Zero)
            {
                Console.WriteLine("程序没有主窗口，尝试激活...");
                mainWindowPtr = User32.FindWindow(_wxWinClassName, _wxWinName);
                if (mainWindowPtr == IntPtr.Zero)
                {
                    return "无法找到微信主窗口";
                }

                if (!User32.SetForegroundWindow(mainWindowPtr))
                {
                    return "无法前置微信窗体";
                }

                User32.ShowWindow(mainWindowPtr, ShowWindowCommand.SW_SHOWDEFAULT);
            }
            else
            {
                Console.WriteLine("主窗口存在，前置...");
                User32.SetForegroundWindow(mainWindowPtr);
            }

            await Task.Delay(1000);
            Console.WriteLine("准备发送");
            User32.SetFocus(mainWindowPtr);

            await Task.Delay(100);
            SendKeys.SendWait("^f");
            await Task.Delay(100);
            SendKeys.SendWait("^a");
            await Task.Delay(100);
            SendKeys.SendWait("{DEL}");

            Clipboard.SetText(friendName);
            SendKeys.SendWait("^v");
            await Task.Delay(500);
            SendKeys.SendWait("{ENTER}");
            await Task.Delay(100);

            Clipboard.SetText(message);
            SendKeys.SendWait("^v");
            await Task.Delay(100);
            SendKeys.SendWait("{ENTER}");
            await Task.Delay(500);

            return null;
        }

        void KeepWx()
        {
            while (!_exit)
            {
                try
                {
                    if (_wxProcess == null)
                    {
                        Scan();
                    }
                    else if (_wxProcess.HasExited)
                    {
                        Scan();
                    }
                    else
                    {
                        _log.Debug($"当前使用的微信进程为：{_wxProcess.Id}");
                        _wxProcess.WaitForExit();
                        Scan();
                    }

                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    _log.Warn("扫描微信进程出错", ex);
                    Thread.Sleep(1000);
                }
            }
        }

        /// <summary>
        /// 微信是否在运行
        /// </summary>
        public bool IsWxRunning { get; private set; }

        public int Pid => _wxProcess?.Id ?? 0;

        /// <summary>
        /// 是否运行了多个实例
        /// </summary>
        public bool HasMulti { get; private set; }

        public void Dispose()
        {
            _exit = true;
        }
    }
}
