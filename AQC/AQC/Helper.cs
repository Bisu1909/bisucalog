using AQC.Interface;
using Microsoft.Practices.Unity;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AQC
{
    public class Helper : IHelper
    {
        public Helper(IWebDriver driver, IFindManager findManager, IWaitManager waitManager, ILog logger)
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
        private int intervalInmilliseconds = 200;
        public string GetAlertText(int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitAlertIsPresented(timeoutInmilliseconds);
            _logger.LogInfo(string.Format("Get text from Alert"));
            try
            {
                string text = _driver.SwitchTo().Alert().Text;
                _logger.LogInfo(string.Format("Text [{0}] get", text));
                return text;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public string GetText(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsVisibled(element, timeoutInmilliseconds);
            _logger.LogInfo(string.Format("Get text from element [{0}]", element));
            try
            {
                string text = element.Text;
                _logger.LogInfo(string.Format("Text [{0}] get", text));
                return text;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public string GetText(By by, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsVisibled(by, timeoutInmilliseconds);
            var element = _findManager.Find(by);
            _logger.LogInfo(string.Format("Get text from element [{0}]", by));
            try
            {
                string text = element.Text;
                _logger.LogInfo(string.Format("Text [{0}] get", text));
                return text;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public bool IsEnabled(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsVisibled(element, timeoutInmilliseconds);
            try
            {
                bool isEnabled = element.Enabled;
                string logMessage = (isEnabled) ? string.Format("Element [{0}] is enabled, return [True]", element) : string.Format("Element [{0}] is disabled, return [False]", element);
                _logger.LogInfo(logMessage);
                return isEnabled;
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }            
        }
        public bool IsEnabled(By by, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsVisibled(by, timeoutInmilliseconds);
            var element = _findManager.Find(by);
            try
            {
                bool isEnabled = element.Enabled;
                string logMessage = (isEnabled) ? string.Format("Element [{0}] is enabled, return [True]", by) : string.Format("Element [{0}] is disabled, return [False]", by);
                _logger.LogInfo(logMessage);
                return isEnabled;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public bool IsSelected(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsVisibled(element, timeoutInmilliseconds);
            try
            {
                bool isSelected = element.Selected;
                string logMessage = (isSelected) ? string.Format("Element [{0}] is selected, return [True]", element) : string.Format("Element [{0}] is un-selected, return [False]", element);
                _logger.LogInfo(logMessage);
                return isSelected;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public bool IsSelected(By by, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsVisibled(by, timeoutInmilliseconds);
            var element = _findManager.Find(by);
            try
            {
                bool isSelected = element.Selected;
                string logMessage = (isSelected) ? string.Format("Element [{0}] is selected, return [True]", by) : string.Format("Element [{0}] is un-selected, return [False]", by);
                _logger.LogInfo(logMessage);
                return isSelected;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;   
            }
        }
        public void Listener(IWebElement element)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    _logger.LogInfo(string.Format("Listener running, looking for element [{0}] for every [{1}]  milliseconds", element, intervalInmilliseconds));
                    while (_driver != null)
                    {                        
                        
                        try
                        {
                            element.Click();
                        }
                        catch (Exception)
                        {
                            //ignore Exception
                            Thread.Sleep(intervalInmilliseconds);
                        }
                    }
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void Listener(By by)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    _logger.LogInfo(string.Format("Listener running, looking for element(s) [{0}] for every [{1}]  milliseconds", by, intervalInmilliseconds));
                    while (_driver != null)
                    {
                        
                        try
                        {
                            foreach (var element in _findManager.Finds(by))
                            {
                                element.Click();
                            }
                        }
                        catch (Exception)
                        {
                            //ignore Exception
                            Thread.Sleep(intervalInmilliseconds);
                        }
                    }
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void TakeScreenshot()
        {
            var ScreenshotFilePath = Setting.ScreenshotFilePath;
            string fileName = DateTime.UtcNow.ToString("dd_MMM_yyyy_HH-mm-ss") + ".jpeg";
            _logger.LogInfo(string.Format("Take screenshot and saved in [{0}{1}]", ScreenshotFilePath, fileName));
            try
            {
                Directory.CreateDirectory(ScreenshotFilePath);
                Screenshot screenshot = _driver.TakeScreenshot();                
                screenshot.SaveAsFile(Path.Combine(ScreenshotFilePath, fileName), ScreenshotImageFormat.Jpeg);                
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }

        public bool IsVisibled(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(1000));
            wait.PollingInterval = TimeSpan.FromMilliseconds(intervalInmilliseconds);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(by));                
                _logger.LogInfo(string.Format("Element [{0}] is visibled, return [True]", by));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                _logger.LogInfo(string.Format("Element [{0}] is not visibled, return [False]", by));
                return false; 
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }

        }
    }
}
