using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Pavlo_Machulianskyi_Final_Task.PageObject;

namespace UnitTestProject1.PageObject
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        public RadioButton _radioButton;

        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            IWebElement wordElement = GetWebElementById(Id.words.ToString());
            IWebElement bytesElement = GetWebElementById(Id.bytes.ToString());
            IWebElement paragraphsElement = GetWebElementById(Id.paras.ToString());
            IWebElement listsElement = GetWebElementById(Id.lists.ToString());
            _radioButton = new RadioButton(wordElement, paragraphsElement, bytesElement, listsElement);
        }

        public enum Id
        {
            paras,
            words,
            bytes,
            lists
        }
        private IWebElement GetWebElementById(string id) => driver.FindElement(By.XPath($"//input[@id='{id}']"));

        //public void GoTo(Id id) => GetWebElementById(id.ToString());

        [FindsBy(How = How.XPath, Using = "//input[@id='generate']")]
        public IWebElement generateButton;
        
        [FindsBy(How = How.XPath, Using = "//input[@id='start']")]
        public IWebElement startRadioButton;

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
        
        public void ClickOnStartRadioButton()
        {
            startRadioButton.Click();
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

    }

}
