using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Pavlo_Machulianskyi_Final_Task.PageObject;
using Pavlo_Machulianskyi_Final_Task.Elements;
using System;

namespace UnitTestProject1.PageObject
{

    public class HomePage
    {
        private readonly IWebDriver driver;
        public RadioButton radioButton;
        public string url = "https://lipsum.com/";

        [FindsBy(How = How.XPath, Using = "//input[@id='generate']")]
        private IWebElement generateButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='start']")]
        private IWebElement startButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='Languages']/a[@class='ru']")]
        private IWebElement languageButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='amount']")]
        private IWebElement Amount;

        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver; 
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
            IWebElement wordElement = GetWebElementById(Id.words);
            IWebElement bytesElement = GetWebElementById(Id.bytes);
            IWebElement paragraphsElement = GetWebElementById(Id.paras);
            IWebElement listsElement = GetWebElementById(Id.lists);
            radioButton = new RadioButton(wordElement, paragraphsElement, bytesElement, listsElement);
        }

        private IWebElement GetWebElementById(Id id) => driver.FindElement(By.XPath($"//input[@id='{id}']"));
  
        public void ClickOnGenerateButton()
        {
           generateButton.Click();
        }
        
        public void ClickOnStartButton()
        {
            startButton.Click();
        }
        
        public void ClickOnLanguageButton()
        {
            languageButton.Click();
        }

        public void ClearAmountField()
        {
            Amount.Clear();
        }

        public void InputAmountValues(int inputAmountValues)
        {
            Amount.SendKeys(inputAmountValues.ToString());
        }

        public void GenerateAsWordsWithStartText(int inputAmountValues)
        {
            Amount.Clear();
            Amount.SendKeys(inputAmountValues.ToString());
            radioButton.SetValue(Id.words);
            generateButton.Click();
        }

        public void GenerateAsBytesWithStartText(int inputAmountValues)
        {
            Amount.Clear();
            Amount.SendKeys(inputAmountValues.ToString());
            radioButton.SetValue(Id.bytes);
            generateButton.Click();
        }

    }
}
