using AQC.Interface;
using AQC.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace FunctionsManagementTest.POM
{
    public class LoginPage : BasePage
    {
        public LoginPage(IFixture fixture) : base(fixture)
        {
        }

        public override string PageUrl => "https://login.o2f-it.com";
        public void Login()
        {
            TypeText(By.XPath("//input[@id='userNameInput']"), Setting.UserName);
            TypeText(By.XPath("//input[@id='passwordInput']"), Setting.Password);
            Click(By.XPath("//span[@id='submitButton']"));
            WaitPageLoadReady();
        }
 
    }
}
