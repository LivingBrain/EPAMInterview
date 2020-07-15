using System;
using System.Configuration;
using System.Globalization;

namespace EPAMInterview.Configuration
{
    public static class BaseConfiguration
    {
        public static BrowserType TestBrowser
        {
            get
            {
                BrowserType result;
                return Enum.TryParse(ConfigurationManager.AppSettings["browser"], out result) ? result : BrowserType.None;
            }
        }

        public static BrowserType TestBrowserCapabilities
        {
            get
            {
                BrowserType result;
                return Enum.TryParse(ConfigurationManager.AppSettings["DriverCapabilities"], out result) ? result : BrowserType.None;
            }
        }

        public static string Protocol
        {
            get
            {
                return ConfigurationManager.AppSettings["protocol"];
            }
        }

        public static string Host
        {
            get
            {
                return ConfigurationManager.AppSettings["host"];
            }
        }

        public static string Url
        {
            get
            {
                return ConfigurationManager.AppSettings["url"];
            }
        }

        public static int LongTimeout
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["longTimeout"]);
            }
        }

        public static int MediumTimeout
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["mediumTimeout"]);
            }
        }

        public static int ShortTimeout
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["shortTimeout"]);
            }
        }

        public static string GetUrlValue
        {
            get
            {
                return string.Format(CultureInfo.CurrentCulture, "{0}://{1}{2}", Protocol, Host, Url);
            }
        }
    }
}
