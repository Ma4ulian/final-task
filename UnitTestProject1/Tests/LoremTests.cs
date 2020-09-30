using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;
using UnitTestProject1.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pavlo_Machulianskyi_Final_Task.PageObject;
using Pavlo_Machulianskyi_Final_Task.Elements;
using Pavlo_Machulianskyi_Final_Task.Hooks;

namespace Pavlo_Machulianskyi_Final_Task.Tests
{
    [TestClass]
    public class LoremTests : HooksTest
    {

        [DataTestMethod]
        [DataRow(10, 10)]
        [DataRow(-1, 5)]
        [DataRow(0, 5)]
        [DataRow(5, 5)]
        [DataRow(20, 20)]
        public void CheckThatLoremIpsumIsGeneratedWithCorrectSizeWithWords(int inputNumbersOfWords, int expectedNumbersOfWordsOnThePage)
        {
            HomePage homepage = new HomePage(driver);
            homepage.Navigate();
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            homepage.radioButton.SetValue(Id.words);
            homepage.ClearAmountField();
            homepage.InputAmountValues(inputNumbersOfWords);
            homepage.ClickOnGenerateButton();
            searchResultsPage.GetTextInFirstParagraph();
            int actualNumbersOfWordsOnThePage = 1;
            for (int i = 0; i < searchResultsPage.GetTextInFirstParagraph().Length; i++)
            {
                if (searchResultsPage.GetTextInFirstParagraph()[i] == ' ') 
                {
                    actualNumbersOfWordsOnThePage++;
                }
            }
            Assert.AreEqual(actualNumbersOfWordsOnThePage, expectedNumbersOfWordsOnThePage);
        }

        [DataTestMethod]
        [DataRow(0, 5)]
        [DataRow(1, 3)]
        [DataRow(5, 5)]
        [DataRow(10, 10)]
        public void CheckThatLoremIpsumIsGeneratedWithCorrectSizeWithBytes(int inputNumbersOfBytes, int expectedNumbersOfBytesOnThePage)
        {
            HomePage homepage = new HomePage(driver);
            homepage.Navigate();
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            homepage.radioButton.SetValue(Id.bytes);
            homepage.ClearAmountField();
            homepage.InputAmountValues(inputNumbersOfBytes);
            homepage.ClickOnGenerateButton();
            searchResultsPage.GetTextInFirstParagraph();
            int actualNumbersOfBytesOnThePage = 0;
            for (int i = 0; i < searchResultsPage.GetTextInFirstParagraph().Length; i++)
            {
                actualNumbersOfBytesOnThePage++;               
            }
            Assert.AreEqual(actualNumbersOfBytesOnThePage, expectedNumbersOfBytesOnThePage);
        }
    }
}
