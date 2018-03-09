using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC
{
    public abstract class HtmlElementBase
    {
        protected IWebElement _element;
        public HtmlElementBase(IWebElement webElement)
        {
            _element = webElement;
        }
        public IWebElement WrapperElement
        {
            get { return _element; }
        }
     
        public virtual string Text
        {
            get { return _element.Text; }
        }
        public virtual string TagName
        {
            get { return _element.TagName; }
        }
        public virtual string CssClass
        {
           get { return _element.GetAttribute("class"); }
        }
        public string GetAttribute(string attrName)
        {
            return _element.GetAttribute(attrName);
        }
        public void Click()
        {
            _element.Click();
        }
        public virtual void Clear()
        {
            _element.Clear();
        }
    }
}
