using AQC.Demo;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Demo
{
    [TestFixture]
    public class Way2automationTest : AFixture
    {
        [Test]
        public void LoginValidTest()
        {
            CurrentPage.GoTo<Way2automationPage>();
            CurrentPage.As<Way2automationPage>().Login("abc","123");
        }
        [Test]
        public void RegistrationTest()
        {
            CurrentPage.GoTo<Way2automationPage>();
            CurrentPage.As<Way2automationPage>().Login("abc", "123");
            CurrentPage.As<Way2automationPage>().Registration();
        }
        [Test]
        public void DropTest()
        {
            CurrentPage.GoTo<Way2automationPage>();
            CurrentPage.As<Way2automationPage>().Login("abc", "123");
            CurrentPage.As<Way2automationPage>().Droppable();
        }
        [Test]
        public void AlertTest()
        {
            CurrentPage.GoTo<Way2automationPage>();
            CurrentPage.As<Way2automationPage>().Login("abc", "123");
            CurrentPage.As<Way2automationPage>().Alert();
        }
        [Test]
        public void DropdownTest()
        {
            CurrentPage.GoTo<Way2automationPage>();
            CurrentPage.As<Way2automationPage>().Login("abc", "123");
            CurrentPage.As<Way2automationPage>().Dropdown();
        }
    }
}   
