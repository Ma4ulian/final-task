using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using Pavlo_Machulianskyi_Final_Task.Elements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace Pavlo_Machulianskyi_Final_Task.Hooks
{
	[Binding]
	public class Hooks
	{
		private readonly IObjectContainer _objectContainer;
		private IWebDriver _driver;
		private static TestData _testData;

		public Hooks(IObjectContainer objectContainer)
		{
			_objectContainer = objectContainer;
		}

		[BeforeTestRun]
		public static void BeforeTestRun()
		{
			_testData = new TestData();
		}

		[BeforeScenario]
		public void BeforeScenario()
		{
			_driver = new ChromeDriver();
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			_driver.Manage().Window.Maximize();
			_objectContainer.RegisterInstanceAs(_driver);
			_objectContainer.RegisterInstanceAs(_testData);
		}

		[AfterScenario]
		public void AfterScenario()
		{
			_driver?.Dispose();
		}
	}
}
