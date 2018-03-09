using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AQC
{
    public class HtmlCell : HtmlElementBase
    {
        public HtmlCell(IWebElement webElement) : base(webElement)
        {
            if(!string.Equals(webElement.TagName.ToLower(), "td") || !string.Equals(webElement.TagName.ToLower(), "th"))
                throw new InvalidElementStateException("Cell must have tag name is 'td' or 'th'.");
        }
    }
    public class HtmlRow : HtmlElementBase
    {
        public HtmlRow(IWebElement webElement) : base(webElement)
        {
            if (!string.Equals(webElement.TagName.ToLower(), "tr"))
                throw new InvalidElementStateException("Row must have tag name is 'tr'.");
        }
        public IList<HtmlCell> GetCells()
        {
            var cells = _element.FindElements(By.TagName("td"));
            if(cells == null || cells.Count == 0)
            {
                cells = _element.FindElements(By.TagName("th"));
            }
            return cells.Select(x => new HtmlCell(x)).ToList();
        }
        public HtmlCell GetCellAt(int index)
        {
            var cells = _element.FindElements(By.TagName("td"));
            if (cells == null || cells.Count == 0)
            {
                cells = _element.FindElements(By.TagName("th"));
            }
            return new HtmlCell(cells[index]);
        }
    }
   
    public class HtmlTable : HtmlElementBase
    {
        public HtmlTable(IWebElement webElement) : base(webElement)
        {
            if (!string.Equals(webElement.TagName.ToLower(), "table"))
                throw new InvalidElementStateException("Table must have tag name is 'table' or 'th'.");
        }
        public IList<HtmlRow> GetRows()
        {
            var rows = _element.FindElements(By.TagName("tr"));
            return rows.Select(x => new HtmlRow(x)).ToList();
        }
        public HtmlRow GetRowAt(int index)
        {
            var rows = this.GetRows();
            return rows[index];
        }
        public IList<List<HtmlCell>> GetCells()
        {
            var rows = this.GetRows();
            IList<List<HtmlCell>> results = new List<List<HtmlCell>>();
            foreach(var row in rows)
            {
                results.Add(row.GetCells().ToList());
            }
            return results.ToList();
        }
        public HtmlCell GetCellAt(int rowIndex, int colIndex)
        {
            var cells = this.GetCells();
            return cells[rowIndex][colIndex];
        }
    }
}
