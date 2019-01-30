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
                if(this.os != null)
                    return this.os;
                else
                    return "unknown";
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
