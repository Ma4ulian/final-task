using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject1.PageObject;

namespace Pavlo_Machulianskyi_Final_Task.PageObject
{
    public class SearchResultsPage
    {
        private readonly IWebDriver driver;

        public SearchResultsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='lipsum']/p")]
        public IWebElement textInFirstParagraph;

        [FindsBy(How = How.XPath, Using = "//div[@id='lipsum']")]
        public IWebElement textOnPage;


        public string GetTextInFirstParagraph()
        {
            return textInFirstParagraph.Text;
        }

        public string GetTextOnPage()
        {
            return textOnPage.Text;
        }

        public IWebElement SearchWordName(string searchWordInTheFirstSentence)
        {
            return driver.FindElement(By.XPath($"//div[@id='Panes']//p[contains(text(),'{searchWordInTheFirstSentence}')]"));
        }

        public IWebElement SearchFirstSentence()
        {
            return driver.FindElement(By.XPath("//*[@id='lipsum']/p[1]"));
        }
    }
}
