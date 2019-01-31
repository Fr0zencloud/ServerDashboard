using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Diagnostics;

namespace DashboardHelper
{
    class SystemInfo
    {
        public string OS
        {
            get
            {
                if (this.os.Contains("Linux") && this.os != null)
                {
                    return this.os.Split(" #")[0];
                }
                else if (this.os.Contains("Windows")) {
                    return this.os.Split("Microsoft ")[1];
                }
                else
                {
                    return "unknown";
                }
            }
            set
            {
                this.os = value;
            }
        }

        string os = System.Runtime.InteropServices.RuntimeInformation.OSDescription;

        public void startProgram() {

        }
    }
}
