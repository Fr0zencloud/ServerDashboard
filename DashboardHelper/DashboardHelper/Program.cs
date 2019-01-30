using System;
using System.Net;
using System.Diagnostics;

namespace DashboardHelper
{
    class Program
    {
        private static Task task = new Task("test");

        static void Main(string[] args)
        {
#if DEBUG
            WebServer ws = new WebServer(SendResponse, "http://localhost:8080/system/infos/");
#else
    WebServer ws = new WebServer(SendResponse, "http://31.172.80.113:8010/system/infos/");      
#endif

            ws.Run();
            Console.WriteLine("A simple webserver. Press a key to quit.");
            task.Start();
            Console.ReadLine();
        }

        public static string SendResponse(HttpListenerRequest request)
        {
            JSON json = new JSON();
            SystemInfo sysinfo = new SystemInfo();
            json.addArgument("SystemOS", sysinfo.OS);
            json.addArgument("DiscordBot", task.status());
            return json.build();
        }
    }
}
