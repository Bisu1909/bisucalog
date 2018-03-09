using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AQC.Interface;

namespace AQC.Page
{
    public class BlankPage : BasePage
    {
        public BlankPage(IFixture fixture) : base(fixture)
        {

        }

        public override string PageUrl => Setting.BaseUrl;

        public override bool IsAt()
        {
            return Driver.Url.StartsWith(PageUrl, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
