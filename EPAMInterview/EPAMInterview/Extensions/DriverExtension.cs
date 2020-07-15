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
    }
}
