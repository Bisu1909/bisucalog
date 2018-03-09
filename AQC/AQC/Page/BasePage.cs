using Microsoft.Practices.Unity;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AQC.Interface;
using AQC.Unity;
using System.Data;

namespace AQC.Page
{
    public abstract class BasePage : IPage
    {
        public BasePage(IFixture fixture)
        {
            _logger = fixture.GetLogger();
            _refFixture = fixture;
            _findManager = fixture.GetFindManager();
            _waitManager = fixture.GetWaitManager();
            _mouseManager = fixture.GetMouseManager();
            _keyboardManager = fixture.GetKeyboardManager();
            _navigationManager = fixture.GetNavigationManager();
            _helper = fixture.GetHelper();
            Setting = fixture.GetSetting();
            Driver = fixture.GetDriver();
            DbConnectionFactory = fixture.GetDbConnectionManager();
        }

        private IFindManager _findManager;
        private IWaitManager _waitManager;
        private IMouseManager _mouseManager;
        private IKeyboardManager _keyboardManager;
        private INavigationManager _navigationManager;
        private IHelper _helper;
        private IFixture _refFixture;
        private ILog _logger;

        #region #region Inherit hierarchical
        protected IWebDriver Driver { get; set; }
        protected ISetting Setting { get; set; }
        protected IDbConnectionManager DbConnectionFactory { get; set; }
        #endregion
        public abstract string PageUrl { get; }
        public virtual bool IsAt()
        {
            return BroswerUrl.StartsWith(PageUrl, StringComparison.InvariantCultureIgnoreCase);
        }

        public T As<T>() where T : IPage
        {
            if (this is T page)
            {
                if (page.IsAt()) return page;
            }
            else
            {
                var nextPage = UnityConfig.GetUnityContainer().Resolve<T>(new ParameterOverride("fixture", _refFixture));
                if (nextPage.IsAt())
                {
                    (_refFixture as IFixture).SetPage(nextPage);
                    return nextPage;
                }
            }
            throw new InvalidPageException("As method: can not swith to your page cause the view in broswer is not valid.");
        }
        public void GoTo(string url)
        {
            LogInfo(string.Format("Go to url: {0}", url));
            Driver.Navigate().GoToUrl(url);
            MaximizeBrowser();
        }
        public IPage GoTo<T>() where T : IPage
        {

            if (this is T /*&& this.IsAt()*/) return this;
            var page = UnityConfig.GetUnityContainer().Resolve<T>(new ParameterOverride("fixture", _refFixture));
            _refFixture.SetPage(page);
            return page.GoTo<T>(page.PageUrl);
        }
        public IPage GoTo<T>(string url) where T : IPage
        {
            this.GoTo(url);
            if (this is T /*&& this.IsAt()*/) return this;
            var page = UnityConfig.GetUnityContainer().Resolve<T>(new ParameterOverride("fixture", _refFixture));
            //if (page.IsAt())
            //{
            _refFixture.SetPage(page);
            return page;
            //}
            //throw new InvalidPageException("GoTo method: can not swith to your page cause the view in broswer is not valid.");
        }
        public string BroswerUrl
        {
            get
            {
                return Driver.Url;
            }
        }
        
        #region Find
        protected IWebElement Find(By by)
        {
            return _findManager.Find(by);
        }
        protected List<IWebElement> Finds(By by)
        {
            return _findManager.Finds(by);
        }
        protected IWebElement Find(By parent, By by)
        {
            return _findManager.Find(parent, by);
        }
        protected List<IWebElement> Finds(By parent, By by)
        {
            return _findManager.Finds(parent, by);
        }
        protected IWebElement Find(IWebElement parent, By by)
        {
            return _findManager.Find(parent, by);
        }
        protected List<IWebElement> Finds(IWebElement parent, By by)
        {
            return _findManager.Finds(parent, by);
        }
        #endregion

        #region Mouse Actions
        protected void Click(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _mouseManager.Click(element, timeoutInmilliseconds);
        }
        protected void Click(By by, int? timeoutInmilliseconds = null)
        {
            _mouseManager.Click(by, timeoutInmilliseconds);
        }
        protected void RightClick(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _mouseManager.RightClick(element, timeoutInmilliseconds);
        }
        protected void RightClick(By by, int? timeoutInmilliseconds = null)
        {
            _mouseManager.RightClick(by, timeoutInmilliseconds);
        }
        protected void DoubleClick(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _mouseManager.DoubleClick(element, timeoutInmilliseconds);
        }
        protected void DoubleClick(By by, int? timeoutInmilliseconds = null)
        {
            _mouseManager.DoubleClick(by, timeoutInmilliseconds);
        }
        protected void Submit(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _mouseManager.Submit(element, timeoutInmilliseconds);
        }
        protected void Submit(By by, int? timeoutInmilliseconds = null)
        {
            _mouseManager.Submit(by, timeoutInmilliseconds);
        }
        protected void SelectComboItem(IWebElement element, string presentText, int? timeoutInmilliseconds = null)
        {
            _mouseManager.SelectComboItem(element, presentText, timeoutInmilliseconds);
        }
        protected void SelectComboItem(By by, string presentText, int? timeoutInmilliseconds = null)
        {
            _mouseManager.SelectComboItem(by, presentText, timeoutInmilliseconds);
        }
        protected void DragAndDrop(IWebElement from, IWebElement to, int? timeoutInmilliseconds = null)
        {
            _mouseManager.DragAndDrop(from, to, timeoutInmilliseconds);
        }
        protected void DragAndDrop(By from, IWebElement to, int? timeoutInmilliseconds = null)
        {
            _mouseManager.DragAndDrop(from, to, timeoutInmilliseconds);
        }
        protected void DragAndDrop(IWebElement from, By to, int? timeoutInmilliseconds = null)
        {
            _mouseManager.DragAndDrop(from, to, timeoutInmilliseconds);
        }
        protected void DragAndDrop(By from, By to, int? timeoutInmilliseconds = null)
        {
            _mouseManager.DragAndDrop(from, to, timeoutInmilliseconds);
        }
        protected void ClickHoldAndDrop(IWebElement from, IWebElement to, int? timeoutInmilliseconds = null)
        {
            _mouseManager.ClickHoldAndDrop(from, to, timeoutInmilliseconds);
        }
        protected void ClickHoldAndDrop(By from, IWebElement to, int? timeoutInmilliseconds = null)
        {
            _mouseManager.ClickHoldAndDrop(from, to, timeoutInmilliseconds);
        }
        protected void ClickHoldAndDrop(IWebElement from, By to, int? timeoutInmilliseconds = null)
        {
            _mouseManager.ClickHoldAndDrop(from, to, timeoutInmilliseconds);
        }
        protected void ClickHoldAndDrop(By from, By to, int? timeoutInmilliseconds = null)
        {
            _mouseManager.ClickHoldAndDrop(from, to, timeoutInmilliseconds);
        }
        protected void MoveMouseToElement(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _mouseManager.MoveMouseToElement(element, timeoutInmilliseconds);
        }
        protected void MoveMouseToElement(By by, int? timeoutInmilliseconds = null)
        {
            _mouseManager.MoveMouseToElement(by, timeoutInmilliseconds);
        }
        #endregion

        #region Keyboard Action
        protected void ClearText(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _keyboardManager.ClearText(element, timeoutInmilliseconds);
        }
        protected void ClearText(By by, int? timeoutInmilliseconds = null)
        {
            _keyboardManager.ClearText(by, timeoutInmilliseconds);
        }
        protected void TypeText(IWebElement element, string textToType, int? timeoutInmilliseconds = null)
        {
            _keyboardManager.TypeText(element, textToType, timeoutInmilliseconds);
        }
        protected void TypeText(By by, string textToType, int? timeoutInmilliseconds = null)
        {
            _keyboardManager.TypeText(by, textToType, timeoutInmilliseconds);
        }
        protected void TypeTextWithDelay(IWebElement element, string textToType, int delayInmilliseconds, int? timeoutInmilliseconds = null)
        {
            _keyboardManager.TypeTextWithDelay(element, textToType, delayInmilliseconds, timeoutInmilliseconds);
        }
        protected void TypeTextWithDelay(By by, string textToType, int delayInmilliseconds, int? timeoutInmilliseconds = null)
        {
            _keyboardManager.TypeTextWithDelay(by, textToType, delayInmilliseconds, timeoutInmilliseconds);
        }
        protected void ClearAndTypeText(IWebElement element, string textToType, int? timeoutInmilliseconds = null)
        {
            _keyboardManager.ClearAndTypeText(element, textToType, timeoutInmilliseconds);
        }
        protected void ClearAndTypeText(By by, string textToType, int? timeoutInmilliseconds = null)
        {
            _keyboardManager.ClearAndTypeText(by, textToType, timeoutInmilliseconds);
        }
        protected void ClearAndTypeTextWithDelay(IWebElement element, string textToType, int delayInmilliseconds, int? timeoutInmilliseconds = null)
        {
            _keyboardManager.ClearAndTypeTextWithDelay(element, textToType, delayInmilliseconds, timeoutInmilliseconds);
        }
        protected void ClearAndTypeTextWithDelay(By by, string textToType, int delayInmilliseconds, int? timeoutInmilliseconds = null)
        {
            _keyboardManager.ClearAndTypeTextWithDelay(by, textToType, delayInmilliseconds, timeoutInmilliseconds);
        }
        protected void PressEnter(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _keyboardManager.PressEnter(element, timeoutInmilliseconds);
        }
        protected void PressEnter(By by, int? timeoutInmilliseconds = null)
        {
            _keyboardManager.PressEnter(by, timeoutInmilliseconds);
        }
        #endregion

        #region Navigation
        protected void SwitchToTab(int tabIndex)
        {
            _navigationManager.SwitchToTab(tabIndex);
        }
        protected void MaximizeBrowser()
        {
            _navigationManager.MaximizeBrowser();
        }
        protected void RefreshPage(int? timeoutInmilliseconds = null)
        {
            _navigationManager.RefreshPage(timeoutInmilliseconds);
        }
        protected void GoForward(int? timeoutInmilliseconds = null)
        {
            _navigationManager.GoForward(timeoutInmilliseconds);
        }
        protected void GoBackward(int? timeoutInmilliseconds = null)
        {
            _navigationManager.GoBackward(timeoutInmilliseconds);
        }
        protected void AcceptAlert(int? timeoutInmilliseconds = null)
        {
            _navigationManager.AcceptAlert(timeoutInmilliseconds);
        }
        protected void DismissAlert(int? timeoutInmilliseconds = null)
        {
            _navigationManager.DismissAlert(timeoutInmilliseconds);
        }
        protected void ScrollToElement(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _navigationManager.ScrollToElement(element, timeoutInmilliseconds);
        }
        protected void ScrollToElement(By by, int? timeoutInmilliseconds = null)
        {
            _navigationManager.ScrollToElement(by, timeoutInmilliseconds);
        }
        protected void ScrollDown(int nPixcels, int? timeoutInmilliseconds = null)
        {
            _navigationManager.ScrollDown(nPixcels, timeoutInmilliseconds);
        }
        protected void ScrollUp(int nPixcels, int? timeoutInmilliseconds = null)
        {
            _navigationManager.ScrollUp(nPixcels, timeoutInmilliseconds);
        }
        protected void ScrollLeft(int nPixcels, int? timeoutInmilliseconds = null)
        {
            _navigationManager.ScrollLeft(nPixcels, timeoutInmilliseconds);
        }
        protected void ScrollRight(int nPixcels, int? timeoutInmilliseconds = null)
        {
            _navigationManager.ScrollRight(nPixcels, timeoutInmilliseconds);
        }
        protected void ScrollToTop(int? timeoutInmilliseconds = null)
        {
            _navigationManager.ScrollToTop(timeoutInmilliseconds);
        }
        protected void ScrollToBottom(int? timeoutInmilliseconds = null)
        {
            _navigationManager.ScrollToBottom(timeoutInmilliseconds);
        }
        protected void ScrollTo(int xPixcel, int yPixcel, int? timeoutInmilliseconds = null)
        {
            _navigationManager.ScrollTo(xPixcel, yPixcel, timeoutInmilliseconds);
        }
        protected void SwitchToFrame(int frameIndex, int? timeoutInmilliseconds = null)
        {
            _navigationManager.SwitchToFrame(frameIndex, timeoutInmilliseconds);
        }
        protected void SwitchToDefaultFrame(int? timeoutInmilliseconds = null)
        {
            _navigationManager.SwitchToDefaultFrame(timeoutInmilliseconds);
        }
        #endregion

        #region Helper
        protected void Listener(IWebElement element)
        {
            _helper.Listener(element);
        }
        protected void Listener(By by)
        {
            _helper.Listener(by);
        }
        protected void TakeScreenshot()
        {
            _helper.TakeScreenshot();
        }
        protected string GetText(IWebElement element, int? timeoutInmilliseconds = null)
        {
            return _helper.GetText(element, timeoutInmilliseconds);
        }
        protected string GetText(By by, int? timeoutInmilliseconds = null)
        {
            return _helper.GetText(by, timeoutInmilliseconds);
        }
        protected string GetAlertText(int? timeoutInmilliseconds = null)
        {
            return _helper.GetAlertText(timeoutInmilliseconds);
        }
        protected bool IsSelected(IWebElement element, int? timeoutInmilliseconds = null)
        {
            return _helper.IsSelected(element, timeoutInmilliseconds);
        }
        protected bool IsSelected(By by, int? timeoutInmilliseconds = null)
        {
            return _helper.IsSelected(by, timeoutInmilliseconds);
        }
        protected bool IsEnabled(IWebElement element, int? timeoutInmilliseconds = null)
        {
            return _helper.IsEnabled(element, timeoutInmilliseconds);
        }
        protected bool IsEnabled(By by, int? timeoutInmilliseconds = null)
        {
            return _helper.IsEnabled(by, timeoutInmilliseconds);
        }
        public bool IsVisibled(By by)
        {
            return _helper.IsVisibled(by);
        }
        #endregion

        #region Logging
        protected void LogInfo(string logMessage)
        {
            _logger.LogInfo($"{this.GetType().Name}:{logMessage}");
        }

        protected void LogDebug(string logMessage)
        {
            _logger.LogDebug($"{this.GetType().Name}:{logMessage}");
        }

        protected void LogWarning(string logMessage)
        {
            _logger.LogWarning($"{this.GetType().Name}:{logMessage}");
        }

        protected void LogError(string logMessage)
        {
            _logger.LogError($"{this.GetType().Name}:{logMessage}");
        }

        protected void LogFatal(string logMessage)
        {
            _logger.LogFatal($"{this.GetType().Name}:{logMessage}");
        }
        #endregion

        #region Wait Synchronization
        protected void WaitElementIsVisibled(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsVisibled(element, timeoutInmilliseconds);
        }
        protected void WaitElementIsVisibled(By by, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsVisibled(by, timeoutInmilliseconds);
        }
        protected void WaitElementIsClickabled(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsClickabled(element, timeoutInmilliseconds);
        }
        protected void WaitElementIsClickabled(By by, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsClickabled(by, timeoutInmilliseconds);
        }
        protected void WaitElementIsInvisibled(IWebElement element, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsInvisibled(element, timeoutInmilliseconds);
        }
        protected void WaitElementIsInvisibled(By by, int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitElementIsInvisibled(by, timeoutInmilliseconds);
        }
        protected void Wait(int timeoutInmilliseconds)
        {
            _waitManager.Wait(timeoutInmilliseconds);
        }
        protected void WaitPageLoadReady(int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitPageLoadReady(timeoutInmilliseconds);
        }
        protected void WaitAlertIsPresented(int? timeoutInmilliseconds = null)
        {
            _waitManager.WaitAlertIsPresented(timeoutInmilliseconds);
        }
        #endregion

    }
}
