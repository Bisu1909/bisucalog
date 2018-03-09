using AQC.Interface;
using Microsoft.Practices.Unity;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC
{
    public class NavigationManager : INavigationManager
    {
        public NavigationManager(IWebDriver driver, IFindManager findManager,IWaitManager waitManager, ILog logger)
        {
            _driver = driver;
            _logger = logger;
            _findManager = findManager;
            _waitManager = waitManager;
        }
        [Dependency]
        public ISetting Setting { get; set; }
        private IWebDriver _driver;
        private ILog _logger;
        private IFindManager _findManager;
        private IWaitManager _waitManager;
        public void AcceptAlert(int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitAlertIsPresented(timeoutInmilliseconds);
            _logger.LogInfo("Accept Browser Alert");
            try
            {                
                _driver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void DismissAlert(int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitAlertIsPresented(timeoutInmilliseconds);
            _logger.LogInfo("Dismiss Browser Alert");
            try
            {
                _driver.SwitchTo().Alert().Dismiss();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void GoBackward(int? timeoutInmilliseconds = null)
        {
            _logger.LogInfo("Browser - go backward");
            _driver.Navigate().Back();
            _waitManager.WaitPageLoadReady(timeoutInmilliseconds);
        }
        public void GoForward(int? timeoutInmilliseconds = null)
        {
            _logger.LogInfo("Browser - go forward");
            _driver.Navigate().Forward();
            _waitManager.WaitPageLoadReady(timeoutInmilliseconds);
        }
        public void MaximizeBrowser()
        {
            _logger.LogInfo("Maximize Browser window");
            _driver.Manage().Window.Maximize();
        }
        public void RefreshPage(int? timeoutInmilliseconds = null)
        {
            _logger.LogInfo("Refresh Browser...");
            _driver.Navigate().Refresh();
            _waitManager.WaitPageLoadReady(timeoutInmilliseconds);
        }
        public void ScrollDown(int nPixcels, int? timeoutInmilliseconds = null)
        {
            _logger.LogInfo(string.Format("Scroll page down by [{0}] pixcels,",nPixcels));
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("window.scrollBy(0,arguments[0])", nPixcels);
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void ScrollLeft(int nPixcels, int? timeoutInmilliseconds = null)
        {
            _logger.LogInfo(string.Format("Scroll page left by [{0}] pixcels,", nPixcels));
            var negNPixcels = nPixcels * -1;
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("window.scrollBy(arguments[0], 0)", negNPixcels);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void ScrollRight(int nPixcels, int? timeoutInmilliseconds = null)
        {
            _logger.LogInfo(string.Format("Scroll page right by [{0}] pixcels,", nPixcels));
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("window.scrollBy(arguments[0], 0)", nPixcels);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void ScrollToBottom(int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitPageLoadReady(timeoutInmilliseconds);
            _logger.LogInfo(string.Format("Scroll page to bottom"));
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void ScrollToElement(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitPageLoadReady(timeoutInmilliseconds);
            _waitManager.WaitElementIsVisibled(element,timeoutInmilliseconds);
            _logger.LogInfo(string.Format("Scroll page to element [{0}]", element));
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("arguments[0].scrollIntoView();", element);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void ScrollToElement(By by, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitPageLoadReady(timeoutInmilliseconds);
            _waitManager.WaitElementIsVisibled(by, timeoutInmilliseconds);
            var element = _findManager.Find(by);
            _logger.LogInfo(string.Format("Scroll page to element [{0}]", by));
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("arguments[0].scrollIntoView();", element);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void ScrollToTop(int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitPageLoadReady(timeoutInmilliseconds);
            _logger.LogInfo(string.Format("Scroll page to top"));
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("window.scrollTo(0, 0)");
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void ScrollUp(int nPixcels, int? timeoutInmilliseconds = null)
        {
            _logger.LogInfo(string.Format("Scroll page up by [{0}] pixcels,", nPixcels));
            var negNPixcels = nPixcels * -1;
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("window.scrollBy(0,arguments[0])", negNPixcels);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void SwitchToTab(int tabIndex)
        {
            var windows = _driver.WindowHandles;
            _logger.LogInfo(string.Format("Switch to browser Tab with index [{0}]", tabIndex));
            try
            {
                _driver.SwitchTo().Window(windows[tabIndex]);
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }            
        }
        public void ScrollTo(int xPixcel, int yPixcel, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitPageLoadReady(timeoutInmilliseconds);
            _logger.LogInfo(string.Format("Scroll page to location (x = [{0}] and y = [{1}])", xPixcel, yPixcel));
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("window.scrollTo(arguments[0], arguments[1])", yPixcel, xPixcel);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void SwitchToFrame(int frameIndex, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitPageLoadReady(timeoutInmilliseconds);
            _logger.LogInfo(string.Format("Switch to Frame with index [{0}]", frameIndex));
            try
            {
                _driver.SwitchTo().Frame(frameIndex);
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
        public void SwitchToDefaultFrame(int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitPageLoadReady(timeoutInmilliseconds);
            _logger.LogInfo(string.Format("Switch to default Frame"));
            try
            {
                _driver.SwitchTo().DefaultContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
    }
}
