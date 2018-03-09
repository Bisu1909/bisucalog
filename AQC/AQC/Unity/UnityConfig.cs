using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Unity
{
    public class UnityConfig
    {
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetUnityContainer()
        {
            return Container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            var testAssemblyName = System.Configuration.ConfigurationManager.AppSettings["AssemblyName"];
            var assembly = AssemblyUtils.GetLoadedAssembly(testAssemblyName);
            var startUpClassNames = AssemblyUtils.GetTypesWithUnityStartUpAttribute(assembly);
            if (startUpClassNames.Count() > 1)
            {
                throw new InvalidUnitySetUpException("The test project must have only one start up class with attribute 'UnityStartUp'");
            }
            Type type;

            if (startUpClassNames.Count() == 0)
            {
                type = Type.GetType("AQC.Unity.UnityStartUpBase");
            }
            else
            {
                type = startUpClassNames.First();
            }
            var module = (IContainerRegistrationModule<IUnityContainer>)Activator.CreateInstance(type);

            module.Register(container);
        }
    }
}
