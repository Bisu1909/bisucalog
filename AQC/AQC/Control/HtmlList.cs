using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AQC.Control
{
    public class HtmlList : HtmlElementBase
    {
        public HtmlList(IWebElement webElement) : base(webElement)
        {
        }

        public IList<HtmlListItem> GetItems()
        {
            var items = _element.FindElements(By.TagName("li"));
            return items.Select(x => new HtmlListItem(x)).ToList();
        }
        public HtmlListItem GetItemAt(int index)
        {
            var items = _element.FindElements(By.TagName("li"));
            return new HtmlListItem(items[index]);
        }
    }
    public class HtmlListItem : HtmlElementBase
    {
        public HtmlListItem(IWebElement webElement) : base(webElement)
        {
        }
    }
}
