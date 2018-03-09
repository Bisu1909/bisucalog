using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Page
{
    public interface IPage
    {
        bool IsAt();
        string PageUrl { get; }
        string BroswerUrl { get; }
        IPage GoTo<T>() where T : IPage;
        IPage GoTo<T>(string url) where T : IPage;
        T As<T>() where T : IPage;

        //#region Find Element
        //IWebElement Find(By by);
        //List<IWebElement> Finds(By by);
        //IWebElement Find(By parent, By by);
        //List<IWebElement> Finds(By parent, By by);
        //IWebElement Find(IWebElement parent, By by);
        //List<IWebElement> Finds(IWebElement parent, By by);
        //#endregion

        //#region Mouse Actions
        //void Click(IWebElement element, int? timeoutInmilliseconds = null);
        //void Click(By by, int? timeoutInmilliseconds = null);
        //void RightClick(IWebElement element, int? timeoutInmilliseconds = null);
        //void RightClick(By by, int? timeoutInmilliseconds = null);
        //void DoubleClick(IWebElement element, int? timeoutInmilliseconds = null);
        //void DoubleClick(By by, int? timeoutInmilliseconds = null);
        //void Submit(IWebElement element, int? timeoutInmilliseconds = null);
        //void Submit(By by, int? timeoutInmilliseconds = null);
        //void SelectComboItem(IWebElement element, string presentText, int? timeoutInmilliseconds = null);
        //void SelectComboItem(By by, string presentText, int? timeoutInmilliseconds = null);
        //void DragAndDrop(IWebElement from, IWebElement to, int? timeoutInmilliseconds = null);
        //void DragAndDrop(By from, IWebElement to, int? timeoutInmilliseconds = null);
        //void DragAndDrop(IWebElement from, By to, int? timeoutInmilliseconds = null);
        //void DragAndDrop(By from, By to, int? timeoutInmilliseconds = null);
        //void ClickHoldAndDrop(IWebElement from, IWebElement to, int? timeoutInmilliseconds = null);
        //void ClickHoldAndDrop(By from, IWebElement to, int? timeoutInmilliseconds = null);
        //void ClickHoldAndDrop(IWebElement from, By to, int? timeoutInmilliseconds = null);
        //void ClickHoldAndDrop(By from, By to, int? timeoutInmilliseconds = null);
        //void MoveMouseToElement(IWebElement element, int? timeoutInmilliseconds = null);
        //void MoveMouseToElement(By by, int? timeoutInmilliseconds = null);
        //#endregion

        //#region Keyboard Action
        //void ClearText(IWebElement element, int? timeoutInmilliseconds = null);
        //void ClearText(By by, int? timeoutInmilliseconds = null);
        //void TypeText(IWebElement element, string text, int? timeoutInmilliseconds = null);
        //void TypeText(By by, string text, int? timeoutInmilliseconds = null);
        //void TypeTextWithDelay(IWebElement element, string text, int delayInmilliseconds, int? timeoutInmilliseconds = null);
        //void TypeTextWithDelay(By by, string text, int delayInmilliseconds, int? timeoutInmilliseconds = null);
        //void ClearAndTypeText(IWebElement element, string TextToType, int? timeoutInmilliseconds = null);
        //void ClearAndTypeText(By by, string text, int? timeoutInmilliseconds = null);
        //void ClearAndTypeTextWithDelay(IWebElement element, string TextToType, int delayInmilliseconds, int? timeoutInmilliseconds = null);
        //void ClearAndTypeTextWithDelay(By by, string text, int delayInmilliseconds, int? timeoutInmilliseconds = null);
        //void PressEnter(IWebElement element, int? timeoutInmilliseconds = null);
        //void PressEnter(By text, int? timeoutInmilliseconds = null);
        //#endregion

        //#region Navigation
        //void SwitchToTab(int tabIndex);
        //void MaximizeBrowser();
        //void RefreshPage(int? timeoutInmilliseconds = null);
        //void GoForward(int? timeoutInmilliseconds = null);
        //void GoBackward(int? timeoutInmilliseconds = null);
        //void AcceptAlert(int? timeoutInmilliseconds = null);
        //void DismissAlert(int? timeoutInmilliseconds = null);
        //void ScrollToElement(IWebElement element, int? timeoutInmilliseconds = null);
        //void ScrollToElement(By by, int? timeoutInmilliseconds = null);
        //void ScrollDown(int nPixcels, int? timeoutInmilliseconds = null);
        //void ScrollUp(int nPixcels, int? timeoutInmilliseconds = null);
        //void ScrollLeft(int nPixcels, int? timeoutInmilliseconds = null);
        //void ScrollRight(int nPixcels, int? timeoutInmilliseconds = null);
        //void ScrollToTop(int? timeoutInmilliseconds = null);
        //void ScrollToBottom(int? timeoutInmilliseconds = null);
        //void ScrollTo(int xPixcel, int yPixcel, int? timeoutInmilliseconds = null);
        //void SwitchToFrame(int frameIndex, int? timeoutInmilliseconds = null);
        //void SwitchToDefaultFrame(int? timeoutInmilliseconds = null);
        //#endregion

        //#region Helper
        //void Listener(IWebElement element);
        //void Listener(By by);
        //void TakeScreenshot();
        //string GetText(IWebElement element, int? timeoutInmilliseconds = null);
        //string GetText(By by, int? timeoutInmilliseconds = null);
        //string GetAlertText(int? timeoutInmilliseconds = null);
        //bool IsSelected(IWebElement element, int? timeoutInmilliseconds = null);
        //bool IsSelected(By by, int? timeoutInmilliseconds = null);
        //bool IsEnabled(IWebElement element, int? timeoutInmilliseconds = null);
        //bool IsEnabled(By by, int? timeoutInmilliseconds = null);
        //#endregion

        //#region Logging
        //void LogInfo(string logMessage);
        //void LogDebug(string logMessage);
        //void LogWarning(string logMessage);
        //void LogError(string logMessage);
        //void LogFatal(string logMessage);
        //#endregion

        //#region Wait Synchronization
        //void WaitElementIsVisibled(IWebElement element, int? timeoutInmilliseconds = null);
        //void WaitElementIsVisibled(By by, int? timeoutInmilliseconds = null);
        //void WaitElementIsClickabled(IWebElement element, int? timeoutInmilliseconds = null);
        //void WaitElementIsClickabled(By by, int? timeoutInmilliseconds = null);
        //void WaitElementIsInvisibled(IWebElement element, int? timeoutInmilliseconds = null);
        //void WaitElementIsInvisibled(By by, int? timeoutInmilliseconds = null);
        //void Wait(int timeoutInmilliseconds);
        //void WaitPageLoadReady(int? timeoutInmilliseconds = null);
        //void WaitAlertIsPresented(int? timeoutInmilliseconds = null);
        //#endregion
    }
}
