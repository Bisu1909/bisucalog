using Microsoft.Practices.Unity;
using SpecFlow.Unity;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace AQC.Unity
{
    public static class TestDependencies
    {
        [ScenarioDependencies]
        public static IUnityContainer CreateContainer()
        {
            // create container with the runtime dependencies
            var container = new UnityContainer();
            //TODO: add customizations, stubs required for testing
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


            //container.RegisterType<IWebDriverFactory, WebDriverFactory>(new HierarchicalLifetimeManager());
            module.Register(container);
            // Registers the build steps, this gives us dependency resolution using the container.
            // NB If you need named parameters into the steps you should override specific registrations
            container.RegisterTypes(typeof(TestDependencies).Assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))),
                                    WithMappings.FromMatchingInterface,
                                    WithName.Default,
                                    WithLifetime.ContainerControlled);

            return container;
        }
    }
}
