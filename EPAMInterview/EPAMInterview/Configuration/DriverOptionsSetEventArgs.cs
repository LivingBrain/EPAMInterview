using OpenQA.Selenium;
using System;

namespace EPAMInterview.Configuration
{
    public class DriverOptionsSetEventArgs : EventArgs
    {
        public DriverOptionsSetEventArgs(DriverOptions options)
        {
            this.DriverOptions = options;
        }

        public DriverOptions DriverOptions { get; }
    }
}
