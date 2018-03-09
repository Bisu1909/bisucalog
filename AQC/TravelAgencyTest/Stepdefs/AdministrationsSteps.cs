using AQC.Implement;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TravelAgencyTest.POM;

namespace TravelAgencyTest.Stepdefs
{
    [Binding]
    [Scope(Feature = "Administrations")]
    public sealed class AdministrationsSteps : BDDFixture
    {
        [Given(@"User go to Travel Agency price Guideline page")]
        public void GivenUserGoToTravelAgencyPriceGuidelinePage()
        {
            CurrentPage.GoTo<PriceGuidelinePage>();
        }

        [When(@"User Login with username and password")]
        public void WhenUserLoginWithUsernameAndPassword()
        {
            CurrentPage.As<LoginPage>().Login(Setting.UserName, Setting.Password);
        }

        [Given(@"User fake authen as ""(.*)"" in price Guideline page")]
        public void GivenUserFakeAuthenAsInPriceGuidelinePage(string user)
        {
            CurrentPage.As<PriceGuidelinePage>().FakeAuthento(user);
        }

        [When(@"User select create new guideline button")]
        public void WhenUserSelectCreateNewGuidelineButton()
        {
            CurrentPage.As<PriceGuidelinePage>().SelectToOpenNewGuidelinePopup();
        }

        [When(@"User select service as ""(.*)"" on create price guideline popup")]
        public void WhenUserSelectServiceAsOnCreatePriceGuidelinePopup(string service)
        {
            CurrentPage.As<PriceGuidelinePage>().SelectService(service);
        }

        [When(@"User select from and to as ""(.*)"" and ""(.*)""")]
        public void WhenUserSelectFromAndToAsAnd(string from, string to)
        {
            CurrentPage.As<PriceGuidelinePage>().FillFlightFromAndToPlace(from, to);
        }

        [When(@"User select ""(.*)"" Class")]
        public void WhenUserSelectClass(string classType)
        {
            CurrentPage.As<PriceGuidelinePage>().SelectFlightClass(classType);
        }

        [When(@"User fill Low price as ""(.*)"", average price as ""(.*)"", High price as ""(.*)""")]
        public void WhenUserFillLowPriceFromToAverageAs(string lowPrice, string averagePrice, string highPrice)
        {
            CurrentPage.As<PriceGuidelinePage>().FillPrices(lowPrice, averagePrice, highPrice);
        }

        [When(@"User select Create button on create price guideline popup")]
        public void WhenUserSelectCreateButtonOnCreatePriceGuidelinePopup()
        {
            CurrentPage.As<PriceGuidelinePage>().SelectCreatePriceGuideline();
        }

        [Then(@"User should see success create price guideline message")]
        public void ThenUserShouldSeeSuccessCreatePriceGuidelineMessage()
        {
            CurrentPage.As<PriceGuidelinePage>().CheckSuccessCreateMessage();
        }

        [Given(@"User search Flight from ""(.*)"" to ""(.*)"", class as ""(.*)""")]
        public void GivenUserSearchFlightFromTo(string from, string to, string classType)
        {
            CurrentPage.As<PriceGuidelinePage>().SearchFlight(from, to, classType);
        }

        [Given(@"User delete guideline on page")]
        public void GivenUserDeleteGuidelineOnPage()
        {
            CurrentPage.As<PriceGuidelinePage>().DeleteFirstPriceGuidelineRecords();
        }

        [Then(@"User should see success delete price guideline message")]
        public void ThenUserShouldSeeSuccessDeletePriceGuidelineMessage()
        {
            CurrentPage.As<PriceGuidelinePage>().CheckSuccessDeleteMessage();
        }

    }
}
