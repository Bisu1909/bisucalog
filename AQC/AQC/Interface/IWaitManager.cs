using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Interface
{
    public interface IWaitManager
    {
        void WaitElementIsVisibled(IWebElement element, int? timeoutInmilliseconds = null);
        void WaitElementIsVisibled(By by, int? timeoutInmilliseconds = null);
        void WaitElementIsClickabled(IWebElement element, int? timeoutInmilliseconds = null);
        void WaitElementIsClickabled(By by, int? timeoutInmilliseconds = null);
        void WaitElementIsInvisibled(IWebElement element, int? timeoutInmilliseconds = null);
        void WaitElementIsInvisibled(By by, int? timeoutInmilliseconds = null);
        void Wait(int timeoutInMiniSeconds);
        void WaitPageLoadReady(int? timeoutInmilliseconds = null);
        void WaitAlertIsPresented(int? timeoutInmilliseconds = null);
    }
}
