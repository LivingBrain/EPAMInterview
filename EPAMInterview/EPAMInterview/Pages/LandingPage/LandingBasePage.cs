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

        public LandingBasePage AddCookieToHidePopup()
        {
            this.Driver.AddNewCookie(new Cookie("ubs_cookie_settings_2.0.2", "0-1"));

            return this;
        }

        public LandingBasePage RefreshPage()
        {
            this.Driver.RefreshPage();

            return this;
        }

        public LandingBasePage ClickSetPreferences()
        {
            var test = this.Driver.FindElements(By.CssSelector(".actionbutton__button"));
                
            this.Driver.JSClick("document.getElementsByClassName('privacysettings__saveUserPreferences')[0].click();");

            return this;
        }
    }
}
