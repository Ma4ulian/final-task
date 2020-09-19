using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;
using UnitTestProject1.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pavlo_Machulianskyi_Final_Task.Tests
{
    [TestClass]
    public class LoremTests : BaseTest
    {
        private IWebDriver _driver;
        public LoremTests(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }


       
    }
}
