using EPAMInterview.Configuration;
using OpenQA.Selenium;
using EPAMInterview.Extensions;

namespace EPAMInterview.Pages.LandingPage
{
    public class LandingBasePage : PageConfiguration
    {

        public LandingBasePage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void NavigateToLandingPage()
        {
            this.Driver.Navigate().GoToUrl(BaseConfiguration.GetUrlValue);
        }

        public LandingBasePage ClickSearchAndTypeSearchSeantence(string searchSentence)
        {
            this.Driver.FindElement(By.CssSelector(".headerSearch__toggle")).Click();
            return this;
        }

        public LandingBasePage ClickSetPreferences()
        {
            this.Driver.FindElements(By.CssSelector(".privacysettings__allowAllCookies")).Click();
                
            this.Driver.JSClick("document.getElementsByClassName('privacysettings__saveUserPreferences')[0].click();");

            return this;
        }
    }
}
