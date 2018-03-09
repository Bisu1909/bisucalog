using AQC.Interface;
using AQC.Page;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Demo
{
    public class Way2automationPage : BasePage
    {
        [Dependency]
        public IDataService DataService { get; set; }
        public Way2automationPage(IFixture fixture) : base(fixture)
        {
        }
        public override string PageUrl => "http://way2automation.com/way2auto_jquery/index.php";
        internal void Login(string username, string password)
        {
            Click(By.XPath("//a[.='Signin']"));
            TypeText(By.XPath("//div[@id='login']//input[@name='username']"), username);
            TypeText(By.XPath("//div[@id='login']//input[@name='password']"), password);
            Submit(By.XPath("//div[@id='login']//input[@value='Submit']"));
            WaitPageLoadReady();
        }
        internal void Registration()
        {
            string username = "dong" + DateTime.Now;
            string email = username + "@gmail.com";
            string password = "Amaris2017";
            Click(By.XPath("//h2[.='Registration']"));
            TypeText(By.XPath("id('register_form')/fieldset[1]/p[1]/input"), "Manh Dong");
            TypeText(By.XPath("id('register_form')/fieldset[1]/p[2]/input"), "Nguyen");
            Click(By.XPath("id('register_form')/fieldset[2]//label[2]/input"), 4000);
            Click(By.XPath("id('register_form')/fieldset[3]//label[2]/input"), 4000);
            ClearAndTypeTextWithDelay(By.XPath("id('register_form')/fieldset[6]/input[1]"), "0902962207", 500);
            ClearAndTypeText(By.XPath("id('register_form')/fieldset[7]/input[1]"), username);
            ClearAndTypeTextWithDelay(By.XPath("id('register_form')/fieldset[8]/input[1]"), email, 500, 7000);
            TypeText(By.XPath("id('register_form')/fieldset[11]/input[1]"), password);
            TypeText(By.XPath("id('register_form')/fieldset[12]/input[1]"), password);
            Click(By.XPath("id('register_form')/fieldset[13]/input[1]"));
        }
        internal void Droppable()
        {
            Click(By.XPath("//h2[.='Droppable']"));
            SwitchToFrame(0);
            ClickHoldAndDrop(By.XPath("//p[.='Drag me to my target']"), By.XPath("//p[.='Drop here']"), 10000);
            SwitchToDefaultFrame();
            Click(By.XPath("//a[.='Shopping cart demo']"));
            SwitchToFrame(4);
            DragAndDrop(By.XPath("id('ui-id-2')//li[.='Lolcat Shirt']"), By.XPath("//div[@id='cart']//ol/li"));
            ClickHoldAndDrop(By.XPath("id('ui-id-2')//li[.='Lolcat Shirt']"), By.XPath("//div[@id='cart']//ol/li"));
            TakeScreenshot();

        }
        internal void Alert()
        {
            Click(By.XPath("//a[.='Alert']"));
            SwitchToFrame(0);
            Click(By.XPath("//button[@onclick='myFunction()']"));
            string alertText = GetAlertText();
            LogInfo(alertText + " Nguyen Manh Dong");
            AcceptAlert();
            TakeScreenshot();
            SwitchToDefaultFrame();
            Click(By.XPath("//a[.='Input Alert']"));
            SwitchToFrame(1);
            Click(By.XPath("//button[@onclick='myFunction()']"));
            AcceptAlert();
            Assert.True(GetText(By.XPath("//p[@id='demo']")).Contains("Harry Potter"));
        }
        internal void Dropdown()
        {
            MoveMouseToElement(By.XPath("//a[.='Dynamic Elements']"));
            TakeScreenshot();
        }
    }
}
