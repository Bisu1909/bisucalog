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
    [Scope(Feature = "TravelRequestCreation")]
    public sealed class TravelRequestCreationSteps : BDDFixture
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
        [Given(@"User fake authen as ""(.*)"" in Create Page")]
        public void GivenUserFakeAuthenAsInCreatePage(string user)
        {
            CurrentPage.As<CreatePage>().FakeAuthento(user);
        }

        [When(@"Traveller select traveller ""(.*)""")]
        public void WhenTravellerSelectTraveller(string user)
        {
            CurrentPage.As<CreatePage>().SelectTraveller(user);
        }

        [When(@"Traveller select main transportation as ""(.*)""")]
        public void WhenTravellerSelectMainTransportationAs(string maintransportation)
        {
            CurrentPage.As<CreatePage>().SelectMainTransportation(maintransportation);
        }

        [When(@"Traveller select other services as CarRental")]
        public void WhenTravellerSelectOtherServicesAsCarRental()
        {
            CurrentPage.As<CreatePage>().SelectCarRental();
        }
        [When(@"Traveller select other services as Taxi")]
        public void WhenTravellerSelectOtherServicesAsTaxi()
        {
            CurrentPage.As<CreatePage>().SelectTaxi();
        }
        [When(@"Traveller select other services as Hotel")]
        public void WhenTravellerSelectOtherServicesAsHotel()
        {
            CurrentPage.As<CreatePage>().SelectHotel();
        }
        [When(@"Traveller fill Start Date as today \+ 5 and End Date as today \+ 10")]
        public void WhenTravellerFillStartDateAsTodayAndEndDateAsToday()
        {
            string startDate = DateTime.Today.AddDays(5).ToString("dd/MM/yyyy");
            string endDate = DateTime.Today.AddDays(10).ToString("dd/MM/yyyy");
            CurrentPage.As<CreatePage>().FillTravelDate(startDate, endDate);
        }
        [When(@"Traveller fill From Field ""(.*)"" and To Field ""(.*)""")]
        public void WhenTravellerFillFromFieldAndToField(string from, string to)
        {
            CurrentPage.As<CreatePage>().FillFromAndToPlace(from, to);
        }

        [When(@"Traveller select I'm in a hurry button")]
        public void WhenTravellerSelectIMInAHurryButton()
        {
            CurrentPage.As<CreatePage>().SelectImInHurryButton();
        }

        [Then(@"Traveller should see Success request creation message with requestID")]
        public void ThenTravellerShouldSeeSuccessRequestCreationMessageWithRequestID()
        {
            CurrentPage.As<CreatePage>().CheckSucessCreateRequestMessage();
            CurrentPage.As<CreatePage>().CheckRedirected();
        }

        [When(@"Traveller select Continue button")]
        public void WhenTravellerSelectContinueButton()
        {
            CurrentPage.As<CreatePage>().SelectContinueButton();
        }

        [When(@"Traveller fill Trip detail: Flight from ""(.*)"", to ""(.*)"", outbound  as today \+ 5 and return as today \+ 10")]
        public void WhenTravellerFillTripDetailFlightFromToOutboundAsTodayAndReturnAsToday(string from, string to)
        {
            string startDate = DateTime.Today.AddDays(5).ToString("dd/MM/yyyy");
            string endDate = DateTime.Today.AddDays(10).ToString("dd/MM/yyyy");
            CurrentPage.As<CreatePage>().FillFlightDetails(from, to, startDate, endDate);
        }
        [When(@"Traveller fill Trip detail: Hotel location ""(.*)"", check in date as today \+ 5, check out date as today \+ 10")]
        public void WhenTravellerFillTripDetailHotelLocationCheckInDateAsTodayCheckOutDateAsToday(string location)
        {
            string startDate = DateTime.Today.AddDays(5).ToString("dd/MM/yyyy");
            string endDate = DateTime.Today.AddDays(10).ToString("dd/MM/yyyy");
            CurrentPage.As<CreatePage>().FillHotelDetails(location, startDate, endDate);
        }
        [When(@"Traveller fill Trip detail: Taxi detail")]
        public void WhenTravellerFillTripDetailTaxiDetail()
        {
            CurrentPage.As<CreatePage>().FillTaxiDetails();
        }

        [When(@"Traveller fill Trip detail: Car Rental with pick-up ""(.*)"", drop-off ""(.*)"", outbound date as today \+ 5 and return as today \+ 10")]
        public void WhenTravellerFillTripDetailCarRentalWithPick_UpDrop_OffOutboundDateAsTodayAndReturnAsToday(string pickupLocation, string dropoffLocation)
        {
            string startDate = DateTime.Today.AddDays(5).ToString("dd/MM/yyyy");
            string endDate = DateTime.Today.AddDays(10).ToString("dd/MM/yyyy");
            CurrentPage.As<CreatePage>().FillCarRentalDetails(pickupLocation, dropoffLocation, startDate, endDate);
        }


        [When(@"Traveller select Finish button")]
        public void WhenTravellerSelectFinishButton()
        {
            CurrentPage.As<CreatePage>().SelectFinishButton();
            WaitManager.Wait(10000);
        }

    }
}
