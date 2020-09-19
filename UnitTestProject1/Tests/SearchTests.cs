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
        private IWebDriver _driver;
       
        public SearchTests(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }


        [TestMethod]
        public void CheckThatLoremIpsumIsNotSee()
        {
            HomePage homepage = new HomePage(_driver);
            homepage.ClickOnStartRadioButton();
            homepage.ClickOnGenerateButton();
            Assert.IsFalse(homepage.GetTextInFirstParagraph().Contains("Lorem ipsum"));
        }

        [TestMethod]
        public void CheckThatTextContainsSearchWord()
        {
            HomePage homepage = new HomePage(_driver);
            homepage.ClickOnLanguageButton();
            Assert.IsTrue(homepage.SearchWordName("рыба").Text.Contains("рыба"));
            _driver.Close();
        }

        [TestMethod]
        public void CheckThatTextContainsSearchString()
        {
            HomePage homepage = new HomePage(_driver);
            homepage.ClickOnGenerateButton();
            Assert.IsTrue(homepage.SearchFirstSentence().Text.Contains("Lorem ipsum dolor sit amet, consectetur adipiscing elit"));
            _driver.Close();
        }
    }
}
