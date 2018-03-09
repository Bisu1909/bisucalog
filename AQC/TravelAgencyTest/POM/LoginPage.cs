using AQC.Interface;
using AQC.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyTest.POM
{
    public class LoginPage : BasePage
    {
        private By LoginUsernameField = By.Id("userNameInput");
        private By LoginpasswordField = By.Id("passwordInput");
        private By LoginSubmitButton = By.Id("submitButton");
        private By LoaddingOverlay = By.XPath("//div[@class='blockUI blockMsg blockPage']");
        public LoginPage(IFixture fixture) : base(fixture)
        {
        }

        public override string PageUrl => "https://login.o2f-it.com/";

        public void Login(string username, string password)
        {
            MaximizeBrowser();
            TypeText(LoginUsernameField, username);
            TypeText(LoginpasswordField, password);
            Submit(LoginSubmitButton);      
            
        }
    }
}
