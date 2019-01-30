using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace DashboardHelper
{
    class Task
    {
        private string task;
        private bool isRunning = false;
        private bool isStarting = false;
        Process process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = @"C:\Users\niki\Documents\GitHub\AeroBot\DiscordAeroBot\bin\Debug\netcoreapp2.1\DiscordAeroBot.dll",
                WorkingDirectory = @"C:\Users\niki\Documents\GitHub\AeroBot\DiscordAeroBot\bin\Debug\netcoreapp2.1\",
                UseShellExecute = true,
                RedirectStandardOutput = false,
                RedirectStandardError = false,
                CreateNoWindow = true
            }

        };

        public Task(string _task) {
            this.task = _task;
        }

        public void Start() {
            this.isStarting = true;
            try
            {
                process.Start();
                checkStatus();
            }
            catch(Exception e) {
                Console.WriteLine(e);
            }
        }

        private void checkStatus() {
            if (!process.HasExited)
            {
                this.isStarting = false;
                this.isRunning = true;
            }
            else if (process.HasExited)
            {
                this.isRunning = false;
                this.isStarting = false;
            }
        }

        public string status() {
            checkStatus();
            if (!isRunning && !isStarting)
            {
                return "stopped";
            }
            else if (isRunning)
            {
                return "running";
            }
            else if (isStarting) {
                return "starting";
            }
            return "unkown";
        }

        public void Stop() {
            process.Close();
        }
    }
}
