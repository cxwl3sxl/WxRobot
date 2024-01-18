using System;
using System.Net;
using System.Threading;

namespace MessageSendTest
{
    internal class Program
    {
        static void Main()
        {
            new Thread(SendWorker)
            {
                IsBackground = true
            }.Start();
            Console.WriteLine("Send work is started... press any key to exit");
            Console.ReadLine();
        }

        static void SendWorker()
        {
            if (Environment.GetCommandLineArgs().Length != 3)
            {
                PrintUsage();
                return;
            }

            var server = Environment.GetCommandLineArgs()[1];
            var to = Environment.GetCommandLineArgs()[2];

            if (string.IsNullOrWhiteSpace(server) || string.IsNullOrWhiteSpace(to))
            {
                PrintUsage();
                return;
            }

            while (true)
            {
                var pre = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0,
                    0);
                var sleep = 60 * 60 * 1000 - (int)(DateTime.Now - pre).TotalMilliseconds;
                Thread.Sleep(sleep);
                Send(server, to);
            }
        }

        static void PrintUsage()
        {
            Console.WriteLine("Usage: ");
            Console.WriteLine("MessageSendTest.exe [server address without api e.g http://a.com] [friend name]");
            Environment.Exit(0);
        }

        static void Send(string server, string to)
        {
            var top = Console.CursorTop;
            Console.CursorLeft = 0;
            try
            {
                var client = new WebClient();
                var data = client.UploadString($"{server}{(server.EndsWith("/") ? "" : "/")}api/wx/SendMessage",
                    $"{{\"to\": \"{to}\",\"message\": \"现在是：{DateTime.Now:yyyy-MM-dd HH:mm:ss}\"}}");
                Console.WriteLine(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.CursorTop = top;
            }
        }
    }
}
