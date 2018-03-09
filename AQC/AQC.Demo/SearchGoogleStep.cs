using AQC.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using AQC.Interface;
using System.Runtime.CompilerServices;

namespace AQC.Demo
{
    [Binding]
    public sealed class SearchGoogleSteps: BDDFixture
    {
        [Given(@"I go to http://www\.google\.com\.vn")]
        public void GivenIGoToHttpWww_Google_Com_Vn()
        {
            CurrentPage.GoTo<GooglePage>();
        }

        [Given(@"I fill search with ""(.*)""")]
        public void GivenIFillSearchWith(string p0)
        {
            CurrentPage.As<GooglePage>().Fillq(p0);
        }

        [When(@"I press search")]
        public void WhenIPress()
        {
            CurrentPage.As<GooglePage>().EnterSearch();
        }

        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(string p0)
        {
            CurrentPage.As<GooglePage>().CheckResulst(p0);
        }

    }
}

