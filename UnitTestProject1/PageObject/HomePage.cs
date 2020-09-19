using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;
using Pavlo_Machulianskyi_Final_Task.PageObject;

namespace UnitTestProject1.PageObject
{
    public class HomePage : BasePage
    {
        private IWebDriver _driver;
        //private readonly By textOnPage = By.XPath("//div[@id='lipsum']");
       // private readonly By textInFirstParagraph = By.XPath("//div[@id='lipsum']/p");
        //private readonly By generateButton = By.XPath("//*[@id='generate']");
       // private readonly By startRadioButton = By.XPath("//input[@id='start']");
        public RadioButton _radioButton;

        public HomePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
            _radioButton = new RadioButton(wordsRadioButton, paragraphsRadioButton, bytesRadioButton, listsRadioButton);
        }


        private IWebElement GetWebElementById(string id) => _driver.FindElement(By.XPath($"//*[@id='{id}']"));


        [FindsBy(How = How.XPath, Using = "//div[@id='lipsum']/p")]
        private readonly IWebElement textInFirstParagraph;

        [FindsBy(How = How.XPath, Using = "//*[@id='generate']")]
        private readonly IWebElement generateButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='start']")]
        private IWebElement startRadioButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='Languages']/a[@class='ru']")]
        private readonly IWebElement languageButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='words']")]
        private IWebElement wordsRadioButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='bytes']")]
        private IWebElement bytesRadioButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='amount']")]
        private readonly IWebElement clearAmount;

        [FindsBy(How = How.XPath, Using = "//div[@id='lipsum']")]
        private IWebElement textOnPage;

        [FindsBy(How = How.XPath, Using = "//input[@id='amount']")]
        private IWebElement inputAmount;

        [FindsBy(How = How.XPath, Using = "//input[@id='paragraphs']")]
        private IWebElement paragraphsRadioButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='lists']")]
        private IWebElement listsRadioButton;

        public string GetTextOnPage()
        {
            return textOnPage.Text;
        }


        public void ClickOnGenerateButton()
        {
            generateButton.Click();
        }

        public string GetTextInFirstParagraph()
        {
            return textInFirstParagraph.Text;
        }

        public void ClickOnStartRadioButton()
        {
            startRadioButton.Click();
        }

        public void ClickOnLanguageButton()
        {
            languageButton.Click();
        }

        public void ClickOnWordsRadioButton()
        {
            wordsRadioButton.Click();
        }

        public void ClickOnBytesRadioButton()
        {
            bytesRadioButton.Click();
        }

        public IWebElement SearchWordName(string searchWordInTheFirstSentence)
        {
            return _driver.FindElement(By.XPath($"//div[@id='Panes']//p[contains(text(),'{searchWordInTheFirstSentence}')]"));
        }

        public IWebElement SearchFirstSentence()
        {
            return _driver.FindElement(By.XPath("//*[@id='lipsum']/p[1]"));
        }

        public void ClearAmountField()
        {
            clearAmount.Clear();
        }

        public void InputAmountValues(string expectedSentenceWithTenWords)
        {
            inputAmount.SendKeys(expectedSentenceWithTenWords);
        }

    }

}
