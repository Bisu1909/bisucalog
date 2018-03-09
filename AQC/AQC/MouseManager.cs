using AQC.Interface;
using Microsoft.Practices.Unity;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AQC
{
    public class MouseManager : IMouseManager
    {
        public MouseManager(IWebDriver driver, IFindManager findManager, IWaitManager waitManager, ILog logger)
        {
            _driver = driver;
            _findManager = findManager;
            _waitManager = waitManager;
            _logger = logger;
        }
        [Dependency]
        public ISetting Setting { get; set; }
        private IWebDriver _driver;
        private IFindManager _findManager;
        private IWaitManager _waitManager;
        private ILog _logger;
        
        public void Click(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsClickabled(element, timeoutInmilliseconds);
            _logger.LogInfo(string.Format("Perform Click on element [{0}]", element));
            try
            {
                element.Click();
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }            
        }
        public void TryClick(By by)
        {
            _findManager.Find(by).Click();
        }
        public void Click(By by, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsClickabled(by, timeoutInmilliseconds);
            var waitTime = timeoutInmilliseconds ?? Setting.ImplicitWaitInmilliseconds;
            _logger.LogInfo(string.Format("Perform Click on element [{0}]", by));
            int count = 0;
            while (true)
            {
                try
                {
                    _findManager.Find(by).Click();
                    break;
                }
                catch (Exception e)
                {
                    if((e is InvalidOperationException || e is StaleElementReferenceException) && (count <= waitTime))
                    {
                        Thread.Sleep(200);
                        count = count + 200;                        
                    }
                    else
                    {
                        _logger.LogError(e.ToString());
                        throw;
                    }                    
                }
            }    
        }
        public void ClickHoldAndDrop(IWebElement from, IWebElement to, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsClickabled(from, timeoutInmilliseconds);
            _waitManager.WaitElementIsClickabled(to, timeoutInmilliseconds);
            var action = new Actions(_driver);
            _logger.LogInfo(string.Format("Perform Click-Hold on element [{0}] and drop it on element [{1}]", from, to));
            try
            {
                action.ClickAndHold(from).MoveToElement(to).Release().Build().Perform();
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void ClickHoldAndDrop(By from, IWebElement to, int? timeoutInmilliseconds = null)
        {            
            _waitManager.WaitElementIsClickabled(from, timeoutInmilliseconds);
            _waitManager.WaitElementIsClickabled(to, timeoutInmilliseconds);
            var fromElement = _findManager.Find(from);
            var action = new Actions(_driver);
            _logger.LogInfo(string.Format("Perform Click-Hold on element [{0}] and drop it on element [{1}]", from, to));
            try
            {
                action.ClickAndHold(fromElement).MoveToElement(to).Release().Build().Perform();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void ClickHoldAndDrop(IWebElement from, By to, int? timeoutInmilliseconds = null)
        {            
            _waitManager.WaitElementIsClickabled(from, timeoutInmilliseconds);
            _waitManager.WaitElementIsClickabled(to, timeoutInmilliseconds);
            var toElement = _findManager.Find(to);
            var action = new Actions(_driver);
            _logger.LogInfo(string.Format("Perform Click-Hold on element [{0}] and drop it on element [{1}]", from, to));
            try
            {
                action.ClickAndHold(from).MoveToElement(toElement).Release().Build().Perform();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void ClickHoldAndDrop(By from, By to, int? timeoutInmilliseconds = null)
        {            
            _waitManager.WaitElementIsClickabled(from, timeoutInmilliseconds);
            _waitManager.WaitElementIsClickabled(to, timeoutInmilliseconds);
            var fromElement = _findManager.Find(from);
            var toElement = _findManager.Find(to);
            var action = new Actions(_driver);
            _logger.LogInfo(string.Format("Perform Click-Hold on element [{0}] and drop it on element [{1}]", from, to));
            try
            {
                action.ClickAndHold(fromElement).MoveToElement(toElement).Release().Build().Perform();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void DoubleClick(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsClickabled(element, timeoutInmilliseconds);
            var action = new Actions(_driver);
            _logger.LogInfo(string.Format("Perform Double Click on element [{0}]", element));
            try
            {
                action.DoubleClick(element).Build().Perform();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void DoubleClick(By by, int? timeoutInmilliseconds = null)
        {            
            _waitManager.WaitElementIsClickabled(by, timeoutInmilliseconds);
            var element = _findManager.Find(by);
            var action = new Actions(_driver);
            _logger.LogInfo(string.Format("Perform Double Click on element [{0}]", by));
            try
            {
                action.DoubleClick(element).Build().Perform();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void DragAndDrop(IWebElement from, IWebElement to, int? timeoutInmilliseconds = null)
        {

            _waitManager.WaitElementIsClickabled(from, timeoutInmilliseconds);
            _waitManager.WaitElementIsClickabled(to, timeoutInmilliseconds);
            var action = new Actions(_driver);
            _logger.LogInfo(string.Format("Perform drag and Drop element [{0}] to element [{1}]", from, to));
            try
            {
                action.DragAndDrop(from, to).Build().Perform();
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void DragAndDrop(By from, IWebElement to, int? timeoutInmilliseconds = null)
        {            
            _waitManager.WaitElementIsClickabled(from, timeoutInmilliseconds);
            _waitManager.WaitElementIsClickabled(to, timeoutInmilliseconds);
            var fromElement = _findManager.Find(from);
            var action = new Actions(_driver);
            _logger.LogInfo(string.Format("Perform drag and Drop element [{0}] to element [{1}]", from, to));
            try
            {
                action.DragAndDrop(fromElement, to).Build().Perform();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void DragAndDrop(IWebElement from, By to, int? timeoutInmilliseconds = null)
        {            
            _waitManager.WaitElementIsClickabled(from, timeoutInmilliseconds);
            _waitManager.WaitElementIsClickabled(to, timeoutInmilliseconds);
            var toElement = _findManager.Find(to);
            var action = new Actions(_driver);
            _logger.LogInfo(string.Format("Perform drag and Drop element [{0}] to element [{1}]", from, to));
            try
            {
                action.DragAndDrop(from, toElement).Build().Perform();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void DragAndDrop(By from, By to, int? timeoutInmilliseconds = null)
        {            
            _waitManager.WaitElementIsClickabled(from, timeoutInmilliseconds);
            _waitManager.WaitElementIsClickabled(to, timeoutInmilliseconds);
            var fromElement = _findManager.Find(from);
            var toElement = _findManager.Find(to);
            var action = new Actions(_driver);
            _logger.LogInfo(string.Format("Perform drag and Drop element [{0}] to element [{1}]", from, to));
            try
            {
                action.DragAndDrop(fromElement, toElement).Build().Perform();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void MoveMouseToElement(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsVisibled(element, timeoutInmilliseconds);
            var action = new Actions(_driver);
            _logger.LogInfo(string.Format("Perform move mouse to element [{0}] ", element));
            try
            {
                action.MoveToElement(element);
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void MoveMouseToElement(By by, int? timeoutInmilliseconds = null)
        {            
            _waitManager.WaitElementIsVisibled(by, timeoutInmilliseconds);
            var element = _findManager.Find(by);
            var action = new Actions(_driver);
            _logger.LogInfo(string.Format("Perform move mouse to element [{0}] ", by));
            try
            {
                action.MoveToElement(element);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void RightClick(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsClickabled(element, timeoutInmilliseconds);
            var action = new Actions(_driver);
            _logger.LogInfo(string.Format("Perform right-click on element [{0}] ", element));
            try
            {
                action.ContextClick(element);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void RightClick(By by, int? timeoutInmilliseconds = null)
        {            
            _waitManager.WaitElementIsClickabled(by, timeoutInmilliseconds);
            var element = _findManager.Find(by);
            var action = new Actions(_driver);
            _logger.LogInfo(string.Format("Perform right-click on element [{0}] ", by));
            try
            {
                action.ContextClick(element);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void SelectComboItem(IWebElement element, string presentText, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsClickabled(element, timeoutInmilliseconds);
            var selectElement = new SelectElement(element);
            _logger.LogInfo(string.Format("Perform select item with text [{0}] on element [{1}] ", presentText, element));
            try
            {                
                selectElement.SelectByText(presentText);
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }            
        }
        public void SelectComboItem(By by, string presentText, int? timeoutInmilliseconds = null)
        {            
            _waitManager.WaitElementIsClickabled(by, timeoutInmilliseconds);
            var element = _findManager.Find(by);
            var selectElement = new SelectElement(element);
            _logger.LogInfo(string.Format("Perform select item with text [{0}] on element [{1}] ", presentText, by));
            try
            {
                selectElement.SelectByText(presentText);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void Submit(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsClickabled(element, timeoutInmilliseconds);
            _logger.LogInfo(string.Format("Perform submit on element [{0}] ", element));
            try
            {
                element.Submit();
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void Submit(By by, int? timeoutInmilliseconds = null)
        {            
            _waitManager.WaitElementIsClickabled(by, timeoutInmilliseconds);
            var element = _findManager.Find(by);
            _logger.LogInfo(string.Format("Perform submit on element [{0}] ", by));
            try
            {
                element.Submit();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
    }
}
