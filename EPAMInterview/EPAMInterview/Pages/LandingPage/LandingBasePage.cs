using EPAMInterview.Configuration;
using OpenQA.Selenium;
using EPAMInterview.Extensions;
using EPAMInterview.Pages.SearchPage;

namespace EPAMInterview.Pages.LandingPage
{
    public class LandingBasePage : PageConfiguration
    {
        public readonly By searchIcon = By.CssSelector(".headerSearch__toggle");
        public readonly By searchInput = By.Id("searchbox");
        public readonly By searchInputButton = By.CssSelector(".autocomplete-search-box-form .search-button");

        public LandingBasePage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void NavigateToLandingPage()
        {
            Driver.Navigate().GoToUrl(BaseConfiguration.GetUrlValue);
        }

        public SearchBasePage ClickSearchAndTypeSearchSeantence(string searchSentence)
        {
            Driver.FindElement(searchIcon).Click();
            Driver.WaitForElementToBeVisible(searchInput, BaseConfiguration.ShortTimeout);
            Driver.FindElement(searchInput).SendKeys(searchSentence);
            Driver.FindElement(searchInputButton).Click();
            return new SearchBasePage(DriverContext);
        }

        public LandingBasePage AddCookieToHidePopup()
        {
            Driver.AddNewCookie(new Cookie("ubs_cookie_settings_2.0.2", "0-1"));

            return this;
        }

        public LandingBasePage RefreshPage()
        {
            Driver.RefreshPage();

            return this;
        }        
    }
}
