using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace EPAMInterview.Extensions
{
    public static class DriverExtension
    {
        public static void JavaScriptExecutor(this IWebDriver webDriver, string jsCode)
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

        public static void WaitForElementToBeClickable(this IWebDriver webDriver, IWebElement webElement, double timeOutInSeconds)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeOutInSeconds))
            {
                Message = "Web element not clickable."
            };
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
        }

        public static void WaitForElementToBeVisible(this IWebDriver webDriver, By webElement, double timeOutInSeconds)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeOutInSeconds))
            {
                Message = "Web element not displayed."
            };
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(webElement));
        }

        public static void WaitForPageToLoad(this IWebDriver webDriver, double timeOutInSeconds)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
