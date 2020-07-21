using EPAMInterview.Configuration;
using EPAMInterview.Pages.LandingPage;
using TechTalk.SpecFlow;

namespace EPAMInterview.Steps
{
    [Binding]
    public class LandingPageSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private readonly LandingBasePage page;

        public LandingPageSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;

            if (this.page == null)
            {
                this.page = new LandingBasePage(this.driverContext);
            }
        }

        [When(@"User Navigates to UBS page")]
        public void GoToLandingPage()
        {
            this.page.NavigateToLandingPage();
        }

        [When(@"User clicks Set Preferences on Privacy Settings popup")]
        public void UserClicksSetPreferences()
        {
            this.page.ClickSetPreferences();
        }

        [When(@"User searches (.*) using search icon on landing page")]
        public void ClickSearchIcon(string searchSentence)
        {
            this.page.ClickSearchAndTypeSearchSeantence(searchSentence);
        }

        [When(@"Cookie is added to hide popup and page is refreshed")]
        public void AddCookieToHidePopup()
        {
            this.page.AddCookieToHidePopup().RefreshPage();

        }
    }
}
