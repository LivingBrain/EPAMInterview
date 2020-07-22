using EPAMInterview.Configuration;
using EPAMInterview.Models;
using EPAMInterview.Pages.SearchPage;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EPAMInterview.Steps.SearchPage
{
    [Binding]
    public class SearchPageSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private readonly SearchBasePage page;

        public SearchPageSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;

            if (this.page == null)
            {
                this.page = new SearchBasePage(this.driverContext);
            }
        }

        [Then(@"Recommended search result should be as follows")]
        public void AsserRecommendedSearchResult(Table table)
        {
            var recommendedSearchResultItem = table.CreateInstance<SearchResultItem>();
            page.AssertRecommendedSearchResult(recommendedSearchResultItem);
        }

    }
}
