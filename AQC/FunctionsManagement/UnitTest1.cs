using System;
using AQC;
using FunctionsManagementTest.POM;
using NUnit.Framework;

namespace FunctionsManagementTest
{
    [TestFixture]
    public class UnitTest1 : AFixture
    {
        [Test]
        public void TestMethod1()
        {
            CurrentPage.GoTo<FunctionsManagementPage>();
            CurrentPage.As<LoginPage>().Login();
            CurrentPage.As<FunctionsManagementPage>().FakeAuthenTo("Le Page Thomas");
            CurrentPage.As<FunctionsManagementPage>().CheckIsAtFunctionsManagementPage();
        }
    }
}
