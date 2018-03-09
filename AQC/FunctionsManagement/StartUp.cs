using AQC;
using AQC.Interface;
using AQC.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyTest
{
    [UnityStartUp]
    public class StartUp : UnityStartUp
    {
        public override void Register(IUnityContainer container)
        {
            base.Register(container);
            container.RegisterType<ISetting, Setting>(new ContainerControlledLifetimeManager());
        }
    }
}
