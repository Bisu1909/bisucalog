using AQC.Interface;
using Microsoft.Practices.Unity;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AQC
{
    public class KeyboardManager : IKeyboardManager
    {
        private IWebDriver _driver;
        private IFindManager _findManager;
        private IWaitManager _waitManager;
        private ILog _logger;
        [Dependency]
        public ISetting Setting { get; set; }
        public KeyboardManager(IWebDriver driver, IFindManager findManager, IWaitManager waitManager, ILog logger)
        {
            _driver = driver;
            _findManager = findManager;
            _waitManager = waitManager;
            _logger = logger;
        }
        public void ClearAndTypeText(IWebElement element, string textToType, int? timeoutInmilliseconds = null)
        {
            ClearText(element, timeoutInmilliseconds);
            TypeText(element, textToType, timeoutInmilliseconds);
        }
        public void ClearAndTypeText(By by, string textToType, int? timeoutInmilliseconds = null)
        {
            ClearText(by, timeoutInmilliseconds);
            TypeText(by, textToType, timeoutInmilliseconds);
        }
        public void ClearAndTypeTextWithDelay(IWebElement element, string textToType, int delayInmilliseconds, int? timeoutInmilliseconds = null)
        {
            ClearText(element, timeoutInmilliseconds);
            TypeTextWithDelay(element, textToType, delayInmilliseconds, timeoutInmilliseconds);
        }
        public void ClearAndTypeTextWithDelay(By by, string textToType, int delayInmilliseconds, int? timeoutInmilliseconds = null)
        {
            ClearText(by, timeoutInmilliseconds);
            TypeTextWithDelay(by, textToType, delayInmilliseconds, timeoutInmilliseconds);
        }
        public void ClearText(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsClickabled(element, timeoutInmilliseconds);
            _logger.LogInfo(string.Format("Perform clear text on element [{0}]", element));
            try
            {
                element.Clear();
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }            
        }
        public void ClearText(By by, int? timeoutInmilliseconds = null)
        {            
            _waitManager.WaitElementIsClickabled(by, timeoutInmilliseconds);
            var element = _findManager.Find(by);
            _logger.LogInfo(string.Format("Perform clear text on element [{0}]", by));
            try
            {
                element.Clear();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void PressEnter(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsClickabled(element, timeoutInmilliseconds);
            _logger.LogInfo(string.Format("Perform press Enter on element [{0}]", element));
            try
            {
                element.SendKeys(Keys.Enter);
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void PressEnter(By by, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsClickabled(by, timeoutInmilliseconds);
            var element = _findManager.Find(by);
            _logger.LogInfo(string.Format("Perform press Enter on element [{0}]", by));
            try
            {
                element.SendKeys(Keys.Enter);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void TypeText(IWebElement element, string text, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsClickabled(element, timeoutInmilliseconds);
            _logger.LogInfo(string.Format("Perform type text [{0}] on element [{1}]", text, element));
            try
            {
                element.SendKeys(text);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void TypeText(By by, string text, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsClickabled(by, timeoutInmilliseconds);
            var driver = _driver;
            var element = _findManager.Find(by);
            _logger.LogInfo(string.Format("Perform type text [{0}] on element [{1}]", text, by));
            try
            {
                element.SendKeys(text);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void TypeTextWithDelay(IWebElement element, string text, int delayInmilliseconds, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsClickabled(element, timeoutInmilliseconds);
            _logger.LogInfo(string.Format("Perform type text [{0}] on element [{1}] with delay [{2}] milliseconds", text, element, delayInmilliseconds));
            try
            {
                foreach (var c in text)
                {
                    element.SendKeys(c.ToString());
                    Thread.Sleep(delayInmilliseconds);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void TypeTextWithDelay(By by, string text, int delayInmilliseconds, int? timeoutInmilliseconds = null)
        {            
            _waitManager.WaitElementIsClickabled(by, timeoutInmilliseconds);
            var element = _findManager.Find(by);
            _logger.LogInfo(string.Format("Perform type text [{0}] on element [{1}] with delay [{2}] milliseconds", text, by, delayInmilliseconds));
            try
            {
                foreach (var c in text)
                {
                    element.SendKeys(c.ToString());
                    Thread.Sleep(delayInmilliseconds);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
    }
}
