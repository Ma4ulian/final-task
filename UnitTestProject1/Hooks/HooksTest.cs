using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pavlo_Machulianskyi_Final_Task.PageObject;
using System;
using UnitTestProject1.PageObject;

namespace Pavlo_Machulianskyi_Final_Task.Hooks
{
    public class HooksTest
    {
        public IWebDriver driver;


        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://lipsum.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (driver != null)
                driver.Quit();
        }

        public HomePage GetHomePage()
        {
            return new HomePage(GetDriver());
        }

        public SearchResultsPage GetSearchResultsPage()
        {
            return new SearchResultsPage(GetDriver());
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }


    }
}