using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Interface
{
    public interface IMouseManager
    {
        void Click(IWebElement element, int? timeoutInmilliseconds = null);
        void Click(By by, int? timeoutInmilliseconds = null);
        void RightClick(IWebElement element, int? timeoutInmilliseconds = null);
        void RightClick(By by, int? timeoutInmilliseconds = null);
        void DoubleClick(IWebElement element, int? timeoutInmilliseconds = null);
        void DoubleClick(By by, int? timeoutInmilliseconds = null);
        void Submit(IWebElement element, int? timeoutInmilliseconds = null);
        void Submit(By by, int? timeoutInmilliseconds = null);
        void SelectComboItem(IWebElement element, string presentText, int? timeoutInmilliseconds = null);
        void SelectComboItem(By by, string presentText, int? timeoutInmilliseconds = null);
        void DragAndDrop(IWebElement from, IWebElement to, int? timeoutInmilliseconds = null);
        void DragAndDrop(By from, IWebElement to, int? timeoutInmilliseconds = null);
        void DragAndDrop(IWebElement from, By to, int? timeoutInmilliseconds = null);
        void DragAndDrop(By from, By to, int? timeoutInmilliseconds = null);
        void ClickHoldAndDrop(IWebElement from, IWebElement to, int? timeoutInmilliseconds = null);
        void ClickHoldAndDrop(By from, IWebElement to, int? timeoutInmilliseconds = null);
        void ClickHoldAndDrop(IWebElement from, By to, int? timeoutInmilliseconds = null);
        void ClickHoldAndDrop(By from, By to, int? timeoutInmilliseconds = null);
        void MoveMouseToElement(IWebElement element, int? timeoutInmilliseconds = null);
        void MoveMouseToElement(By by, int? timeoutInmilliseconds = null);
    }
}
