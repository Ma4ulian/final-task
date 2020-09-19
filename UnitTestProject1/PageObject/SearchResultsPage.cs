using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject1.PageObject;

namespace Pavlo_Machulianskyi_Final_Task.PageObject
{
    public class SearchResultsPage : BasePage
    {
        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
