using AQC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace AQC
{
    public class WebDriverFactory : IWebDriverFactory
    {
        public IWebDriver CreateWebDriver()
        {
            var driverDirectory = ConfigurationManager.AppSettings["DriverDirectory"];
            var implicitWaitInmilliseconds = int.Parse(ConfigurationManager.AppSettings["ImplicitWaitInmilliseconds"]);
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--test-type");
            IWebDriver webDriver;
            if (!string.IsNullOrEmpty(driverDirectory))
            {
                webDriver = new ChromeDriver(driverDirectory, chromeOptions);
                webDriver.Manage().Window.Maximize();
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(implicitWaitInmilliseconds);
            }
            else
            {
                webDriver = new ChromeDriver(chromeOptions);
            }
            return webDriver;
        }
    }
}
