using AQC.Demo;
using AQC.Interface;
using AQC.Page;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TravelAgencyTest.POM
{
    public class CreatePage : BasePage
    {           
        public CreatePage(IFixture fixture) : base(fixture)
        {
        }
        public override string PageUrl => Setting.BaseUrl + "TravelAgency/create";
        #region Elements
        private By travellerProfileFormSaveButton = By.XPath("//form[@id='traveller-profile-form']//button[@id='btn-save']");
        private By PolicyFormCheckBox = By.XPath("//form[@id='accept-policy-form']//input[@type='checkbox']");
        private By PolicyFormConfirmButton = By.XPath("//form[@id='accept-policy-form']//button[@id='btn-Confirm']");
        private By userMenu = By.XPath("//li[@id='userMenu']/a");
        private By userMenuSearchField = By.XPath("//div[@class='select2-drop select2-display-none select2-with-searchbox select2-drop-active']/div/input");
        private By searchinglabel = By.XPath("//li[.='Searching…']");
        private By userMenuSearchFieldResultlabel = By.XPath("//div[@class='details-warper']");
        private By loaddingOverlay = By.XPath("//div[@class='blockUI blockMsg blockPage']");
        private By welcomelabel = By.XPath("//h2[contains(text(),'Welcome back')]");
        private By planeRadio = By.XPath("id('radio_Flight')/following-sibling::div");
        private By trainRadio = By.XPath("id('radio_Train')/following-sibling::div");
        private By anyTransportRadio = By.XPath("id('radio_any_Transport')/following-sibling::div");
        private By carRentalCheckbox = By.XPath("id('checkBox_CarRental')/following-sibling::div");
        private By taxiCheckbox = By.XPath("id('checkBox_Taxi')/following-sibling::div");
        private By hotelCheckBox = By.XPath("id('checkBox_Hotel')/following-sibling::div");
        private By startDateField = By.XPath("//div[@id='FromDateTimeAllModule']/input[1]");
        private By endDateField = By.XPath("//div[@id='ToDateTimeAllModule']/input[1]");
        private By flightFromPlace = By.XPath("//div[@id='s2id_FromAirportPlace']/a/span");
        private By transportFromPlace = By.XPath("//div[@id='s2id_FromTransportationPlace']/a/span");
        private By flightToPlace = By.XPath("//div[@id='s2id_ToAirportPlace']/a/span");
        private By transportToPlace = By.XPath("//div[@id='s2id_ToTransportationPlace']/a/span");
        private By hotelPlace = By.XPath("//div[@id='s2id_HotelLocation']/a/span[1]");
        private By searchField = By.XPath("//input[@class='select2-input select2-focused']");
        private By imHurryButton = By.XPath("//button[@id='btnSubmitWithoutInformation']");
        private By popupMessage = By.XPath("//p[@class='content']");
        private By usernameList = By.XPath("//ul[@role='listbox']/li");
        private By searchInput = By.XPath("//div[@id='select2-drop']//input");
        #endregion
        public void FakeAuthento(string username)
        {
            if (IsVisibled(travellerProfileFormSaveButton)) Click(travellerProfileFormSaveButton); WaitPageLoadReady();
            if (IsVisibled(PolicyFormCheckBox)) { Click(PolicyFormCheckBox); Click(PolicyFormConfirmButton); WaitPageLoadReady(); }
            username = username.ToLower();
            WaitPageLoadReady();
            string currentUser = GetText(userMenu).ToLower();
            if (currentUser.Contains(username))
            {
                return;
            }
            Click(userMenu);
            TypeText(userMenuSearchField, username);
            WaitElementIsInvisibled(searchinglabel);
            List<IWebElement> listUsername = Finds(usernameList);
            foreach(var returnUsername in listUsername)
            {
                if (GetText(returnUsername).ToLower().Contains(username))
                {
                    Click(returnUsername);
                    break;
                }
            }      
            
            WaitPageLoadReady();
            if (IsVisibled(travellerProfileFormSaveButton)) Click(travellerProfileFormSaveButton); WaitPageLoadReady();
            if (IsVisibled(PolicyFormCheckBox)) { Click(PolicyFormCheckBox); Click(PolicyFormConfirmButton); WaitPageLoadReady(); }
        }
        public bool IsAtWelcomePage()
        {
            Assert.True(GetText(welcomelabel).Contains("Welcome back"));
            return true;
        }
        public void SelectMainTransportation(string mainTranportation)
        {
            mainTranportation = mainTranportation.ToLower();
            switch (mainTranportation)
            {
                case "plane":
                    Click(planeRadio);
                    break;
                case "train":
                    Click(trainRadio);
                    break;
                case "anytransport":
                    Click(anyTransportRadio);
                    break;
                default:
                    break;
            }
        }
        public void SelectCarRental()
        {
            Click(carRentalCheckbox);
        }
        public void SelectTaxi()
        {
            Click(taxiCheckbox);
        }
        public void SelectHotel()
        {
            Click(hotelCheckBox);
        }
        
        public void FillTravelDate(string startDate, string endDate)
        {
            ClearAndTypeText(startDateField, startDate);
            ClearAndTypeText(endDateField, endDate); 
        }
        public void FillFromAndToPlace(string fromPlace = null, string toPlace = null)
        {
            if (IsVisibled(flightFromPlace))
            {
                Click(flightFromPlace);
                TypeText(searchField, fromPlace);
                WaitElementIsInvisibled(searchinglabel);
                PressEnter(searchField);
                Click(flightToPlace);
                TypeText(searchField, toPlace);
                WaitElementIsInvisibled(searchinglabel);
                PressEnter(searchField);
            }
            else if (IsVisibled(transportFromPlace))
            {
                Click(transportFromPlace);
                TypeText(searchField, fromPlace);
                WaitElementIsInvisibled(searchinglabel);
                PressEnter(searchField);                
                Click(transportToPlace);
                TypeText(searchField, toPlace);
                WaitElementIsInvisibled(searchinglabel);
                PressEnter(searchField);
            }
            else if(IsVisibled(hotelPlace))
            {
                Click(hotelPlace);
                TypeText(searchField, fromPlace);
                WaitElementIsInvisibled(searchinglabel);
                Click(searchinglabel);
                PressEnter(searchField);
            }
        }
        public void SelectImInHurryButton()
        {
            Click(imHurryButton);
        }
        public void SelectContinueButton()
        {
            var continueButton = By.XPath("//button[@id='btnNextFirstPage']");
            Click(continueButton);
            WaitPageLoadReady();
        }
        public void CheckSucessCreateRequestMessage()
        {
            string message = GetText(popupMessage);
            Assert.IsTrue(message.ToLower().Contains("successfully"));
        }
        public string GetRequestId()
        {
            string message = GetText(popupMessage);
            string requestID = Regex.Match(message, @"\d+").Value;            
            return requestID;
        }
        public void CheckRedirected()
        {
            RefreshPage();
            WaitPageLoadReady();
        }
        public void SelectTraveller(string traveller)
        {
            traveller = traveller.ToLower();
            var alternativeTravellerInput = By.XPath("//div[@id='s2id_AlternativeTravelerIds']//input");
            var alternativeTravellerField = By.XPath("//div[@id='s2id_AlternativeTravelerIds']/a/span");
            if (!IsVisibled(alternativeTravellerField))
            {
                TypeText(alternativeTravellerInput, traveller);
                WaitElementIsInvisibled(searchinglabel);
                PressEnter(alternativeTravellerInput);
                WaitPageLoadReady();
            }
        }
        public void SelectNextButton()
        {
            Wait(3000);
            var nextButton = By.XPath("//div[@id='2page_FlightModule']//b[.='Next']");
            Click(nextButton);
            WaitPageLoadReady();
        }
        public void FillHotelDetails(string location = "", string checkinDate = "", string checkoutDate = "")
        {
            var hotelIcon = By.XPath("//i[@class='fa fa-hotel font21']");
            if (!IsVisibled(hotelIcon)) return;
            Click(hotelIcon);
            WaitPageLoadReady();
            var locationField = By.XPath("//div[@id='s2id_HotelRequestModule_HotelCityId']//span[@class='select2-chosen']");
            if (!location.Equals(""))
            {
                Click(locationField);
                ClearAndTypeText(searchInput, location);
                WaitElementIsInvisibled(searchinglabel);
                PressEnter(searchInput);
            }
            var checkoutDateInput = By.XPath("//div[@id='HotelRequestModule_ToDate']/input[@class='datepickerinput form-control']");
            if (!checkoutDate.Equals(""))
            {
                ClearAndTypeText(checkoutDateInput, checkoutDate);
            }
            var checkinDateInput = By.XPath("//div[@id='HotelRequestModule_FromDate']/input[@class='datepickerinput form-control']");
            if (!checkinDate.Equals(""))
            {
                ClearAndTypeText(checkinDateInput, checkinDate);
            }
            
        }
        public void FillTaxiDetails()
        {            
            var taxiLabel = By.XPath("//i[@class='fa fa-taxi font21']");
            var outboundFromAirportRadio = By.XPath("//input[@id='radio_outboundTaxi_Airport']/following-sibling::div");
            var outboundToAirportRadio = By.XPath("//input[@id='radio_outboundToTaxi_Airport']/following-sibling::div");
            var returnFromAirportRadio = By.XPath("//input[@id='radio_returnTaxi_Airport']/following-sibling::div");
            var returnToAirportRadio = By.XPath("//input[@id='radio_returnToTaxi_Airport']/following-sibling::div");
            if (!IsVisibled(taxiLabel))
            {
                return;
            }
            Click(taxiLabel);
            WaitPageLoadReady();
            Wait(2000);
            Click(outboundFromAirportRadio);
            Click(outboundToAirportRadio);
            if (IsVisibled(returnFromAirportRadio))
            {
                Click(returnFromAirportRadio);
                Click(returnToAirportRadio);
            }
        }
        public void FillCarRentalDetails(string pickupLocation, string dropoffLocation, string outbounDate, string returnDate)
        {
            var carRentalLabel = By.XPath("//i[@class='fa fa-car font21']");
            var pickupField = By.XPath("//div[@id='s2id_CarRentalRequestModule_GoFromPlace']//span[.='Select a location']");
            var dropoffField = By.XPath("//div[@id='s2id_CarRentalRequestModule_GoToPlace']//span[.='Select a location']");
            var outboundDateInput = By.XPath("//div[@id='CarRentalRequestModule_FromDate']//input[@class='datepickerinput form-control']");
            var returnDateInput = By.XPath("//div[@id='CarRentalRequestModule_ToDate']//input[@class='datepickerinput form-control']");
            if (!IsVisibled(carRentalLabel))
            {
                return;
            }
            Click(carRentalLabel);
            WaitPageLoadReady();
            Click(pickupField);
            TypeText(searchInput, pickupLocation);
            WaitElementIsInvisibled(searchinglabel);
            PressEnter(searchInput);
            Click(dropoffField);
            TypeText(searchInput, dropoffLocation);
            WaitElementIsInvisibled(searchinglabel);
            PressEnter(searchInput);
            ClearAndTypeText(returnDateInput, returnDate);
            ClearAndTypeText(outboundDateInput, outbounDate);
            var commentArea = By.XPath("//textarea[@id='CarRentalRequestModule_Comment']");
            Click(commentArea);
            
        }
        public void SelectFinishButton()
        {
            var finishButton = By.XPath("//b[.='Finish']");
            Click(finishButton);
        }
        public void FillFlightDetails(string from, string to, string outboundDate , string returnDate)
        {
            var flightLabel = By.XPath("//i[@class='fa fa-plane font21']");
            if (!IsVisibled(flightLabel)) return;
            Click(flightLabel);
            WaitPageLoadReady();

            var fromField = By.XPath("//div[@id='s2id_FlightRequestModule_FlightFromId']//span[@class='select2-chosen']");
            Click(fromField);
            TypeText(searchInput, from);
            WaitElementIsInvisibled(searchinglabel);
            PressEnter(searchInput);

            var toField = By.XPath("//div[@id='s2id_FlightRequestModule_FlightToId']//span[@class='select2-chosen']");
            Click(toField);
            TypeText(searchInput, to);
            WaitElementIsInvisibled(searchinglabel);
            PressEnter(searchInput);

            var returnDateInput = By.XPath("//div[@id='FlightRequestModule_ToDateDate']//input[@class='datepickerinput form-control']");
            ClearAndTypeText(returnDateInput, returnDate);

            var outboundDateInput = By.XPath("//div[@id='FlightRequestModule_FromDateDate']//input[@class='datepickerinput form-control']");
            ClearAndTypeText(outboundDateInput, outboundDate);

            
        }
    }
}
