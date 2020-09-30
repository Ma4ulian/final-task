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

        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver; 
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement wordElement = GetWebElementById(Id.words);
            IWebElement bytesElement = GetWebElementById(Id.bytes);
            IWebElement paragraphsElement = GetWebElementById(Id.paras);
            IWebElement listsElement = GetWebElementById(Id.lists);
            radioButton = new RadioButton(wordElement, paragraphsElement, bytesElement, listsElement);
        }

        private IWebElement GetWebElementById(Id id) => driver.FindElement(By.XPath($"//input[@id='{id}']"));

        [FindsBy(How = How.XPath, Using = "//input[@id='generate']")]
        public IWebElement generateButton;
        
        [FindsBy(How = How.XPath, Using = "//input[@id='start']")]
        public IWebElement startButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='Languages']/a[@class='ru']")]
        public IWebElement languageButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='amount']")]
        public IWebElement clearAmount;

        [FindsBy(How = How.XPath, Using = "//input[@id='amount']")]
        public IWebElement inputAmount;
  
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
            clearAmount.Clear();
        }

        public void InputAmountValues(int inputAmountValues)
        {
            inputAmount.SendKeys(inputAmountValues.ToString());
        }

        public void GenerateAsWordsWithStartText(int inputAmountValues)
        {
            clearAmount.Clear();
            inputAmount.SendKeys(inputAmountValues.ToString());
            radioButton.SetValue(Id.words);
            generateButton.Click();
        }

        public void GenerateAsBytesWithStartText(int inputAmountValues)
        {
            clearAmount.Clear();
            inputAmount.SendKeys(inputAmountValues.ToString());
            radioButton.SetValue(Id.bytes);
            generateButton.Click();
        }

    }
}
