using System;
using System.Net;
using System.Diagnostics;

namespace DashboardHelper
{
    class Program
    {
        private static Task minecraft = new Task("minecraft@vanilla");
        private static Task jira = new Task("jira");

        static void Main(string[] args)
        {
            WebServer ws = new WebServer(SendResponse, "http://31.172.80.113:8010/system/infos/");  
            WebServer startTaskWebServer = new WebServer(StartTask, "http://31.172.80.113:8010/system/start/");

            ws.Run();
            startTaskWebServer.Run();
            Console.ReadLine();
        }

        public static string SendResponse(HttpListenerRequest request)
        {
            JSON json = new JSON();
            SystemInfo sysinfo = new SystemInfo();
            json.addArgument("SystemOS", sysinfo.OS);
            json.addArgument("Minecraft", minecraft.status());
            json.addArgument("Jira", jira.status());
            return json.build();
        }

        public static string StartTask(HttpListenerRequest request) {
            Task[] tasks = new Task[] { jira, minecraft };
            JSON json = new JSON();
            foreach (Task task in tasks)
            {
                if (task.getName().Equals(request.QueryString["task"])) {
                    task.Start();
                    json.addArgument("started", task.getName());
                }
            }
           
            return json.build();
        }
    }
}
