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
    [Scope (Feature = "RequestManagement")]
    public sealed class RequestManagementSteps : BDDFixture
    {
        [Given(@"User go to Travel Agency Handle Request page")]
        public void GivenUserGoToTravelAgencyHandleRequestPage()
        {
            CurrentPage.GoTo<HandleRequestPage>();
            //Helper.Listener(By.XPath("//form[@id='traveller-profile-form']//button[@id='btn-save']"));
            //Helper.Listener(By.XPath("//form[@id='accept-policy-form']//input[@type='checkbox']"));
            //Helper.Listener(By.XPath("//form[@id='accept-policy-form']//button[@id='btn-Confirm']"));
        }


        [When(@"User Login with username and password")]
        public void WhenUserLoginWithUsernameAndPassword()
        {
            CurrentPage.As<LoginPage>().Login(Setting.UserName, Setting.Password);
        }

        [Given(@"User fake authen as ""(.*)"" on Handle Request page")]
        public void GivenUserFakeAuthenAsOnHandleRequestPage(string user)
        {
            CurrentPage.As<HandleRequestPage>().FakeAuthento(user);
        }

        [Given(@"User select All tab")]
        public void GivenUserSelectAllTab()
        {
            CurrentPage.As<HandleRequestPage>().SelectAllTab();
        }

        [Given(@"User select view detail button on request has status ""(.*)""")]
        public void GivenUserSelectViewDetailButtonOnRequestHasStatus(string status)
        {
            string requestId = CurrentPage.As<HandleRequestPage>().GetFirstRequestIdByStatus(status);
            CurrentPage.As<HandleRequestPage>().SelectViewRequestDetailButton(requestId);
        }

        [Given(@"User fake authen as Traveller")]
        public void GivenUserFakeAuthenAsTraveller()
        {
            string userName = CurrentPage.As<RequestDetailsPage>().GetTravellerName();
            CurrentPage.As<RequestDetailsPage>().FakeAuthento(userName);
        }

        [When(@"User select options for Flight if required")]
        public void WhenUserSelectOptionsForFlightIfRequired()
        {
            CurrentPage.As<RequestDetailsPage>().SelectFlightOption();
        }

        [When(@"User select options for Train if required")]
        public void WhenUserSelectOptionsForTrainIfRequired()
        {
            CurrentPage.As<RequestDetailsPage>().SelectTrainOption();
        }

        [When(@"User select options for Taxi if required")]
        public void WhenUserSelectOptionsForTaxiIfRequired()
        {
            CurrentPage.As<RequestDetailsPage>().SelectTaxiOption();
        }

        [When(@"User select options for Car Rental if required")]
        public void WhenUserSelectOptionsForCarRentalIfRequired()
        {
            CurrentPage.As<RequestDetailsPage>().SelectCarRentalOption();
        }

        [When(@"User select options for Hotel required")]
        public void WhenUserSelectOptionsForHotelRequired()
        {
            CurrentPage.As<RequestDetailsPage>().SelectHotelOption();
        }

        [Given(@"User select Submit selection button")]
        public void GivenUserSelectSubmitSelectionButton()
        {
            CurrentPage.As<RequestDetailsPage>().SelectSubmitSelection();
        }

        [Then(@"User should see Success update proposal message")]
        public void ThenUserShouldSeeSuccessUpdateProposalMessage()
        {
            CurrentPage.As<RequestDetailsPage>().CheckSuccessUpdateProposalMessage();
        }

        [Then(@"Request status should be ""(.*)""")]
        public void ThenRequestStatusShouldBe(string status)
        {
            CurrentPage.As<RequestDetailsPage>().CheckRequestStatus(status);
        }
        [Given(@"User select Request pending on traveller/manager progress bar")]
        public void GivenUserSelectRequestPendingOnTravellerManagerProgressBar()
        {
            CurrentPage.As<HandleRequestPage>().SelectRequestPendingOnTravellerFilter();
        }



    }
}
