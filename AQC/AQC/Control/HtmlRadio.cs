using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AQC
{
    public class HtmlRadio : HtmlInput
    {
        public HtmlRadio(IWebElement webElement) : base(webElement)
        {
        }
        public virtual void Select()
        {
            var isChecked = _element.Selected;
            if (!isChecked) _element.Click();
        }
        public virtual bool IsChecked
        {
            get
            {
                return _element.Selected;
            }
        }
    }
    public class HtmlRadioGroup : HtmlInput
    {
        private List<HtmlRadio> _radioes;
        public HtmlRadioGroup(List<IWebElement> webElements) : base(webElements[0])
        {
            if (webElements.Exists(x => x.GetAttribute("type") != "radio"))
                throw new InvalidElementStateException("each radio in group must have type is 'radio'.");
            _radioes = webElements.Select(x => new HtmlRadio(x)).ToList();
        }

        public override void Clear()
        {
            foreach (var radio in _radioes)
            {
                _radioes.Clear();
            }
        }
        public override string CssClass
        {
            get
            {
                throw new InvalidOperationException("HtmlRadioGroup dont support CssClass attribute.");
            }
        }
        public override void SetValue(string value)
        {
            throw new InvalidOperationException("HtmlRadioGroup dont support SetValue method.");
        }
        public override string TagName => base.TagName;
        public override string Text
        {
            get
            {
                throw new InvalidOperationException("HtmlRadioGroup dont support Text attribute.");
            }
        }
        public HtmlRadio SelectedRadio
        {
            get
            {
                foreach (var radio in _radioes)
                {
                    if (radio.IsChecked) return radio;
                };
                return null;
            }
        }
        public override string Value
        {
            get
            {
                var radio = this.SelectedRadio;
                return radio?.Value;
            }
        }
    }
}
