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
    [Scope(Feature = "BookingV2")]
    public sealed class BookingV2Steps : BDDFixture
    {
        private static string requestId = null;

        [Given(@"User go to Travel Agency Handle Request Page")]
        public void GivenUserGoToTravelAgencyHandleRequestPage()
        {
            CurrentPage.GoTo<HandleRequestPage>();
        }

        [When(@"User Login with username and password")]
        public void WhenUserLoginWithUsernameAndPassword()
        {
            CurrentPage.As<LoginPage>().Login(Setting.UserName, Setting.Password);
        }

        [When(@"User select All tab")]
        public void WhenUserSelectAllTab()
        {
            CurrentPage.As<HandleRequestPage>().SelectAllTab();
        }

        [When(@"User select price button on request with status ""(.*)""")]
        public void WhenUserSelectPriceButtonOnRequestWithStatus(string status)
        {
            requestId = CurrentPage.As<HandleRequestPage>().GetFirstRequestIdByStatus(status);
            CurrentPage.As<HandleRequestPage>().SelectPriceButton(requestId);
        }

        [When(@"User fill all booking form info")]
        public void WhenUserFillAllBookingForm()
        {
            CurrentPage.As<HandleRequestPage>().BookRequestPendingOnSupplier(requestId);
        }

        [When(@"User select Send Booking Information button")]
        public void WhenUserSelectSendBookingInformationButton()
        {
            CurrentPage.As<HandleRequestPage>().SelectSendBookingInformationButton();
        }
        [Then(@"User should see success send booking information message")]
        public void ThenUserShouldSeeSuccessSendBookingInformationMessage()
        {
            
        }
        [When(@"User should see request status as ""(.*)""")]
        public void WhenUserShouldSeeRequestStatusAs(string status)
        {
            CurrentPage.As<HandleRequestPage>().CheckSuccessSendBookingInfoRequestStatus(requestId, status);
        }
        [Given(@"User fake authen as ""(.*)"" in Handle Request pages")]
        public void GivenUserFakeAuthenAsInHandleRequestPages(string user)
        {
            CurrentPage.As<HandleRequestPage>().FakeAuthento(user);
        }
        [When(@"User select Save Draft button")]
        public void WhenUserSelectSaveDraftButton()
        {
            CurrentPage.As<HandleRequestPage>().SelectSaveDraftButton();
        }






    }
}
