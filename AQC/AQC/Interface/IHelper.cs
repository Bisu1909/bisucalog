using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Interface
{
    public interface IHelper
    {
        void Listener(IWebElement element);
        void Listener(By by);
        void TakeScreenshot();
        string GetText(IWebElement element, int? timeoutInmilliseconds = null);
        string GetText(By by, int? timeoutInmilliseconds = null);       
        string GetAlertText(int? timeoutInmilliseconds = null);
        bool IsSelected(IWebElement element, int? timeoutInmilliseconds = null);
        bool IsSelected(By by, int? timeoutInmilliseconds = null);
        bool IsEnabled(IWebElement element, int? timeoutInmilliseconds = null);
        bool IsEnabled(By by, int? timeoutInmilliseconds = null);
        bool IsVisibled(By by);
    }
}
