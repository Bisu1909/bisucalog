using AQC.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Interface
{
    public interface IFindManager
    {
        IWebElement Find(By by);
        IWebElement Find(By parent, By by);
        IWebElement Find(IWebElement parent, By by);
        List<IWebElement> Finds(IWebElement parent, By by);
        List<IWebElement> Finds(By by);
        List<IWebElement> Finds(By parent, By by);        
    }
}
