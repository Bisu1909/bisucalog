using AQC.Interface;
using AQC.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC
{
    public class FindManager : IFindManager
    {        
        public FindManager(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebDriver _driver;
        public IWebElement Find(By by)
        {
            return _driver.FindElement(by);
        }
        public IWebElement Find(By parent, By by)
        {
            return Find(Find(parent), by);
        }
        public IWebElement Find(IWebElement parent, By by)
        {
            return parent.FindElement(by);
        }
        public List<IWebElement> Finds(IWebElement parent, By by)
        {
            return parent.FindElements(by).ToList();
        }
        public List<IWebElement> Finds(By by)
        {
            return _driver.FindElements(by).ToList();
        }
        public List<IWebElement> Finds(By parent, By by)
        {
            return Finds(Find(parent), by);
        }
    }
}
