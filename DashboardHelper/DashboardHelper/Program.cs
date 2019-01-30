using System;
using System.Net;

namespace DashboardHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServer ws = new WebServer(SendResponse, "http://31.172.80.113:8010/system/infos/");
            ws.Run();
            Console.WriteLine("A simple webserver. Press a key to quit.");
            Console.ReadKey();
            ws.Stop();
        }

        public static string SendResponse(HttpListenerRequest request)
        {
            JSON json = new JSON();
            SystemInfo sysinfo = new SystemInfo();
            json.addArgument("SystemOS", sysinfo.OS);
            return json.build();
        }
    }
}
