using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AQC
{
    public class HtmlCheckBox : HtmlInput
    {
        public HtmlCheckBox(IWebElement webElement) : base(webElement)
        {
        }
        public virtual void Check()
        {
            var isChecked = _element.Selected;
            if (!isChecked) _element.Click();
        }
        public virtual void UnCheck()
        {
            var isChecked = _element.Selected;
            if (isChecked) _element.Click();
        }
        public virtual bool IsChecked
        {
            get
            {
                return _element.Selected;
            }
        }
    }
}
