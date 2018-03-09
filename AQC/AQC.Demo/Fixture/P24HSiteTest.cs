using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace AQC.Demo.Fixture
{
    /// <summary>
    /// Summary description for P24HSiteTest
    /// </summary>
    [TestFixture]
    public class P24HSiteTest: AFixture
    {
        [Test]
        public void GoTo24h()
        {
            CurrentPage.GoTo<P24HPage>();
        }
        [Test]
        public void GoTo24hBongDa()
        {
            CurrentPage.GoTo<P24HPage>();
            CurrentPage.As<P24HPage>().ChooseBongDaLink();
        }
    }
}
