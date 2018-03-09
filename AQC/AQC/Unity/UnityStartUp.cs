using AQC.Interface;
using AQC.Log;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Unity
{
    public class UnityStartUp : IContainerRegistrationModule<IUnityContainer>
    {
        public virtual void Register(IUnityContainer container)
        {
            container.RegisterType<ILog, Log4NetAdaper>(new PerResolveLifetimeManager());
            container.RegisterType<IWebDriverFactory, WebDriverFactory>(new ContainerControlledLifetimeManager());
            container.RegisterType<IFindManager, FindManager>(new PerResolveLifetimeManager());
            container.RegisterType<IWaitManager, WaitManager>(new PerResolveLifetimeManager());
            container.RegisterType<IMouseManager, MouseManager>(new PerResolveLifetimeManager());
            container.RegisterType<IKeyboardManager, KeyboardManager>(new PerResolveLifetimeManager());
            container.RegisterType<INavigationManager, NavigationManager>(new PerResolveLifetimeManager());
            container.RegisterType<IHelper, Helper>(new PerResolveLifetimeManager());
            container.RegisterType<ISetting, Setting>(new ContainerControlledLifetimeManager());
            container.RegisterType<IDbConnectionManager, DbConnectionManager>(new ContainerControlledLifetimeManager());
        }
    }
}
