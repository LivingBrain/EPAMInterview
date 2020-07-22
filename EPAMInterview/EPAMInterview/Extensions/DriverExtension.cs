using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace EPAMInterview.Extensions
{
    public static class DriverExtension
    {
        public static void JavaScriptClick(this IWebDriver webDriver, string jsCode)
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

        public static void WaitForElementToBeClickable(this IWebDriver driver, IWebElement webElement, double timeOutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds))
            {
                Message = "Web element not clickable."
            };
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
        }

        public static void WaitForElementToBeVisible(this IWebDriver driver, By webElement, double timeOutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds))
            {
                Message = "Web element not displayed."
            };
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(webElement));
        }
    }
}
