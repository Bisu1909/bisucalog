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
    [Scope(Feature = "TravelRequestEstimation")]
    public sealed class TravelRequestEstimationSteps : BDDFixture
    {
        [Given(@"User go to Travel Agency Create Page")]
        public void GivenUserGoToTravelAgencyCreatePage()
        {
            CurrentPage.GoTo<CreatePage>();
            //Helper.Listener(By.XPath("//form[@id='traveller-profile-form']//button[@id='btn-save']"));
            //Helper.Listener(By.XPath("//form[@id='accept-policy-form']//input[@type='checkbox']"));
            //Helper.Listener(By.XPath("//form[@id='accept-policy-form']//button[@id='btn-Confirm']"));
        }

        [When(@"User Login with username and password")]
        public void WhenUserLoginWithUsernameAndPassword()
        {
            CurrentPage.As<LoginPage>().Login(Setting.UserName, Setting.Password);
        }

        [Then(@"User should see Welcome message on create page")]
        public void ThenUserShouldSeeWelcomeMessageOnCreatePage()
        {
            CurrentPage.As<CreatePage>().IsAtWelcomePage();
        }

        [Given(@"User go to Travel Agency Handle Request Page")]
        public void GivenUserGoToTravelAgencyHandleRequestPage()
        {
            CurrentPage.GoTo<HandleRequestPage>();
        }

        [When(@"User fake authen as ""(.*)"" in HandleRequest Page")]
        public void WhenUserFakeAuthenAsInHandleRequestPage(string user)
        {
            CurrentPage.As<HandleRequestPage>().FakeAuthento(user);
        }

        [When(@"User select All tab")]
        public void WhenUserSelectAllTab()
        {
            CurrentPage.As<HandleRequestPage>().SelectAllTab();
        }

        [When(@"User select estimate price button on request with ""(.*)"" status")]
        public void WhenUserSelectEstimatePriceButtonOnRequestWithStatus(string status)
        {
            string requestId = CurrentPage.As<HandleRequestPage>().GetFirstRequestIdByStatus(status);
            CurrentPage.As<HandleRequestPage>().SelectEstimatePrice(requestId);
            ScenarioContext.Current.Add("requestId", requestId);
        }

        [When(@"User input price as ""(.*)"" currency as ""(.*)"" for all trip")]
        public void WhenUserInputPriceAsCurrencyAsForAllTrip(int price, string currency)
        {
            CurrentPage.As<HandleRequestPage>().EstimatePrice(ScenarioContext.Current.Get<string>("requestId"));
        }

        [When(@"User select Save and Validate button on price pop-up")]
        public void WhenUserSelectSaveAndValidateButtonOnPricePop_Up()
        {
            CurrentPage.As<HandleRequestPage>().SelectSendForValidationButton();
        }

        [Then(@"User should see success estimation message")]
        public void ThenUserShouldSeeSuccessEstimationMessage()
        {
            CurrentPage.As<HandleRequestPage>().CheckSucessEstimatedMessage();
        }

    }
}
