using AQC.Interface;
using AQC.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Demo.POM
{
    class ClassSearchPage : BasePage
    {
        public ClassSearchPage(IFixture fixture) : base(fixture)
        {
        }

        public override string PageUrl => "https://google.com";
    }
}
