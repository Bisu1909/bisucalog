using AQC.Interface;
using AQC.Log;
using AQC.Unity;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;

namespace AQC.Demo
{
    [UnityStartUp]
    public class StartUp : UnityStartUp
    {
        public override void Register(IUnityContainer container)
        {
            base.Register(container);
            container.RegisterType<IDataService, DataService>(new ContainerControlledLifetimeManager());
        }
    }
}
