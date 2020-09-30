using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestProject1.PageObject;
using Pavlo_Machulianskyi_Final_Task.PageObject;
using Pavlo_Machulianskyi_Final_Task.Hooks;

namespace Pavlo_Machulianskyi_Final_Task.Tests
{
    [TestClass]
    public class SearchTests : HooksTest
    {
        private const string loremIpsum = "Lorem ipsum";
        private const string searchWord = "рыба";
        private const string searchString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";

        [TestMethod]
        public void CheckThatLoremIpsumIsMissingInFirstParagraph()
        {
            HomePage homepage = new HomePage(driver);
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            homepage.ClickOnStartButton();
            homepage.ClickOnGenerateButton();
            Assert.IsFalse(searchResultsPage.GetTextInFirstParagraph().Contains(loremIpsum), "Lorem ipsum contains on the page");
        }

        [TestMethod]
        public void CheckThatTextContainsSearchWord()
        {
            HomePage homepage = new HomePage(driver);
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            homepage.ClickOnLanguageButton();
            Assert.IsTrue(searchResultsPage.SearchWordName(searchWord).Text.Contains(searchWord), $"The word {searchWord} is missing from the page");           
        }

        [TestMethod]
        public void CheckThatTextContainsSearchString()
        {
            HomePage homepage = new HomePage(driver);
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            homepage.ClickOnGenerateButton();
            Assert.IsTrue(searchResultsPage.SearchFirstSentence(searchString).Text.Contains(searchString), "Search string is missing in the first sentence");
        }
    }
}
