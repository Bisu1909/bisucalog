using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Interface
{
    public interface IKeyboardManager
    {
        void ClearText(IWebElement element, int? timeoutInmilliseconds = null);
        void ClearText(By by, int? timeoutInmilliseconds = null);
        void TypeText(IWebElement element, string textToType, int? timeoutInmilliseconds = null);
        void TypeText(By by, string text, int? timeoutInmilliseconds = null);
        void TypeTextWithDelay(IWebElement element, string textToType, int delayInmilliseconds, int? timeoutInmilliseconds = null);
        void TypeTextWithDelay(By by, string textToType, int delayInmilliseconds, int? timeoutInmilliseconds = null);
        void ClearAndTypeText(IWebElement element, string textToType, int? timeoutInmilliseconds = null);
        void ClearAndTypeText(By by, string textToType, int? timeoutInmilliseconds = null);
        void ClearAndTypeTextWithDelay(IWebElement element, string textToType, int delayInmilliseconds, int? timeoutInmilliseconds = null);
        void ClearAndTypeTextWithDelay(By by, string textToType, int delayInmilliseconds, int? timeoutInmilliseconds = null);
        void PressEnter(IWebElement element, int? timeoutInmilliseconds = null);
        void PressEnter(By by, int? timeoutInmilliseconds = null);
    }
}
