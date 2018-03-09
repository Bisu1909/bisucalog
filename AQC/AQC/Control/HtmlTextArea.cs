using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AQC
{
    public class HtmlTextArea : HtmlInput
    {
        public HtmlTextArea(IWebElement webElement) : base(webElement)
        {
            if (!webElement.TagName.ToLower().Equals("textarea")) throw new InvalidElementStateException("Web Element is not textarea html tag");
        }
    }
}
