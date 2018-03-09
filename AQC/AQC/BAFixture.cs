using AQC.Interface;
using AQC.Page;
using AQC.Unity;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using AQC;

namespace AQC.Implement
{
    public class BDDFixture : IBDDFixture
    {
        #region Inherit hierarchical
        protected ISetting Setting
        {
            get { return (ISetting)ScenarioContext.Current["CurrentSetting"]; }
            set { ScenarioContext.Current["CurrentSetting"] = value; }
        }
        protected ILog Logger
        {
            get { return (ILog)ScenarioContext.Current["CurrentLogger"]; }
            set { ScenarioContext.Current["CurrentLogger"] = value; }
        }
        protected IFindManager FindManager
        {
            get { return (IFindManager)ScenarioContext.Current["CurrentFindManager"]; }
            set { ScenarioContext.Current["CurrentFindManager"] = value; }
        }
        protected IWaitManager WaitManager
        {
            get { return (IWaitManager)ScenarioContext.Current["CurrentWaitManager"]; }
            set { ScenarioContext.Current["CurrentWaitManager"] = value; }
        }
        protected IMouseManager MouseManager
        {
            get { return (IMouseManager)ScenarioContext.Current["CurrentMouseManager"]; }
            set { ScenarioContext.Current["CurrentMouseManager"] = value; }
        }
        protected IKeyboardManager KeyboardManager
        {
            get { return (IKeyboardManager)ScenarioContext.Current["CurrentKeyboardManager"]; }
            set { ScenarioContext.Current["CurrentKeyboardManager"] = value; }
        }
        protected INavigationManager NavigationManager
        {
            get { return (INavigationManager)ScenarioContext.Current["CurrentNavigationManager"]; }
            set { ScenarioContext.Current["CurrentNavigationManager"] = value; }
        }
        protected IHelper Helper
        {
            get { return (IHelper)ScenarioContext.Current["CurrentHelper"]; }
            set { ScenarioContext.Current["CurrentHelper"] = value; }
        }
        protected IPage CurrentPage
        {
            get { return (IPage)ScenarioContext.Current["CurrentPage"]; }
            set { ScenarioContext.Current["CurrentPage"] = value; }
        }
        protected IWebDriver Driver
        {
            get { return (IWebDriver)ScenarioContext.Current["CurrentDriver"]; }
            set { ScenarioContext.Current["CurrentDriver"] = value; }
        }
        protected IDbConnectionManager DbConnectionManager {
            get { return (IDbConnectionManager)ScenarioContext.Current["CurrentDbConnectionManager"]; }
            set { ScenarioContext.Current["CurrentDbConnectionManager"] = value; }
        }
        #endregion

        #region SpecFlow Scenario       
        [BeforeScenario]
        public virtual void BeforeScenario()
        {
            var container = UnityConfig.GetUnityContainer();
            DbConnectionManager = container.Resolve<IDbConnectionManager>();
            Setting = container.Resolve<ISetting>();
            Logger = container.Resolve<ILog>();
            Logger.Context = $"{ScenarioContext.Current.ScenarioInfo.Title}";
            var factory = container.Resolve<IWebDriverFactory>();
            Driver = factory.CreateWebDriver();
            FindManager = container.Resolve<IFindManager>(new ParameterOverride("driver", Driver));
            WaitManager = container.Resolve<IWaitManager>(new ParameterOverride("driver", Driver), new ParameterOverride("finder", FindManager), new ParameterOverride("logger", Logger));
            MouseManager = container.Resolve<IMouseManager>(new ParameterOverride("driver", Driver), new ParameterOverride("finder", FindManager), new ParameterOverride("waiter", WaitManager), new ParameterOverride("logger", Logger));
            KeyboardManager = container.Resolve<IKeyboardManager>(new ParameterOverride("driver", Driver), new ParameterOverride("findManager", FindManager), new ParameterOverride("waitManager", WaitManager), new ParameterOverride("logger", Logger));
            NavigationManager = container.Resolve<INavigationManager>(new ParameterOverride("driver", Driver), new ParameterOverride("findManager", FindManager), new ParameterOverride("waitManager", WaitManager), new ParameterOverride("logger", Logger));
            Helper = container.Resolve<IHelper>(new ParameterOverride("driver", Driver), new ParameterOverride("findManager", FindManager), new ParameterOverride("waitManager", WaitManager), new ParameterOverride("logger", Logger));
            CurrentPage = new BlankPage(this);
            Logger.LogInfo($"################################################################################################");
            Logger.LogInfo($"BeforeScenario");
        }
        [AfterScenario]
        public virtual void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                Logger.LogInfo("Test result Failed! taking screenshot for checking ...");
                Helper.TakeScreenshot();
            }
            try
            {
                Setting = null;
                Logger = null;
                FindManager = null;
                WaitManager = null;
                NavigationManager = null;
                Helper = null;
                CurrentPage = null;
                Driver?.Close();
                Driver?.Dispose();
                Driver = null;
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region IFixture
        ILog IFixture.GetLogger()
        {
            return Logger;
        }
        IPage IFixture.GetPage()
        {
            return CurrentPage;
        }
        void IFixture.SetPage(IPage page)
        {
            CurrentPage = page;
        }
        ISetting IFixture.GetSetting()
        {
            return Setting;
        }
        IWebDriver IFixture.GetDriver()
        {
            return Driver;
        }
        public IFindManager GetFindManager()
        {
            return FindManager;
        }
        public IWaitManager GetWaitManager()
        {
            return WaitManager;
        }
        public IMouseManager GetMouseManager()
        {
            return MouseManager;
        }
        public IKeyboardManager GetKeyboardManager()
        {
            return KeyboardManager;
        }
        public INavigationManager GetNavigationManager()
        {
            return NavigationManager;
        }
        public IHelper GetHelper()
        {
            return Helper;
        }

        public IDbConnectionManager GetDbConnectionManager()
        {
            return DbConnectionManager;
        }
        #endregion
    }
}
