using AQC.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQC.Interface;
using OpenQA.Selenium;

namespace TravelAgencyTest.POM
{
    public class MyRequestPage : BasePage
    {
        public MyRequestPage(IFixture fixture) : base(fixture)
        {
        }

        public override string PageUrl => Setting.BaseUrl + "TravelAgency/myrequest";

        public void SearchRequest(string searchText, string startTime, string toTime)
        {
            var lightSearchInput = By.XPath("//input[@id='Search_BasicSearchs_0__LightSearch']");
            var startTimeInput = By.XPath("//input[@placeholder='Start Time']");
            var toTimeInput = By.XPath("//input[@placeholder='To Time']");
            var searchButton = By.XPath("//i[@class='fa fa-search']");

            TypeText(lightSearchInput, searchText);
            TypeText(startTimeInput, startTime);
            TypeText(toTimeInput, toTime);
            Click(searchButton);

        }
    }
}
