using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Globalization;

namespace EPAMInterview.Configuration
{
    public class DriverContext
    {
        private IWebDriver driver;
        public event EventHandler<DriverOptionsSetEventArgs> DriverOptionSet;

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        private FirefoxOptions FirefoxOptions
        {
            get
            {
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                return firefoxOptions;
            }
        }

        private ChromeOptions ChromeOptions
        {
            get
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                return chromeOptions;
            }
        }

        private T SetDriverOptions<T>(T options) where T : DriverOptions
        {
            EventHandler<DriverOptionsSetEventArgs> driverOptionsSet = DriverOptionSet;
            if (driverOptionsSet != null)
            {
                driverOptionsSet(this, new DriverOptionsSetEventArgs(options));
            }
            return options;
        }

        public void Start()
        {
            switch (BaseConfiguration.TestBrowser)
            {
                case BrowserType.FireFox:
                    driver = new FirefoxDriver(SetDriverOptions(FirefoxOptions));
                    break;
                case BrowserType.Chrome:
                    driver = new ChromeDriver(SetDriverOptions(ChromeOptions));
                    break;
                default:
                    throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, "Driver {0} is not supported", BaseConfiguration.TestBrowser));
            }
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(BaseConfiguration.LongTimeout);
        }

        public void WindowMaximize()
        {
            driver.Manage().Window.Maximize();
        }

        public void Stop()
        {
            if (driver == null)
            {
                return;
            }
            driver.Quit();
        }
    }


}
