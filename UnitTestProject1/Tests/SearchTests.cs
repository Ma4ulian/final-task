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
        private const string searchWordInParagraphs = "lorem";

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

        [TestMethod]
        public void CheckThatLoremIpsumContainsInParagraphs()
        {
            int[] arrayParagraphsCount = new int[10];
            for (int i = 0; i < 10; i++)
            {
                HomePage homepage = new HomePage(driver);
                homepage.Navigate();
                SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
                homepage.ClickOnGenerateButton();
                List<string> paragraphs = searchResultsPage.GetTextOnPage().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var matchQuery = from paragraph in paragraphs
                                 where paragraph.ToLowerInvariant().Contains(searchWordInParagraphs) == true
                                 select paragraph;
                int paragraphsCount = matchQuery.Count();
                arrayParagraphsCount[i] = matchQuery.Count();
            }
            double averageNumberOfParagraphs = arrayParagraphsCount.Average();
            Assert.IsTrue(averageNumberOfParagraphs > 2);
        }
    }
}
