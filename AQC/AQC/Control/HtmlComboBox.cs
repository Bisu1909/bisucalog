using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC
{
    public class HtmlComboBox : HtmlInput
    {
        private SelectElement _wrapper;
        public HtmlComboBox(IWebElement webElement) : base(webElement)
        {
            _wrapper = new SelectElement(webElement);
        }
        public bool IsMultiple { get { return _wrapper.IsMultiple; } }
        public HtmlComboBoxOption SelectedOption
        {
            get
            {
                return new HtmlComboBoxOption(_wrapper, _wrapper.SelectedOption);
            }
        }
        public IList<HtmlComboBoxOption> Options
        {
            get
            {
                var options = _wrapper.Options;
                return options.Select(x => new HtmlComboBoxOption(_wrapper, x)).ToList();
            }
        }
        public void SetSelectedOption(HtmlComboBoxOption option)
        {
            _wrapper.SelectByValue(option.Value);
        }
        public IList<HtmlComboBoxOption> AllSelectedOptions
        {
            get
            {
                var options = _wrapper.AllSelectedOptions;
                return options.Select(x => new HtmlComboBoxOption(_wrapper, x)).ToList();
            }
        }
        public void DeselectAll()
        {
            _wrapper.DeselectAll();
        }
        public void DeselectByIndex(int index)
        {
            _wrapper.DeselectByIndex(index);
        }
        public void DeselectByText(string text)
        {
            _wrapper.DeselectByText(text);
        }
        public void DeselectByValue(string value)
        {
            _wrapper.DeselectByValue(value);
        }
        public void SelectByIndex(int index)
        {
            _wrapper.SelectByIndex(index);
        }
        public void SelectByText(string text)
        {
            _wrapper.SelectByText(text);
        }
        public void SelectByValue(string value)
        {
            _wrapper.SelectByValue(value);
        }
    }

    public class HtmlComboBoxOption : HtmlElementBase
    {
        private SelectElement _parent;
        public HtmlComboBoxOption(SelectElement parent, IWebElement webElement) : base(webElement)
        {
            _parent = parent;
            _element = webElement;
        }
        public string Value
        {
            get { return _element.GetAttribute("value"); }
        }    
        public void Select()
        {
            _parent.SelectByValue(this.Value);
        }
    }
}
