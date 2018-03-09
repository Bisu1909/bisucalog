using AQC.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using AQC.Interface;
using Microsoft.Practices.Unity;

namespace AQC.Demo
{
    public class GooglePage : BasePage
    {
         private By queryButton = By.XPath("//*[@id='rso']/div/div/div[1]/div/div/h3/a");



        [Dependency]
        public IDataService DataService { get; set; }
        public GooglePage(IFixture fixture) : base(fixture)
        {
        }

        public override string PageUrl => "https://www.google.com.vn";

        internal void Search(string term)
        {
            LogInfo("Search");

            ClearAndTypeText(By.Id("lst-ib"), term);
            PressEnter(By.Id("lst-ib"));
            var resultElement = Find(By.XPath("//*[@id='rso']/div/div/div[1]/div/div/h3/a"));
            Assert.AreEqual("Amaris International Consulting Company", resultElement.Text);
            LogInfo("End Search");


        }

        internal void EnterSearch()
        {
            LogInfo("EnterSearch Start");
            ClearAndTypeTextWithDelay(By.Name("q"), "Nguyen Manh DOng", 500);
            PressEnter(By.Name("q"));
            DragAndDrop(By.CssSelector("#tsf > div.tsf-p > div.jsb > center > input[type='submit']:nth-child(1)"), By.Name("q"));
            LogInfo("EnterSearch End");
        }

        internal void CheckResulst(string p0)
        {
            LogInfo("CheckResulst Start");
            var resultElement = Find(By.XPath("//*[@id='rso']/div/div/div[1]/div/div/h3/a"));
            Assert.AreEqual(p0, resultElement.Text);
            LogInfo("CheckResulst End");
        }

        internal void Fillq(string p0)
        {
            LogInfo("Fillq Start");
            ClearAndTypeText(By.Id("lst-ib"), p0);
            LogInfo("Fillq End");
        }

        public override bool IsAt()
        {
            return BroswerUrl.StartsWith(PageUrl);
        }
    }
}
