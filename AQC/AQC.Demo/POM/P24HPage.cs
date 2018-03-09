using AQC.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AQC.Interface;
using NUnit.Framework;

namespace AQC.Demo
{
    public class P24HPage : BasePage
    {
        public P24HPage(IFixture fixture) : base(fixture)
        {
        }

        public override string PageUrl => "http://www.24h.com.vn/";

        public override bool IsAt()
        {
            return BroswerUrl.StartsWith(PageUrl);
        }

        internal void ChooseBongDaLink()
        {
            LogInfo("ChooseBongDaLink");
            var element = Find(By.CssSelector("body > div.container > div.header > div.headerRight > div > div > ul > li:nth-child(1) > a"));
            element.Click();
            var bongdaLinkEle = Find(By.CssSelector("body > div.container > div.content > table > tbody > tr > td:nth-child(1) > div > div.bread-cum-cm2 > div.cate_breadcrum.breadcum-CMtab > ul > li > h1 > a"));
            Assert.AreEqual("Bóng đá", bongdaLinkEle.Text);
            LogInfo("END ChooseBongDaLink");
        }
    }
}
