using EPAMInterview.Configuration;
using EPAMInterview.Pages.LandingPage;
using System.Collections.Generic;
using System.Linq;
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
        }

        [When(@"User searches (.*) using search icon on landing page")]
        public void ClickSearchIcon(string searchSentence)
        {
            page.ClickSearchAndTypeSearchSeantence(searchSentence);
        }

        [When(@"Cookie is added to hide popup and page is refreshed")]
        public void AddCookieToHidePopup()
        {
            this.page.AddCookieToHidePopup().RefreshPage();
        }

        [When(@"User clicks Select domicile button in header and selects (.*) as region and (.*) as country")]
        public void SelectDomicile(string regionName, string countryName)
        {
            this.page
                .ClickSelectDomicileButton()
                .ClickDomicileRegion(regionName)
                .ClickDomicileCountry(countryName);
        }

        [When(@"User clicks language code in header to change to (DE|EN) language")]
        public void ChangePageLanguage(string languageCode)
        {
            this.page.ClickLanguageCodeToChangePageLanguage(languageCode);
        }

        [Then(@"User should be on (.*) page with (.*) language")]
        public void CheckPageUrl(string countryCode, string languageCode)
        {
            this.page
                .AssertPageCountry(countryCode)
                .AssertPageLanguage(languageCode);
        }

        [Then(@"Main section headers should be")]
        public void CheckSectionHeaders(Table table)
        {
            List<string> sectionHeadersList = table.Header.Contains("SectionTitle") ? table.Rows.Select(r => r["SectionTitle"]).ToList() : null;

            this.page.CheckMainSectionsHeaders(sectionHeadersList);
        }
    }
}
