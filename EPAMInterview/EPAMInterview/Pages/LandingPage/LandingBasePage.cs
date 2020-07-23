using EPAMInterview.Configuration;
using OpenQA.Selenium;
using EPAMInterview.Extensions;
using EPAMInterview.Pages.SearchPage;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System;

namespace EPAMInterview.Pages.LandingPage
{
    public class LandingBasePage : PageConfiguration
    {
        private readonly By searchIcon = By.CssSelector(".headerSearch__toggle");
        private readonly By searchInput = By.Id("searchbox");
        private readonly By searchInputButton = By.CssSelector(".autocomplete-search-box-form .search-button");
        private readonly By selectDomicileButton = By.Id("domicileButton");
        private readonly By domicileRegionDropDownButton = By.XPath("//ul[@id='metanavigation-navContent0']//li[contains(@class,'domicileSelection__item--region')]");
        private readonly By domicileCountryDropDownButton = By.XPath("//ul[@id='metanavigation-navContent0']//li[contains(@class,'domicileSelection__item--country')]");
        private readonly By languageCodeButton = By.XPath("//a[contains(@class,'languageButton')]");

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
        
        public LandingBasePage ClickSelectDomicileButton()
        {
            Thread.Sleep(1000); //TODO issue with hiding domicile nav fixed by sleep. Need refactor. 
            //Driver.WaitForPageToLoad(BaseConfiguration.MediumTimeout); //document.readyState not fixing this issue
            Driver.FindElement(selectDomicileButton).Click();
            return this;
        }

        public LandingBasePage ClickDomicileRegion(string domicileRegionName)
        {
            Driver.WaitForElementToBeClickable(Driver.FindElement(domicileRegionDropDownButton), BaseConfiguration.ShortTimeout);
            Driver.FindElement(domicileRegionDropDownButton).Click();
            Driver.FindElement(By.XPath($"//ul[@id='metanavigation-navContent0']//button[contains(text(),'{domicileRegionName}')]")).Click();
            return this;
        }

        public LandingBasePage ClickDomicileCountry(string countryName)
        {
            Driver.WaitForElementToBeClickable(Driver.FindElement(domicileCountryDropDownButton), BaseConfiguration.ShortTimeout);
            Driver.FindElement(domicileCountryDropDownButton).Click();
            Driver.FindElement(By.XPath($"//ul[@id='metanavigation']//ul[contains(@class,'domicileSelection__list--country')]//a[contains(text(),'{countryName}')]")).Click();
            return this;
        }

        public LandingBasePage AssertPageCountry(string expectedPageCountryCode)
        {
            var pageUrl = Driver.Url;
            var actualPageCountryCode = pageUrl.Split('/')[3];

            Assert.AreEqual(expectedPageCountryCode, actualPageCountryCode);
            return this;
        }

        public LandingBasePage AssertPageLanguage(string expectedPageLanguageCode)
        {
            var pageUrl = Driver.Url;
            var actualPageLanguageCode = pageUrl.Split('/')[4].Split('.')[0];

            Assert.AreEqual(expectedPageLanguageCode, actualPageLanguageCode);
            return this;
        }

        public LandingBasePage CheckMainSectionsHeaders(List<string> expectedSectionsHeaders)
        {
            var jsExecutor = Driver as IJavaScriptExecutor;
            var actualSectionHeadersList = new List<string>();

            var actualSectionHeadersListFromJs = (ReadOnlyCollection<object>) jsExecutor?.ExecuteScript(
                "let sectionHeaders = document.querySelectorAll('#main h2'); " +
                "let sectionHeadersTitles = []; " +
                "for (i = 0; i < sectionHeaders.length; i++) " +
                "{sectionHeadersTitles.push(sectionHeaders[i].innerText);}; " +
                "return sectionHeadersTitles;");

            foreach (var item in actualSectionHeadersListFromJs)
            {
                actualSectionHeadersList.Add(item.ToString());
            }

            Assert.IsTrue(actualSectionHeadersList.SequenceEqual(expectedSectionsHeaders));

            return this;
        }

        public LandingBasePage ClickLanguageCodeToChangePageLanguage(string languageCode)
        {
            if (Driver.FindElement(languageCodeButton).Text == languageCode)
            {
                Driver.FindElement(By.XPath($"//a[contains(@class,'languageButton') and contains(text(),'{languageCode}')]")).Click();
            }

            return this;
        }
    }
}
