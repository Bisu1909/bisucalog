using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC
{
    public static class WebElementExtension
    {
        public static T As<T>(this IWebElement element)
        {
            return (T)Activator.CreateInstance(typeof(T), element);
        }
    }
}
