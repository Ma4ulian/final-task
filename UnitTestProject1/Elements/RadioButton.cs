using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject1.PageObject;
using Pavlo_Machulianskyi_Final_Task.Elements;

namespace Pavlo_Machulianskyi_Final_Task.PageObject
{

    public class RadioButton
    {
        private readonly IWebElement _wordsWebElement;
        private readonly IWebElement _paragraphsWebElement;
        private readonly IWebElement _bytesWebElement;
        private readonly IWebElement _listsWebElement;
        public RadioButton(IWebElement wordsWebElement, IWebElement paragraphsWebElement, IWebElement bytesWebElement, IWebElement listsWebElement)
        {
            _wordsWebElement = wordsWebElement;
            _paragraphsWebElement = paragraphsWebElement;
            _bytesWebElement = bytesWebElement;
            _listsWebElement = listsWebElement;
        }

        public void SetValue(Id radioButtonValue)
        {
            switch (radioButtonValue)
            {
                case Id.paras:
                    _paragraphsWebElement.Click();
                    break;
                case Id.words:
                    _wordsWebElement.Click();
                    break;
                case Id.bytes:
                    _bytesWebElement.Click();
                    break;
                case Id.lists:
                    _listsWebElement.Click();
                    break;
                default:
                    break;
            }

        }

    }
}
