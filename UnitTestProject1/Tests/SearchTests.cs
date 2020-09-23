using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestProject1.PageObject;
using Pavlo_Machulianskyi_Final_Task.PageObject;

namespace Pavlo_Machulianskyi_Final_Task.Tests
{
    [TestClass]
    public class SearchTests : BaseTest
    {


        [TestMethod]
        public void CheckThatLoremIpsumIsMissingInFirstParagraph()
        {
            HomePage homepage = new HomePage(driver);
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            homepage.ClickOnStartRadioButton();
            homepage.ClickOnGenerateButton();
            if (searchResultsPage.GetTextInFirstParagraph().Contains("Lorem ipsum"))
                Assert.Fail("Lorem ipsum contains on the page");
            else 
                Assert.IsFalse(searchResultsPage.GetTextInFirstParagraph().Contains("Lorem ipsum"));

        }

        [TestMethod]
        public void CheckThatTextContainsSearchWord()
        {
            HomePage homepage = new HomePage(driver);
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            homepage.ClickOnLanguageButton();
            if (searchResultsPage.SearchWordName("рыба").Text.Contains("рыба"))
                Assert.IsTrue(searchResultsPage.SearchWordName("рыба").Text.Contains("рыба"));
            else
                Assert.Fail("The word рыба is missing from the page");                
        }

        [TestMethod]
        public void CheckThatTextContainsSearchString()
        {
            HomePage homepage = new HomePage(driver);
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            homepage.ClickOnGenerateButton();
            if (searchResultsPage.SearchFirstSentence().Text.Contains("Lorem ipsum dolor sit amet, consectetur adipiscing elit"))
                Assert.IsTrue(searchResultsPage.SearchFirstSentence().Text.Contains("Lorem ipsum dolor sit amet, consectetur adipiscing elit"));
            else
                Assert.Fail("Search string is missing in the first sentence");

        }
    }
}
