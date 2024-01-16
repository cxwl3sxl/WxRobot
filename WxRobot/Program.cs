namespace WxRobot
{
    internal class Program
    {

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            PinFun.Core.Startup.InitLog4Net();
            Application.Run(new MainWin());
        }
    }
}