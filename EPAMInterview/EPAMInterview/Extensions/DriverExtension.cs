using OpenQA.Selenium;

namespace EPAMInterview.Extensions
{
    public static class DriverExtension
    {
        public static void JSClick(this IWebDriver webDriver, string jsCode)
        {
            var jsExecutor = webDriver as IJavaScriptExecutor;
            jsExecutor?.ExecuteScript(jsCode);
        }

        public static void RefreshPage(this IWebDriver webDriver)
        {
            webDriver.Navigate().Refresh();
        }

        public static void AddNewCookie(this IWebDriver webDriver, Cookie cookie)
        {
            webDriver.Manage().Cookies.AddCookie(cookie);
        }
    }
}
