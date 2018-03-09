//using AQC.Implement;
//using OpenQA.Selenium;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using TechTalk.SpecFlow;
//using TravelAgencyTest.POM;

//namespace TravelAgencyTest.Stepdefs
//{
//    [Binding]
//    public sealed class TravelAgencyStepDefs : BDDFixture
//    {

//        [Given(@"User go to Travel Agency Create Page")]
//        public void GivenUserGoToTravelAgencyCreatePage()
//        {
            //CurrentPage.GoTo<CreatePage>();
//        }
//        [When(@"User Login with username and password")]
//        public void WhenUserLoginWithUsernameAndPassword()
//        {
//            CurrentPage.As<LoginPage>().Login(Setting.UserName, Setting.Password);
//        }
//        [Then(@"User should see Welcome message on create page")]
//        public void ThenUserShouldSeeWelcomeMessageOnCreatePage()
//        {
//            CurrentPage.As<CreatePage>().IsAtWelcomePage();
//        }
//        [Given(@"User fake authen as '(.*)' in Create Page")]       
//        [Given(@"User fake authen as ""(.*)"" in Create Page")]   
//        public void GivenUserFakeAuthenAsInCreatePage(string username)
//        {
//            CurrentPage.As<CreatePage>().FakeAuthento(username);
//        }
//        [When(@"Traveller select '(.*)', '(.*)' and '(.*)', '(.*)', '(.*)'")]
//        [When(@"Traveller select traveller as ""(.*)"", main transportation as ""(.*)"" and select carRental ""(.*)"", select Taxi ""(.*)"", Select Hotel ""(.*)""")]    
//        public void WhenTravellerSelectAnd(string traveller, string mainTransportation, string selectCarRental, string selectTaxi, string selectHotel)
//        {
//            CurrentPage.As<CreatePage>().SelectTraveller(traveller);
//            CurrentPage.As<CreatePage>().SelectTransportationAndSercices(mainTransportation, selectCarRental, selectTaxi, selectHotel);
//        }
//        [When(@"Traveller select Continue button")]
//        public void WhenTravellerSelectContinueButton()
//        {
//            CurrentPage.As<CreatePage>().SelectContinueButton();
//        }

//        [When(@"Traveller fill Start Date as '(.*)' and End Date as '(.*)'")] 
//        [When(@"Traveller fill Start Date as ""(.*)"" and End Date as ""(.*)""")]
//        public void WhenTravellerFillStartDateAsAndEndDateAs(string startDate, string endDate)
//        {
//            CurrentPage.As<CreatePage>().FillTravelDate(startDate, endDate);
//        }
//        [When(@"Traveller fill From Field '(.*)' and To Field '(.*)' if required")]
//        [When(@"Traveller fill From Field ""(.*)"" and To Field ""(.*)"" if required")]
//        public void WhenTravellerFillFromFieldAndToFieldIfRequired(string fromPlace, string toPlace)
//        {
//            CurrentPage.As<CreatePage>().FillFromAndToPlace(fromPlace, toPlace);
//        }
//        [When(@"Traveller select I'm in a hurry button")]
//        public void WhenTravellerSelectIMInAHurryButton()
//        {
//            CurrentPage.As<CreatePage>().SelectImInHurryButton();
//        }
//        [Then(@"Traveller should see Success request creation message with requestID")]        
//        public void ThenTravellerShouldSeeSuccessMessageWithRequestID()
//        {
//            CurrentPage.As<CreatePage>().CheckSucessCreateRequestMessage();
//            string requestId = CurrentPage.As<CreatePage>().GetRequestId();
//            ScenarioContext.Current.Add("requestId", requestId);
//            CurrentPage.As<CreatePage>().CheckRedirected();
//        }
//        [Given(@"User go to Travel Agency HandleRequest Page")]
//        public void GivenUserGoToTravelAgencyHandleRequestPage()
//        {
//            CurrentPage.GoTo<HandleRequestPage>();
//        }
//        [Given(@"User fake authen as '(.*)' in HandleRequest Page")]
//        public void GivenUserFakeAuthenAsInHandleRequestPage(string username)
//        {
//            CurrentPage.As<HandleRequestPage>().FakeAuthento(username);
//        }
//        [Then(@"TravelAllocator should see Pending On Allocation tab")]
//        public void ThenTravelAllocatorShouldSeePendingOnAllocationTab()
//        {
//            CurrentPage.As<HandleRequestPage>().CheckPendingOnAllocationTabVisibled();
//        }
//        [Given(@"TravelAllocator search by requestID")]
//        public void GivenTravelAllocatorSearchByRequestID()
//        {
//            string requestId = ScenarioContext.Current.Get<string>("requestId");
//            CurrentPage.As<HandleRequestPage>().SearchByRequestIdAllocationTab(requestId);
//        }
//        [Given(@"TravelAllocator allocate new request to '(.*)'")]
//        public void GivenTravelAllocatorAllocateNewRequestTo(string travelAgentName)
//        {
//            string requestId = ScenarioContext.Current.Get<string>("requestId");
//            CurrentPage.As<HandleRequestPage>().AllocatedRequest(requestId, travelAgentName);
//        }
//        [Then(@"TravelAllocator should see success allocated message with requestID")]
//        public void ThenTravelAllocatorShouldSeeSuccessAllocatedMessageWithRequestID()
//        {
//            string requestId = ScenarioContext.Current.Get<string>("requestId");
//            CurrentPage.As<HandleRequestPage>().CheckSucessAllocatedMessage(requestId);
//        }
//        [Given(@"TravelAgent select MyTasks tab")]
//        public void GivenTravelAgentSelectMyTasksTab()
//        {
//            CurrentPage.As<HandleRequestPage>().SelectMyTasksTab();
//        }
//        [Given(@"TravelAgent estimate travel request price")]
//        public void GivenTravelAgentEstimateTravelRequestPrice()
//        {
//            string requestId = ScenarioContext.Current.Get<string>("requestId");
//            CurrentPage.As<HandleRequestPage>().EstimatePrice(requestId);
//        }
//        [Then(@"TravelAgent should see success estimation message")]
//        public void ThenTravelAgentShouldSeeSuccessEstimationMessage()
//        {
//            CurrentPage.As<HandleRequestPage>().CheckSucessEstimatedMessage();
//        }
//        [Given(@"User go to TravelAgency MyTeam page")]
//        public void GivenUserGoToTravelAgencyMyTeamPage()
//        {
//            CurrentPage.GoTo<MyTeamPage>();
//        }
//        [Given(@"User fake authen as '(.*)' in MyTeam Page")]
//        public void GivenUserFakeAuthenAsInMyTeamPage(string user)
//        {
//            CurrentPage.As<MyTeamPage>().FakeAuthento(user);
//        }
//        [Given(@"User validate approve Travel request")]
//        public void GivenUserValidateApproveTravelRequest()
//        {
//            string requestId = ScenarioContext.Current.Get<string>("requestId");
//            CurrentPage.As<MyTeamPage>().ApprovedRequest(requestId);
//            CurrentPage.As<MyTeamPage>().CheckSucessApprovedMessage(requestId);
//        }
//        [Given(@"User go to Travel Agency ProposalDetails Page with RequestID")]
//        public void GivenUserGoToTravelAgencyProposalDetailsPage()
//        {
//            string requestId = ScenarioContext.Current.Get<string>("requestId");
//            CurrentPage.GoTo<ProposalDetailsPage>(Setting.BaseUrl + "TravelAgency/Proposal/Index/" + requestId);
//        }
//        [Given(@"User fake authen as '(.*)' in proposalDetails Page")]
//        public void GivenUserFakeAuthenAsInProposalDetailsPage(string user)
//        {
//            CurrentPage.As<ProposalDetailsPage>().FakeAuthento(user);
//        }
//        [Given(@"TravelAgent create Travel Proposals with info: '(.*)' , '(.*)', '(.*)' , '(.*)'")]        
//        public void GivenTravelAgentCreateTravelProposalWith(string from, string to, string startDate, string endDate)
//        {
//            string flightProposalId = CurrentPage.As<ProposalDetailsPage>().CreateFlightProposal();
//            CurrentPage.As<ProposalDetailsPage>().CreateFlightSegment(flightProposalId, startDate, endDate);
//            CurrentPage.As<ProposalDetailsPage>().CreateHotelProposal(startDate, endDate);
//            string taxiProposalId = CurrentPage.As<ProposalDetailsPage>().CreateTaxiProposal();
//            CurrentPage.As<ProposalDetailsPage>().CreateTaxiSegment(taxiProposalId, from, to);
//            CurrentPage.As<ProposalDetailsPage>().CreateTaxiSegment(taxiProposalId, from, to, "", "", true);
//            string carRentalProposalId = CurrentPage.As<ProposalDetailsPage>().CreateCarRentalProposal();
//            CurrentPage.As<ProposalDetailsPage>().CreateCarRentalSegment(carRentalProposalId, from, to);
//        }
//        [Then(@"TravelAgent can Choose proposal for Traveller")]        
//        public void GivenTravelAgentChooseProposalForTraveller()
//        {
//            CurrentPage.As<ProposalDetailsPage>().ChooseProposal();
//        }
//        [Given(@"TravelAgent open booking pop-up and book the request")]
//        public void GivenTravelAgentOpenBookingPop_UpAndBookTheRequest()
//        {
//            ScenarioContext.Current.Pending();
//        }
//        [Then(@"TravelAgent can send proposal Email to traveller")]
//        public void ThenTravelAgentCanSendProposalEmailToTraveller()
//        {
//            CurrentPage.As<ProposalDetailsPage>().SendProposalEmail();
//        }
//        [When(@"Traveller select Next button on second trip detail page")]
//        public void WhenTravellerSelectNextButtonOnSecondTripDetailPage()
//        {
//            CurrentPage.As<CreatePage>().SelectNextButton();
//        }        
//        [When(@"Traveller fill Trip detail: Hotel with location ""(.*)"", check in date as ""(.*)"", check out date as ""(.*)""")]
//        public void WhenTravellerFillTripDetailHotelWithLocationCheckInDateAsCheckOutDateAs(string location, string checkinDate, string checkoutDate)
//        {
//            CurrentPage.As<CreatePage>().FillHotelDetails(location, checkinDate, checkoutDate);
//        }
//        [When(@"Traveller fill Trip detail: Taxi detail")]
//        public void WhenTravellerFillTripDetailTaxiDetail()
//        {
//            CurrentPage.As<CreatePage>().FillTaxiDetails();
//        }
//        [When(@"Traveller fill Trip detail: Car Rental with pick-up ""(.*)"", drop-off ""(.*)"", outbound date ""(.*)"" and return date ""(.*)""")]
//        public void WhenTravellerFillTripDetailCarRentalWithPick_UpDrop_OffOutboundDateAndReturnDate(string pickupLocation, string dropLocation, string outboundDate, string returnDate)
//        {
//            CurrentPage.As<CreatePage>().FillCarRentalDetails(pickupLocation, dropLocation, outboundDate, returnDate);
//        }
//        [When(@"Traveller select Finish button")]
//        public void WhenTravellerSelectFinishButton()
//        {
//            CurrentPage.As<CreatePage>().SelectFinishButton();
//        }
//        [When(@"Traveller fill Trip detail: Flight with from ""(.*)"", to ""(.*)"", outbound ""(.*)"" and return ""(.*)""")]
//        public void WhenTravellerFillTripDetailFlightWithFromToOutboundAndReturn(string from, string to, string outboundDate, string returnDate)
//        {
//            CurrentPage.As<CreatePage>().FillFlightDetails(from, to, outboundDate, returnDate);
//        }

































//    }
//}
