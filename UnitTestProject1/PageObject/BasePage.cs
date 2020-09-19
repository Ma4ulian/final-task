using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1.PageObject
{
    public class BasePage
    {
        private readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Implisitwait(long timeToWait)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeToWait);
        }
    }
}
