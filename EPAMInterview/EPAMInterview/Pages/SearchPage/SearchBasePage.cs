using EPAMInterview.Configuration;
using EPAMInterview.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using EPAMInterview.Extensions;

namespace EPAMInterview.Pages.SearchPage
{
    public class SearchBasePage : PageConfiguration
    {
        private readonly By recommendedSearchResultTitle = By.XPath("//p[@class='recommended-label']/following-sibling::h2[@class='title']");
        private readonly By recommendedSearchResultUrl = By.XPath("//p[@class='recommended-label']/parent::div[@class='title-and-summary']/following-sibling::a[@class='more-link']");

        public SearchBasePage(DriverContext driverContext) : base(driverContext)
        {
        }

        public SearchBasePage AssertRecommendedSearchResult(SearchResultItem searchResult)
        {
            Driver.WaitForElementToBeVisible(recommendedSearchResultUrl, BaseConfiguration.MediumTimeout);

            var actualRecommendedSearchResultTitle = Driver.FindElement(recommendedSearchResultTitle).Text;
            var actualRecommendedSearchResultUrl = Driver.FindElement(recommendedSearchResultUrl).GetAttribute("href");

            var expectedRecommendedSearchResultTitle = searchResult.ResultTitle;
            var expectedRecommendedSearchResultUrl = searchResult.ResultUrl;

            Assert.AreEqual(expectedRecommendedSearchResultTitle, actualRecommendedSearchResultTitle);
            Assert.AreEqual(expectedRecommendedSearchResultUrl, actualRecommendedSearchResultUrl);

            return this;
        }

    }
}
