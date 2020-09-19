
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pavlo_Machulianskyi_Final_Task.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestProject1.PageObject;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private const string searchWordInTheFirstSentence = "рыба";
        private const string expectedTextInTheFirstSentence = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
        private const string searchWordInParagraphs = "lorem";
        private const string expectedSentenceWithTenWords = "10";

        private IWebDriver driver;

        [TestInitialize]        
        public void SetUp()
        { 
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://lipsum.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        
        [TestMethod]
        public void CheckThatTextContainsSearchWord()
        {
            HomePage homepage = new HomePage(driver);
            homepage.ClickOnLanguageButton();
            Assert.IsTrue(homepage.SearchWordName(searchWordInTheFirstSentence).Text.Contains(searchWordInTheFirstSentence));
            driver.Close();
        }
        
        [TestMethod]
        public void CheckThatTextContainsSearchString()
        {
            HomePage homepage = new HomePage(driver);
            homepage.ClickOnGenerateButton();          
            Assert.IsTrue(homepage.SearchFirstSentence().Text.Contains("Lorem ipsum dolor sit amet, consectetur adipiscing elit"));
            driver.Close();
        }
        
        
      [TestMethod]
        public void CheckThatLoremIpsumIsGeneratedWithCorrectSizeWithTenWords()
        {
            HomePage homepage = new HomePage(driver);
            homepage.ClickOnWordsRadioButton();
            homepage._radioButton.SetValue(RadioButtonValue.words);
            homepage.ClearAmountField();
            homepage.InputAmountValues(expectedSentenceWithTenWords);
            homepage.ClickOnGenerateButton();       
            homepage.GetTextInFirstParagraph();
            int actual = 1;
            int expected = 10;
            for (int i = 0; i < homepage.GetTextInFirstParagraph().Length; i++)
            {
                if (homepage.GetTextInFirstParagraph()[i] == ' ')
                {
                    actual++;
                }
            }  
            Assert.AreEqual(actual, expected);
            driver.Close();
        }

        [TestMethod]
        public void CheckThatLoremIpsumIsGeneratedWithCorrectSizeWithMinusOneWord()
        {
            HomePage homepage = new HomePage(driver);
            homepage.ClickOnWordsRadioButton();
            driver.FindElement(By.XPath("//input[@id='amount']")).Clear();
            driver.FindElement(By.XPath("//input[@id='amount']")).SendKeys("-1" + Keys.Enter);
            homepage.ClickOnGenerateButton();
            int actual = 1;
            int expected = 5;
            for (int i = 0; i < homepage.GetTextInFirstParagraph().Length; i++) if (homepage.GetTextInFirstParagraph()[i] == ' ') actual++;
            Assert.AreEqual(actual, expected);
            driver.Close();
        }

        [TestMethod]
        public void CheckThatLoremIpsumIsGeneratedWithCorrectSizeWithZeroWord()
        {
            HomePage homepage = new HomePage(driver);
            homepage.ClickOnWordsRadioButton();
            driver.FindElement(By.XPath("//input[@id='amount']")).Clear();
            driver.FindElement(By.XPath("//input[@id='amount']")).SendKeys("0" + Keys.Enter);
            homepage.ClickOnGenerateButton();
            string str = driver.FindElement(By.XPath("//div[@id='lipsum']/p")).Text;
            int actual = 1;
            int expected = 5;
            for (int i = 0; i < str.Length; i++) if (str[i] == ' ') actual++;
            Assert.AreEqual(actual, expected);
            driver.Close();
        }

        [TestMethod]
        public void CheckThatLoremIpsumIsGeneratedWithCorrectSizeWithFiveWords()
        {
            HomePage homepage = new HomePage(driver);
            homepage.ClickOnWordsRadioButton();
            driver.FindElement(By.XPath("//input[@id='amount']")).Clear();
            driver.FindElement(By.XPath("//input[@id='amount']")).SendKeys("5" + Keys.Enter);
            homepage.ClickOnGenerateButton();
            string str = driver.FindElement(By.XPath("//div[@id='lipsum']/p")).Text;
            int actual = 1;
            int expected = 5;
            for (int i = 0; i < str.Length; i++) if (str[i] == ' ') actual++;
            Assert.AreEqual(actual, expected);
            driver.Close();
        }

        [TestMethod]
        public void CheckThatLoremIpsumIsGeneratedWithCorrectSizeWithTwentyWords()
        {
            HomePage homepage = new HomePage(driver);
            homepage.ClickOnWordsRadioButton();
            driver.FindElement(By.XPath("//input[@id='amount']")).Clear();
            driver.FindElement(By.XPath("//input[@id='amount']")).SendKeys("20" + Keys.Enter);
            homepage.ClickOnGenerateButton();
            string str = driver.FindElement(By.XPath("//div[@id='lipsum']/p")).Text;
            int actual = 1;
            int expected = 20;
            for (int i = 0; i < str.Length; i++) if (str[i] == ' ') actual++;
            Assert.AreEqual(actual, expected);
            driver.Close();
        }

        [TestMethod]
        public void CheckThatLoremIpsumIsGeneratedWithCorrectSizeWithZeroBites()
        {
            HomePage homepage = new HomePage(driver);
            homepage.ClickOnBytesRadioButton();
            driver.FindElement(By.XPath("//input[@id='amount']")).Clear();
            driver.FindElement(By.XPath("//input[@id='amount']")).SendKeys("0" + Keys.Enter);
            homepage.ClickOnGenerateButton();
            string str = driver.FindElement(By.XPath("//div[@id='lipsum']/p")).Text;
            int actual = 0;
            int expected = 5;
            for (int i = 0; i < str.Length; i++) actual++;
            Assert.AreEqual(actual, expected);
            driver.Close();
        }

        [TestMethod]
        public void CheckThatLoremIpsumIsGeneratedWithCorrectSizeWithOneBites()
        {
            HomePage homepage = new HomePage(driver);
            homepage.ClickOnBytesRadioButton();
            driver.FindElement(By.XPath("//input[@id='amount']")).Clear();
            driver.FindElement(By.XPath("//input[@id='amount']")).SendKeys("1" + Keys.Enter);
            homepage.ClickOnGenerateButton();
            string str = driver.FindElement(By.XPath("//div[@id='lipsum']/p")).Text;
            int actual = 0;
            int expected = 3;
            for (int i = 0; i < str.Length; i++) actual++;
            Assert.AreEqual(actual, expected);
            driver.Close();
        }

        [TestMethod]
        public void CheckThatLoremIpsumIsGeneratedWithCorrectSizeWithFiveBites()
        {
            HomePage homepage = new HomePage(driver);
            homepage.ClickOnBytesRadioButton();
            driver.FindElement(By.XPath("//input[@id='amount']")).Clear();
            driver.FindElement(By.XPath("//input[@id='amount']")).SendKeys("5" + Keys.Enter);
            homepage.ClickOnGenerateButton();
            string str = driver.FindElement(By.XPath("//div[@id='lipsum']/p")).Text;
            int actual = 0;
            int expected = 5;
            for (int i = 0; i < str.Length; i++)
            {
                actual++;
            }               
            Assert.AreEqual(actual, expected);
            driver.Close();
        }

        [TestMethod]
        public void CheckThatLoremIpsumIsGeneratedWithCorrectSizeWithTenBites()
        {
            HomePage homepage = new HomePage(driver);
            homepage.ClickOnBytesRadioButton();
            driver.FindElement(By.XPath("//input[@id='amount']")).Clear();
            driver.FindElement(By.XPath("//input[@id='amount']")).SendKeys("10" + Keys.Enter);
            homepage.ClickOnGenerateButton();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string str = driver.FindElement(By.XPath("//div[@id='lipsum']/p")).Text;
            int actual = 0;
            int expected = 10;
            for (int i = 0; i < str.Length; i++) actual++;
            Assert.AreEqual(actual, expected);
            driver.Close();
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (driver != null)
                driver.Quit();
        }

        [TestMethod]
        public void CheckThatLoremIpsumContainsInParagraphs()
        {           
            int[] arrayParagraphsCount = new int[10];
            for (int i = 0; i < 10; i++)
            {
                driver.Navigate().GoToUrl("https://lipsum.com/");
                HomePage homepage = new HomePage(driver);
                homepage.ClickOnGenerateButton();
                List<string> paragraphs = homepage.GetTextOnPage().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
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

