using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject1.PageObject;

namespace Pavlo_Machulianskyi_Final_Task.PageObject
{
    public enum RadioButtonValue
    {
        paragraphs,
        words,
        bytes,
        lists
    }
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

        public void SetValue(RadioButtonValue radioButtonValue)
        {
            switch (radioButtonValue)
            {
                case RadioButtonValue.paragraphs:
                    _paragraphsWebElement.Click();
                    break;
                case RadioButtonValue.words:
                    _wordsWebElement.Click();
                    break;
                case RadioButtonValue.bytes:
                    _bytesWebElement.Click();
                    break;
                case RadioButtonValue.lists:
                    _listsWebElement.Click();
                    break;
                default:
                    break; 
            }

        }
        
    }
}
