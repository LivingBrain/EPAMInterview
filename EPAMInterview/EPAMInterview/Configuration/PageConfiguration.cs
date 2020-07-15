using OpenQA.Selenium;

namespace EPAMInterview.Configuration
{
    public abstract class PageConfiguration
    {
        public PageConfiguration(DriverContext driverContext)
        {
            this.DriverContext = driverContext;
            this.Driver = driverContext.Driver;
        }

        protected IWebDriver Driver { get; set; }

        protected DriverContext DriverContext { get; set; }
    }
}
