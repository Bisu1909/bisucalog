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
    [Scope(Feature = "ProposalManagement")]
    public sealed class ProposalManagementSteps : BDDFixture
    {
        private static string requestId = null;
        private static string proposalId = null;

        [Given(@"User go to Travel Agency Handle Request Page")]
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
        [Given(@"User fake authen as ""(.*)"" in Handle Request page")]
        [When(@"User fake authen as ""(.*)"" in HandleRequest Page")]
        public void WhenUserFakeAuthenAsInHandleRequestPage(string user)
        {
            CurrentPage.As<HandleRequestPage>().FakeAuthento(user);
        }       

        [When(@"User select All tab")]
        [Given(@"User select All tab")]
        public void WhenUserSelectAllTab()
        {
            CurrentPage.As<HandleRequestPage>().SelectAllTab();
        }
        [Given(@"User select view detail button on request has status ""(.*)""")]
        public void GivenUserSelectViewDetailButtonOnRequestHasStatus(string status)
        {
            string requestId = CurrentPage.As<HandleRequestPage>().GetFirstRequestIdByStatus(status);
            CurrentPage.As<HandleRequestPage>().SelectViewRequestDetailButton(requestId);
        }

        [Given(@"User select manage proposals button on request detail page")]
        public void GivenUserSelectManageProposalsButtonOnRequestDetailPage()
        {
            CurrentPage.As<RequestDetailsPage>().SelectManageProposalsButton();
        }

        [Then(@"User shoud see request in status ""(.*)"" in proposal Detail page")]
        public void ThenUserShoudSeeRequestInStatusInProposalDetailPage(string status)
        {
            CurrentPage.As<ProposalDetailsPage>().CheckRequestStatus(status);
        }

        [Given(@"User create flight proposal if required: Supplier ""(.*)"", price ""(.*)"", start date as today \+ (.*), end date as today \+ (.*)")]
        public void GivenUserCreateFlightProposalIfRequiredSupplierPriceStartDateAsTodayEndDateAsToday(string supplier, string price, int startDayPlus, int endDayPlus)
        {
            string proposalId = CurrentPage.As<ProposalDetailsPage>().CreateFlightProposal(supplier, price);
            string startDate = DateTime.Today.AddDays(startDayPlus).ToString("dd/MM/yyyy");
            string endDate = DateTime.Today.AddDays(endDayPlus).ToString("dd/MM/yyyy");
            CurrentPage.As<ProposalDetailsPage>().CreateFlightSegment(proposalId, startDate, endDate);
        }

        [Given(@"User create Hotel proposal if required: Price ""(.*)"", checkin as today \+ (.*), checkout as today \+ (.*)")]
        public void GivenUserCreateHotelProposalIfRequiredPriceCheckinAsTodayCheckoutAsToday(string price, int checkinDayPlus, int checkoutDayPlus)
        {
            string startDate = DateTime.Today.AddDays(checkinDayPlus).ToString("dd/MM/yyyy");
            string endDate = DateTime.Today.AddDays(checkoutDayPlus).ToString("dd/MM/yyyy");
            CurrentPage.As<ProposalDetailsPage>().CreateHotelProposal(startDate, endDate, price);
        }
        [Given(@"User create Car rental proposal if required: Supplier ""(.*)"", price ""(.*)"", from ""(.*)"", to ""(.*)"", start date as today \+ (.*), end date as today \+ (.*)")]
        public void GivenUserCreateCarRentalProposalIfRequiredSupplierPriceFromToStartDateAsTodayEndDateAsToday(string supplier, string price, string from, string to, int startDayPlus, int endDayPlus)
        {
            string startDate = DateTime.Today.AddDays(startDayPlus).ToString("dd/MM/yyyy");
            string endDate = DateTime.Today.AddDays(endDayPlus).ToString("dd/MM/yyyy");
            string proposalId = CurrentPage.As<ProposalDetailsPage>().CreateCarRentalProposal(supplier, price);
            CurrentPage.As<ProposalDetailsPage>().CreateCarRentalSegment(proposalId, from, to, startDate, endDate);
        }
        [Given(@"User create Taxi proposal if required: Supplier ""(.*)"", price ""(.*)"", from ""(.*)"", to ""(.*)"", start date as today \+ (.*), end date as today \+ (.*)")]
        public void GivenUserCreateTaxiProposalIfRequiredSupplierPriceFromToStartDateAsTodayEndDateAsToday(string supplier, string price, string from, string to, int startDayPlus, int endDayPlus)
        {
            string startDate = DateTime.Today.AddDays(startDayPlus).ToString("dd/MM/yyyy");
            string endDate = DateTime.Today.AddDays(endDayPlus).ToString("dd/MM/yyyy");
            string proposalId = CurrentPage.As<ProposalDetailsPage>().CreateTaxiProposal(supplier, price);
            CurrentPage.As<ProposalDetailsPage>().CreateTaxiSegment(proposalId, from, to, startDate, endDate);
        }
        [Given(@"User create Train proposal if required: Supplier ""(.*)"", price ""(.*)"", from ""(.*)"", to ""(.*)"", start date as today \+ (.*), end date as today \+ (.*)")]
        public void GivenUserCreateTrainProposalIfRequiredSupplierPriceFromToStartDateAsTodayEndDateAsToday(string supplier, string price, string from, string to, int startDayPlus, int endDayPlus)
        {
            string startDate = DateTime.Today.AddDays(startDayPlus).ToString("dd/MM/yyyy");
            string endDate = DateTime.Today.AddDays(endDayPlus).ToString("dd/MM/yyyy");
            string proposalId = CurrentPage.As<ProposalDetailsPage>().CreateTrainProposal(supplier, price);
            CurrentPage.As<ProposalDetailsPage>().CreateTrainSegment(proposalId, from, to, startDate, endDate);
        }


        [Given(@"User select Send Proposal Email button")]
        public void GivenUserSelectSendProposalEmailButton()
        {
            CurrentPage.As<ProposalDetailsPage>().SelectSendProposalEmail();
        }

        [Then(@"User should see success send proposal message")]
        public void ThenUserShouldSeeSuccessSendProposalMessage()
        {
            CurrentPage.As<ProposalDetailsPage>().CheckEmailSentSuccessMessage();
        }
        [Given(@"User select Booked but unfinished requests progress bar")]
        public void GivenUserSelectBookedButUnfinishedRequestsProgressBar()
        {
            CurrentPage.As<HandleRequestPage>().SelectBookUnfinishedRequestFilter();
        }

        [Given(@"User select view detail on request has status ""(.*)"", has flight proposal and start date not passed current date")]
        public void GivenUserSelectViewDetailOnRequestHasStatusHasFlightProposalAndStartDateNotPassedCurrentDate(string status)
        {
            requestId = CurrentPage.As<HandleRequestPage>().GetRequestIdWithFlightNotStarted(status);
            CurrentPage.As<HandleRequestPage>().SelectViewRequestDetailButton(requestId);
        }

        [Given(@"User select Change button on Booked flight proposal")]
        public void GivenUserSelectChangeButtonOnFlightProposal()
        {
            proposalId = CurrentPage.As<ProposalDetailsPage>().OpenChangePopupBookedFlightRequest();
        }
        [When(@"User fill Change reason, fill Additional cost as (.*) on flight change proposal pop-up")]
        public void WhenUserFillChangeReasonFillAdditionalCostAsOnFlightChangeProposalPop_Up(string additionalCost)
        {
            CurrentPage.As<ProposalDetailsPage>().FillChangePopup(additionalCost);
        }
        [When(@"User select Change proposal button")]
        public void WhenUserSelectChangeProposalButton()
        {
            CurrentPage.As<ProposalDetailsPage>().SelectChangeProposalButton();
        }
        [Then(@"User should see Success change request message")]
        public void ThenUserShouldSeeSuccessChangeRequestMessage()
        {
            CurrentPage.As<ProposalDetailsPage>().CheckSuccessChangeRequestMessage();
        }
        [Then(@"User should see status ""(.*)"" on flight proposal")]
        public void ThenUserShouldSeeStatusOnFlightProposal(string status)
        {            
            CurrentPage.As<ProposalDetailsPage>().CheckStatusOfFlightProposal(proposalId, status);
        }
        [Then(@"User should see status ""(.*)"" on all flight segments")]
        public void ThenUserShouldSeeStatusOnAllFlightSegments(string status)
        {
            CurrentPage.As<ProposalDetailsPage>().CheckStatusOfFlightSegments(proposalId, status);
        }
        [When(@"User select Create Proposal For Changes button")]
        public void WhenUserSelectCreateProposalForChangesButton()
        {
            CurrentPage.As<ProposalDetailsPage>().SelectCreateProposalForChanges(proposalId);
        }
        [Then(@"User should see Success add transport proposal message")]
        public void ThenUserShouldSeeSuccessAddTransportProposalMessage()
        {
            CurrentPage.As<ProposalDetailsPage>().CheckSuccessCreateProposalForChangesMessage();
        }
        [Then(@"User should see status ""(.*)"" on newly created flight proposal")]
        public void ThenUserShouldSeeStatusOnNewlyCreatedFlightProposal(string status)
        {
            proposalId = CurrentPage.As<ProposalDetailsPage>().GetNewFlightProposalId();
            CurrentPage.As<ProposalDetailsPage>().CheckStatusOfFlightProposal(proposalId, status);
        }
        [Then(@"User should see status ""(.*)"" on newly created flight segments")]
        public void ThenUserShouldSeeStatusOnNewlyCreatedFlightSegments(string status)
        {
            CurrentPage.As<ProposalDetailsPage>().CheckStatusOfFlightSegments(proposalId, status);
        }







    }
}
