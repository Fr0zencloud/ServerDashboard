using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using DashboardHelper;

namespace DashboardHelper
{
    class Task
    {
        private string task;
        private string start;
        private string stop;
        private string isActive;

        public Task(string _task) {
            this.task = _task;
            this.start = "systemctl start " + _task;
            this.stop = "systemctl stop " + _task;
            this.isActive = "systemctl is-active " + _task;
        }

        public string getName() {
            return this.task;
        }

        public string Start() {
            return start.Bash();
        }

        public string status() {
            string output = isActive.Bash().Replace("\n", "");
            Console.WriteLine("[" + DateTime.Now + "] " + this.task + ": [" + output + "]");
            if (output.Equals("active"))
            {
                return "running";
            }
            else if (output.Equals("inactive")) {
                return "stopped";
            }
            return "unkown";
        }

        public string Stop() {
           return stop.Bash();
        }
    }
}
