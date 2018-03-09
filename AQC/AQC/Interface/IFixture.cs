using AQC.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Interface
{
    public interface IFixture
    {
        void SetPage(IPage page);
        ILog GetLogger();
        IPage GetPage();
        ISetting GetSetting();
        IWebDriver GetDriver();
        IFindManager GetFindManager();
        IWaitManager GetWaitManager();
        IMouseManager GetMouseManager();
        IKeyboardManager GetKeyboardManager();
        INavigationManager GetNavigationManager();
        IHelper GetHelper();
        IDbConnectionManager GetDbConnectionManager();
    }
}
