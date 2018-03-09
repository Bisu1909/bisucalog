using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC
{
    public class HtmlInput : HtmlElementBase
    {
        private static readonly string[] tagNames = new string[] { "input", "textarea" };
        public HtmlInput(IWebElement webElement) : base(webElement)
        {
            if (!tagNames.Contains(webElement.TagName.ToLower())) throw new InvalidElementStateException("Web Element is not input or textarea html tag");
        }

        public virtual string Value
        {
            get { return base.GetAttribute("value"); }
        }
        public virtual void SetValue(string value)
        {
            _element.SendKeys(value);
        }
    }
}
