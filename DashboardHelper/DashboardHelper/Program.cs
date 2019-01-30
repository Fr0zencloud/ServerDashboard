using System;
using System.Net;

namespace DashboardHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServer ws = new WebServer(SendResponse, "http://localhost:8080/system/infos/");
            ws.Run();
            Console.WriteLine("A simple webserver. Press a key to quit.");
            Console.ReadKey();
            ws.Stop();
        }

        public static string SendResponse(HttpListenerRequest request)
        {
            string OSinfo = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            string response = "{" + OSinfo + "}";
            return response;
        }
    }
}
