using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Pavlo_Machulianskyi_Final_Task.Elements;
using Pavlo_Machulianskyi_Final_Task.PageObject;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UnitTestProject1.PageObject;

namespace Pavlo_Machulianskyi_Final_Task.Steps
{
    [Binding]
    public class LoremSteps
    {
        private HomePage _homepage;
        private SearchResultsPage _searchPage;
        private TestData _testData;
        private int actualNumbersOfWordsOnThePage = 1;

        public LoremSteps(IWebDriver driver, TestData testData)
        {
            _homepage = new HomePage(driver);
            _searchPage = new SearchResultsPage(driver);
            _testData = testData;
        }

        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            _homepage.Navigate();
        }

        [When(@"I generate (.*) bytes of text with default starting text")]
        public void WhenIGenerateBytesOfText(int inputNumbersOfBytesOnThePage)
        {
           _testData.ActualNumbersOfBytesOnThePage = _searchPage.GetNumbersOfBytesOnThePage(inputNumbersOfBytesOnThePage, _homepage);
        }

        [Then(@"(.*) bytes has been found on the page")]
        public void ThenBytesOfTextGeneratesAndExactMatchIsTrue(int expectedNumbersOfBytesOnThePage)
        {
            Assert.AreEqual(expectedNumbersOfBytesOnThePage, _testData.ActualNumbersOfBytesOnThePage);
        }

        [When(@"I generate (.*) words of text with default starting text")]
        public void WhenIGenerateWordsOfText(int inputNumbersOfWordsOnThePage)
        {
            _homepage.GenerateAsWordsWithStartText(inputNumbersOfWordsOnThePage);
            for (int i = 0; i < _searchPage.GetTextInFirstParagraph().Length; i++)
            {
                if (_searchPage.GetTextInFirstParagraph()[i] == ' ')
                {
                    actualNumbersOfWordsOnThePage++;
                }
            }
            _testData.ActualNumbersOfWordsOnThePage = actualNumbersOfWordsOnThePage;
        }

        [Then(@"(.*) words has been found on the page")]
        public void ThenWordsOfTextGeneratesAndExactMatchIsTrue(int expectedNumbersOfWordsOnThePage)
        {
            Assert.AreEqual(expectedNumbersOfWordsOnThePage, _testData.ActualNumbersOfWordsOnThePage);
        }
    }
}


    
