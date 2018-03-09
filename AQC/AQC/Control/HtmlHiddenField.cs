using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AQC
{
    public class HtmlHiddenField : HtmlInput
    {
        public HtmlHiddenField(IWebElement webElement) : base(webElement)
        {
        }
        public override void SetValue(string value)
        {
            var wrapperDriver = ((RemoteWebElement)_element).WrappedDriver;
            string script = "arguments[0].setAttribute('value', arguments[1]);";
            ((IJavaScriptExecutor)wrapperDriver).ExecuteScript(script, _element, value);
        }
    }
}
