using AQC.Interface;
using AQC.Page;
using AQC.Unity;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Data;

namespace AQC
{
    public class AFixture : IFixture
    {
        #region Inherit hierarchical
        protected ISetting Setting { get; set; }
        protected ILog Logger { get; set; }
        protected IFindManager FindManager { get; set; }
        protected IWaitManager WaitManager { get; set; }
        protected IMouseManager MouseManager { get; set; }
        protected IKeyboardManager KeyboardManager { get; set; }
        protected INavigationManager NavigationManager { get; set; }
        protected IHelper Helper { get; set; }
        protected IPage CurrentPage { get; set; }
        protected IWebDriver Driver { get; set; }
        protected IDbConnectionManager DbConnectionManager { get; set; }
        #endregion

        #region NUnit setup
        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            var container = UnityConfig.GetUnityContainer();
            DbConnectionManager = container.Resolve<IDbConnectionManager>();
            Setting = container.Resolve<ISetting>();
            Logger = container.Resolve<ILog>();
            Logger.Context = $"{TestContext.CurrentContext.Test.ClassName}";
            var factory = UnityConfig.GetUnityContainer().Resolve<IWebDriverFactory>();
            Driver = factory.CreateWebDriver();
            FindManager = container.Resolve<IFindManager>(new ParameterOverride("driver", Driver));
            WaitManager = container.Resolve<IWaitManager>(new ParameterOverride("driver", Driver), new ParameterOverride("findManager", FindManager), new ParameterOverride("logger", Logger));
            MouseManager = container.Resolve<IMouseManager>(new ParameterOverride("driver", Driver), new ParameterOverride("findManager", FindManager), new ParameterOverride("waitManager", WaitManager), new ParameterOverride("logger", Logger));
            KeyboardManager = container.Resolve<IKeyboardManager>(new ParameterOverride("driver", Driver), new ParameterOverride("findManager", FindManager), new ParameterOverride("waitManager", WaitManager), new ParameterOverride("logger", Logger));
            NavigationManager = container.Resolve<INavigationManager>(new ParameterOverride("driver", Driver), new ParameterOverride("findManager", FindManager), new ParameterOverride("waitManager", WaitManager), new ParameterOverride("logger", Logger));
            Helper = container.Resolve<IHelper>(new ParameterOverride("driver", Driver), new ParameterOverride("findManager", FindManager), new ParameterOverride("waitManager", WaitManager), new ParameterOverride("logger", Logger));
            CurrentPage = new BlankPage(this);
            Logger.LogInfo($"################################################################################################");
            Logger.LogInfo($"OneTimeSetUp");
        }
        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {
            try
            {
                Logger.LogInfo($"OneTimeTearDown");
                Setting = null;
                Logger = null;
                FindManager = null;
                WaitManager = null;
                MouseManager = null;
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
        [SetUp]
        public virtual void SetUp()
        {
            Logger.LogInfo($"------------------------------------------------------------------------------------------------");
            Logger.LogInfo($"{TestContext.CurrentContext.Test.MethodName}.SetUp");
            CurrentPage.GoTo<BlankPage>();
        }
        [TearDown]
        public virtual void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Logger.LogInfo("Test result Failed! taking screenshot for checking ...");
                Helper.TakeScreenshot();
            }
            Logger.LogInfo($"{TestContext.CurrentContext.Test.MethodName}.TearDown");
            Driver.Manage().Cookies.DeleteAllCookies();
            //CurrentPage.GoTo<BlankPage>();
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
