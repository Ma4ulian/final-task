using NUnit.Framework;
using OpenQA.Selenium;
using Pavlo_Machulianskyi_Final_Task.PageObject;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using UnitTestProject1.PageObject;

namespace Pavlo_Machulianskyi_Final_Task.Steps
{
    [Binding]
    class SearchResultTestSteps
    {
        private readonly HomePage _page;
        private SearchResultsPage _searchPage;

        public SearchResultTestSteps(IWebDriver driver)
        {
            _page = new HomePage(driver);
            _searchPage = new SearchResultsPage(driver);
        }

        [When(@"click on Start button")]
        public void ClickOnStartButton()
        {
            _page.ClickOnStartButton();
        }

        [When(@"click on Generate button")]
        public void ClickOnGenerateButton()
        {
            _page.ClickOnGenerateButton();
        }

        [When(@"click on Language button")]
        public void ClickOnLanguageButton()
        {
            _page.ClickOnLanguageButton();
        }

        [Then(@"the first paragraph in Search result is missing certain ""(.*)""")]
        public void ThanTheFirstParagraphInSearchResultIsMissingCertainValue(string search)
        {
            Assert.IsFalse(_searchPage.GetTextInFirstParagraph().Contains(search), "Lorem ipsum contains on the page");
        }

        [Then(@"the text in Search result is contain ""(.*)""")]
        public void ThanThatTextContainsSearchWord(string searchWord)
        {
            Assert.IsTrue(_searchPage.SearchWordName(searchWord).Text.Contains(searchWord), $"The word {searchWord} is missing from the page");
        }

        [Then(@"the text is contain ""(.*)""")]
        public void ThanThatTextContainsSearchString(string searchString)
        {
            Assert.IsTrue(_searchPage.SearchFirstSentence(searchString).Text.Contains(searchString), "Search string is missing in the first sentence");
        }
    }
}
