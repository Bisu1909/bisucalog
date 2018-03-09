using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AQC
{
    public class HtmlForm : HtmlElementBase
    {
        public HtmlForm(IWebElement webElement) : base(webElement)
        {
        }
        public HtmlInput GetInput(string name)
        {
            var inputWebElements = _element.FindElements(By.Name(name));
            var firstElement = inputWebElements[0];
            var type = firstElement.GetAttribute("type");
            switch (type.ToLower())
            {
                case "checkbox": return new HtmlCheckBox(firstElement);
                case "radio": return new HtmlRadioGroup(inputWebElements.ToList());            
                case "hidden": return new HtmlHiddenField(firstElement);
                case "textarea": return new HtmlTextArea(firstElement);
                default: return new HtmlTextBox(firstElement);
            }
            throw new InvalidElementStateException("GetInput: The element is not valid input. Valid inputs are 'textarea' or 'input' not have type 'button','reset', 'submit' ");
        }
    }
}
