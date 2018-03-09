using AQC.Interface;
using Microsoft.Practices.Unity;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;


namespace AQC
{
    public class WaitManager : IWaitManager
    {
        private ILog _logger;
        private IFindManager _findManager;
        private IWebDriver _driver;
        private int intervalInmilliseconds = 200;
        [Dependency]
        public ISetting Setting { get; set; }
        public WaitManager(IWebDriver driver, IFindManager findManager, ILog logger)
        {
            _driver = driver;
            _findManager = findManager;
            _logger = logger;
        }
        public void Wait(int timeoutInmilliseconds)
        {
            _logger.LogInfo(string.Format("Waiting for [{0}] milliseconds ...",timeoutInmilliseconds));
            Thread.Sleep(timeoutInmilliseconds);
        }
        public void WaitElementIsClickabled(IWebElement element, int? timeoutInmilliseconds = null)
        {
            var waitTime = timeoutInmilliseconds ?? Setting.ImplicitWaitInmilliseconds;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(waitTime));
            wait.PollingInterval = TimeSpan.FromMilliseconds(intervalInmilliseconds);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), 
                                      typeof(ElementNotVisibleException),
                                      typeof(StaleElementReferenceException));
            _logger.LogInfo(string.Format("Waiting element [{0}] to be clickabled for [{1}] milliseconds ...", element, waitTime));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void WaitElementIsClickabled(By by, int? timeoutInmilliseconds = null)
        {
            var waitTime = timeoutInmilliseconds ?? Setting.ImplicitWaitInmilliseconds;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(waitTime));
            wait.PollingInterval = TimeSpan.FromMilliseconds(intervalInmilliseconds);
            wait.IgnoreExceptionTypes(typeof(Exception));
            _logger.LogInfo(string.Format("Waiting element [{0}] to be clickabled for [{1}] milliseconds ...", by, waitTime));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(by));

            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        /// <summary>
        /// Review
        /// </summary>
        /// <param name="element"></param>
        /// <param name="timeoutInmilliseconds"></param>
        public void WaitElementIsInvisibled(IWebElement element, int? timeoutInmilliseconds = null)
        {
            WaitElementIsVisibled(element, timeoutInmilliseconds);
            var waitTime = timeoutInmilliseconds ?? Setting.ImplicitWaitInmilliseconds;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(waitTime));
            wait.PollingInterval = TimeSpan.FromMilliseconds(intervalInmilliseconds);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            _logger.LogInfo(string.Format("Waiting element [{0}] to be invisibled for [{1}] milliseconds ...", element, waitTime));
            try
            {
                wait.Until(_driver => !(element.Displayed));
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void WaitElementIsInvisibled(By by, int? timeoutInmilliseconds = null)
        {
            WaitElementIsVisibled(by, timeoutInmilliseconds);
            var waitTime = timeoutInmilliseconds ?? Setting.ImplicitWaitInmilliseconds;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(waitTime));
            wait.PollingInterval = TimeSpan.FromMilliseconds(intervalInmilliseconds);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            _logger.LogInfo(string.Format("Waiting element [{0}] to be invisibled for [{1}] milliseconds ...", by, waitTime));
            try
            {
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        /// <summary>
        /// Review
        /// </summary>
        /// <param name="element"></param>
        /// <param name="timeoutInmilliseconds"></param>
        public void WaitElementIsVisibled(IWebElement element, int? timeoutInmilliseconds = null)
        {            
            var waitTime = timeoutInmilliseconds ?? Setting.ImplicitWaitInmilliseconds;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(waitTime));
            wait.PollingInterval = TimeSpan.FromMilliseconds(intervalInmilliseconds);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            _logger.LogInfo(string.Format("Waiting element [{0}] to be visibled for [{1}] milliseconds ...", element, waitTime));
            try
            {
                wait.Until(_driver => element.Displayed);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void WaitElementIsVisibled(By by, int? timeoutInmilliseconds = null)
        {
            var waitTime = timeoutInmilliseconds ?? Setting.ImplicitWaitInmilliseconds;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(waitTime));
            wait.PollingInterval = TimeSpan.FromMilliseconds(intervalInmilliseconds);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            _logger.LogInfo(string.Format("Waiting element [{0}] to be visibled for [{1}] milliseconds ...", by, waitTime));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void WaitPageLoadReady(int? timeoutInmilliseconds = null)
        {            
            var waitTime = timeoutInmilliseconds ?? Setting.ImplicitWaitInmilliseconds;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(waitTime));
            wait.PollingInterval = TimeSpan.FromMilliseconds(intervalInmilliseconds);
            wait.IgnoreExceptionTypes(typeof(Exception));
            _logger.LogInfo(string.Format("Waiting page load ready for [{0}] milliseconds ...", waitTime));
            bool IsJqueryDefined = (bool)((IJavaScriptExecutor)_driver).ExecuteScript("return (!!window.jQuery)");
            if (IsJqueryDefined)
            {
                try
                {
                    wait.Until(_driver =>
                    {
                        bool isAjaxAndJsFinished = (bool)((IJavaScriptExecutor)_driver).
                            ExecuteScript("return (document.readyState == 'complete' && jQuery.active == 0)");
                    return isAjaxAndJsFinished;
                    });
                }
                catch (Exception e)
                {
                    _logger.LogError(e.ToString());
                    throw;
                }
            }
            else
            {
                _logger.LogWarning("Jquery not found! Ignoring WaitPageLoadReady method ... Please switch to default content and retry");
            }
        }
        public void WaitAlertIsPresented(int? timeoutInmilliseconds = null)
        {
            var waitTime = timeoutInmilliseconds ?? Setting.ImplicitWaitInmilliseconds;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(waitTime));
            wait.PollingInterval = TimeSpan.FromMilliseconds(intervalInmilliseconds);
            _logger.LogInfo(string.Format("Waiting Alert to be presented for [{0}] milliseconds ...", waitTime));
            try
            {
                wait.Until(ExpectedConditions.AlertIsPresent());
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
    }
}
