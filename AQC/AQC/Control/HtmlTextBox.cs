﻿using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC
{
    public class HtmlTextBox: HtmlInput
    {
        public HtmlTextBox(IWebElement webElement) : base(webElement) { }
    }
}
