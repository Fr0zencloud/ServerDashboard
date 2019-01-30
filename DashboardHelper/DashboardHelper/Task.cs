using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace DashboardHelper
{
    class Task
    {
        private string task;
        Process process = new Process();

        public Task(string _task) {
            this.task = _task;
        }

        void Start() {
            process.StartInfo.FileName = task;
            process.Start();
        }

        void Stop() {
            process.Close();
        }
    }
}
