using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Interface
{
    public interface INavigationManager
    {
        void SwitchToTab(int tabIndex);
        void MaximizeBrowser();
        void RefreshPage(int? timeoutInmilliseconds = null);
        void GoForward(int? timeoutInmilliseconds = null);
        void GoBackward(int? timeoutInmilliseconds = null);
        void AcceptAlert(int? timeoutInmilliseconds = null);
        void DismissAlert(int? timeoutInmilliseconds = null);
        void ScrollToElement(IWebElement element, int? timeoutInmilliseconds = null);
        void ScrollToElement(By by, int? timeoutInmilliseconds = null);
        void ScrollDown(int nPixcels, int? timeoutInmilliseconds = null);
        void ScrollUp(int nPixcels, int? timeoutInmilliseconds = null);
        void ScrollLeft(int nPixcels, int? timeoutInmilliseconds = null);
        void ScrollRight(int nPixcels, int? timeoutInmilliseconds = null);
        void ScrollToTop(int? timeoutInmilliseconds = null);
        void ScrollToBottom(int? timeoutInmilliseconds = null);
        void ScrollTo(int xPixcel, int yPixcel, int? timeoutInmilliseconds = null);
        void SwitchToFrame(int frameIndex, int? timeoutInmilliseconds = null);
        void SwitchToDefaultFrame(int? timeoutInmilliseconds = null);
    }
}
