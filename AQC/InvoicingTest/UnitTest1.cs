using System;

using AQC;
using AQC.Page;
using InvoicingTest.POM;
using NUnit.Framework;

namespace InvoicingTest
{
    [TestFixture]
    public class UnitTest1 : AFixture
    {
        [Test]
        public void TestMethod2()
        {
            CurrentPage.GoTo<ManagePage>();
            CurrentPage.As<ManagePage>().FakeAuthenTo("Nguyen Manh Dong");
        }
    }
}
