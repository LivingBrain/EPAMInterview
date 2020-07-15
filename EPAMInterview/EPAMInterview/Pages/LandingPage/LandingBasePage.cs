using EPAMInterview.Configuration;
using OpenQA.Selenium;

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
    }
}
