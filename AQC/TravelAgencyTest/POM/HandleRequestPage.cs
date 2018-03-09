using AQC.Interface;
using AQC.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQC;
using System.Text.RegularExpressions;
using System.Globalization;

namespace TravelAgencyTest.POM
{
    class HandleRequestPage : BasePage
    {
        public HandleRequestPage(IFixture fixture) : base(fixture)
        {
        }

        public override string PageUrl => Setting.BaseUrl + "TravelAgency/handlerequest";
        #region Elements

        private By travellerProfileFormSaveButton = By.XPath("//form[@id='traveller-profile-form']//button[@id='btn-save']");
        private By PolicyFormCheckBox = By.XPath("//form[@id='accept-policy-form']//input[@type='checkbox']");
        private By PolicyFormConfirmButton = By.XPath("//form[@id='accept-policy-form']//button[@id='btn-Confirm']");
        private By userMenu = By.XPath("//li[@id='userMenu']/a");
        private By userMenuSearchField = By.XPath("//div[@class='select2-drop select2-display-none select2-with-searchbox select2-drop-active']/div/input");
        private By searchinglabel = By.XPath("//li[.='Searching…']");
        private By userMenuSearchFieldResultlabel = By.XPath("//div[@class='details-warper']");
        private By RequestTable = By.XPath("//table[@class='table table-dynamic table-hover table-striped req-tbl']");
        private By loaddingOverlay = By.XPath("//div[contains(@class,'blockUI blockOverlay')]");
        private By pendingOnAllocationTab = By.Id("PendingOnAllocation");
        private By searchByRequestIdField = By.Id("LightSearchIndividual");
        private By popupMessage = By.XPath("//p[@class='content']");
        private By usernameList = By.XPath("//ul[@role='listbox']/li");
        private By myTaskTab = By.XPath("id('MyTask')");
        private By flightModuleEstimatePrice = By.Id("FlightModule_EstimatedPrice");
        private By flightModuleEstimateCurrency = By.XPath("//div[contains(@id,'FlightModule_EstimatedCurrencyId')]/a/span[1]");
        private By trainModuleEstimatePrice = By.Id("TrainModule_EstimatedPrice");
        private By trainModuleEstimateCurrency = By.XPath("//div[contains(@id,'TrainModule_EstimatedCurrencyId')]/a/span[1]");
        private By taxiModuleEstimatePrice = By.Id("TaxiModule_EstimatedPrice");
        private By taxiModuleEstimateCurrency = By.XPath("//div[contains(@id,'TaxiModule_EstimatedCurrencyId')]/a/span[1]");
        private By hoteltModuleEstimatePrice = By.Id("HotelModule_EstimatedPrice");
        private By hotelModuleEstimateCurrency = By.XPath("//div[contains(@id,'HotelModule_EstimatedCurrencyId')]/a/span[1]");
        private By carRentalModuleEstimatePrice = By.Id("CarModule_EstimatedPrice");
        private By carRentalModuleEstimateCurrency = By.XPath("//div[contains(@id,'CarModule_EstimatedCurrencyId')]/a/span[1]");
        private By sendForValidationButton = By.Id("estimateSendBtn");
        private By allTab = By.XPath("//a[@id='MyTeam']");
        private By loadingOverlay = By.XPath("//div[@class='loadingoverlay']");
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
            foreach (var returnUsername in listUsername)
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
        public void CheckPendingOnAllocationTabVisibled()
        {
            WaitElementIsVisibled(pendingOnAllocationTab);
        }
        public void SearchByRequestIdAllocationTab(string requestID)
        {
            TypeText(searchByRequestIdField, requestID);
            PressEnter(searchByRequestIdField);
            WaitPageLoadReady();
        }
        public void AllocatedRequest(string travelAgentName, string requestId = null)
        {
            var firstAllocateButton = By.XPath(string.Format("id('RequestEmployeeId{0}')/td[2]/a[2]/i[1]", requestId));
            var secondAllocationButton = By.XPath(string.Format("//td[contains(text(),'{0}')]/preceding-sibling::td/form", travelAgentName));
            Click(firstAllocateButton);
            WaitPageLoadReady();
            Click(secondAllocationButton);
            WaitPageLoadReady();
        }
        public void AllocatedFirstRequest(string travelAgentName)
        {
            var listAllocatedButton = By.XPath("//i[@class='fa fa-gavel']");
            Click(Finds(listAllocatedButton)[0]);
            WaitPageLoadReady();
            var allocateFormLabel = By.XPath("//h4[contains(text(),'Allocate for Request: ')]");
            Assert.True(IsVisibled(allocateFormLabel));
            var secondAllocationButton = By.XPath(string.Format("//td[contains(text(),'{0}')]/preceding-sibling::td/form", travelAgentName));
            WaitPageLoadReady();
            Click(secondAllocationButton);
            WaitPageLoadReady();
        }
        public void CheckSucessAllocatedMessage(string requestId = "")
        {
            string message = GetText(popupMessage);
            if (!requestId.Equals(""))
            {
                Assert.IsTrue(message.Contains(string.Format("Request {0} allocated", requestId)));
                return;
            }
            Assert.IsTrue(message.Contains(string.Format("allocated")));

        }
        public void CheckSucessEstimatedMessage()
        {
            string message = GetText(popupMessage);
            bool isSuccess = message.Contains(string.Format("The estimation will be sent to traveler's manager")) || message.Contains(string.Format("Estimation edited successfully !"));
            Assert.IsTrue(isSuccess);
        }
        public void SelectMyTasksTab()
        {
            Click(myTaskTab);
            WaitElementIsInvisibled(loaddingOverlay);
        }
        public void SelectAllTab()
        {
            Click(allTab);
            WaitElementIsInvisibled(loaddingOverlay);
        }
        public string GetFirstRequestIdByStatus(string status)
        {
            var listStatusLabel = By.XPath(string.Format("//td[@class='State' and contains(text(),'{0}')]", status));
            string requestId = null;
            foreach (var element in Finds(listStatusLabel))
            {
                if(GetText(element).Equals(status))
                {
                    string ajaxReloadActionLink = element.GetAttribute("data-ajax-reload-action");
                    LogInfo(ajaxReloadActionLink);
                    requestId = Regex.Match(ajaxReloadActionLink, @"\d+").Value;
                    break;
                }
            }
            return requestId;
        }
        public string GetRequestIdWithFlightNotStarted(string status)
        {
            var listStatusLabel = By.XPath(string.Format("//td[@class='State' and contains(text(),'{0}')]", status));
            foreach (var element in Finds(listStatusLabel))
            {
                string ajaxReloadActionLink = element.GetAttribute("data-ajax-reload-action");
                string requestId = Regex.Match(ajaxReloadActionLink, @"\d+").Value;
                var flightLabel = By.XPath(string.Format("//tr[@id='RequestEmployeeId{0}']//img[contains(@src,'travel_flight')]", requestId));
                var startDateLabel = By.XPath(string.Format("//tr[@id='RequestEmployeeId{0}']//td[7]", requestId));
                string currentDate = DateTime.Today.ToString("dd/MM/yyyy");
                if (IsVisibled(flightLabel) && (DateTime.ParseExact(GetText(startDateLabel),"d/M/yyyy", CultureInfo.InvariantCulture) >= DateTime.ParseExact(currentDate, "d/M/yyyy", CultureInfo.InvariantCulture)))
                {
                    return requestId;
                }
            }
            LogWarning(string.Format("No request found with status {0}, flight service , startdate bigger than today... return requestId = null", status));
            return null;
        }
        public void SelectViewRequestDetailButton(string requestId)
        {
            var viewDetailButton = By.XPath(string.Format("id('RequestEmployeeId{0}')/td[1]/a[1]/i[1]", requestId));
            Click(viewDetailButton);            
            SwitchToTab(1);
            WaitPageLoadReady();
        }
        public void SelectEstimatePrice(string requestId)
        {
            var estimateButton = By.XPath(string.Format("id('RequestEmployeeId{0}')//i[@class='fa fa-money']", requestId));
            Click(estimateButton);
            WaitPageLoadReady();
            
        }
        public void EstimatePrice(string requestId, string flightPrice = "50", string trainPrice = "50", string hotelPrice = "50", string taxiPrice = "50", string carRentalPrice = "50", string currency = "EUR")
        {
            var estimatePriceForm = By.XPath(string.Format("//h4[contains(text(),'Price estimation for Request Id: {0}')]", requestId));
            Assert.True(IsVisibled(estimatePriceForm));
            if (IsVisibled(flightModuleEstimatePrice))
            {
                FillEstimate(flightModuleEstimatePrice, flightModuleEstimateCurrency, flightPrice, currency);
            }
            if (IsVisibled(trainModuleEstimatePrice))
            {
                FillEstimate(trainModuleEstimatePrice, trainModuleEstimateCurrency, trainPrice, currency);
            }
            if (IsVisibled(hoteltModuleEstimatePrice))
            {
                FillEstimate(hoteltModuleEstimatePrice, hotelModuleEstimateCurrency, hotelPrice, currency);
            }
            if (IsVisibled(taxiModuleEstimatePrice))
            {
                FillEstimate(taxiModuleEstimatePrice, taxiModuleEstimateCurrency, taxiPrice, currency);
            }
            if (IsVisibled(carRentalModuleEstimatePrice))
            {
                FillEstimate(carRentalModuleEstimatePrice, carRentalModuleEstimateCurrency, carRentalPrice, currency);
            }
            WaitPageLoadReady();
            
        }
        public void SelectSendForValidationButton()
        {
            Click(sendForValidationButton);
        }
        private void FillEstimate(By priceInput, By currencyInput, string price, string currency)
        {
            var inputSearchField = By.XPath("id('select2-drop')/div/input");
            ClearAndTypeText(priceInput, price);
            Click(currencyInput);
            ClearAndTypeText(inputSearchField, currency);
            WaitElementIsInvisibled(searchinglabel);
            PressEnter(inputSearchField);
        }
        public void OpenRequestDetailPage(string requestId)
        {
            var requestDetailEyeButton = By.XPath(string.Format("id('RequestEmployeeId{0}')/td[1]/a[1]/i[1]", requestId));
            Click(requestDetailEyeButton);
        }
        public void SelectPriceButton(string requestId)
        {
            var priceButton = By.XPath(string.Format("//tr[@id='RequestEmployeeId{0}']//i[@class='fa fa-dollar']", requestId));
            Click(priceButton);
            
            WaitElementIsInvisibled(loadingOverlay);
        }
        private void FillFlightBookingForm()
        {
            var AmadeusLabel = By.XPath("//h4[contains(text(),'Amadeus')]");
            if (IsVisibled(AmadeusLabel))
            {
                var baseFareInput = By.XPath("//label[.='Base Fare']/following-sibling::input");
                ClearAndTypeText(baseFareInput, "50");
                var taxesInput = By.XPath("//label[.='Taxes']/following-sibling::input");
                ClearAndTypeText(taxesInput, "10");
                var commissionInput = By.XPath("//label[.='Commission']/following-sibling::input");
                ClearAndTypeText(commissionInput, "10");
                var issueDateInput = By.XPath("//label[.='Issued Date']/following-sibling::div/input[1]");
                ClearAndTypeText(issueDateInput, string.Format(DateTime.Now.ToShortDateString()));
                var ticketNumberInput = By.XPath("//label[.='Ticket Number']/following-sibling::input");
                ClearAndTypeText(ticketNumberInput, "Automate");
                var agentPNRInput = By.XPath("//label[.='Agent PNR']/following-sibling::input");
                ClearAndTypeText(agentPNRInput, "Automate");
                var airlinePNRInput = By.XPath("//label[.='Airline PNR']/following-sibling::input");
                ClearAndTypeText(airlinePNRInput, "Automate");
            }
            else
            {
                //var totalCostInput = By.XPath("//label[.='Total Cost']/following-sibling::input");
                //ClearAndTypeText(totalCostInput, "50");
                var priceInput = By.XPath("//label[.='Price (VAT Incl.)']/following-sibling::input");
                ClearAndTypeText(priceInput, "50");
                var supplierReferenceInput = By.XPath("//label[.='Supplier Reference']/following-sibling::input");
                ClearAndTypeText(supplierReferenceInput, "Automate");
                var bookingReference = By.XPath("//label[.='Booking Reference']/following-sibling::input");
                ClearAndTypeText(bookingReference, "Automate");
                var terminalInput = By.XPath("//label[.='Terminal']/following-sibling::input");
                ClearAndTypeText(terminalInput, "Automate");
                var seatInput = By.XPath("//label[.='Seat']/following-sibling::input");
                ClearAndTypeText(seatInput, "Automate");
            }
        }
        private void FillHotelBookingForm()
        {
            var priceInput = By.XPath("//div[contains(@id,'book-panel-Hotel-')]//label[.='Price (VAT Incl.)']/following-sibling::input");
            ClearAndTypeText(priceInput, "50");
            var bookingReferenceInput = By.XPath("//div[contains(@id,'book-panel-Hotel-')]//label[.='Booking Reference']/following-sibling::input");
            ClearAndTypeText(bookingReferenceInput, "Automated");
        }
        private void FillTaxiBookingForm()
        {
            var priceInput = By.XPath("//div[contains(@id,'book-panel-Taxi-')]//label[.='Price (VAT Incl.)']/following-sibling::input");
            ClearAndTypeText(priceInput, "50");
            var supplierReferenceInput = By.XPath("//div[contains(@id,'book-panel-Taxi-')]//label[.='Supplier Reference']/following-sibling::input");
            ClearAndTypeText(supplierReferenceInput, "Automate");
            var bookingReferenceInput = By.XPath("//div[contains(@id,'book-panel-Taxi-')]//label[.='Booking Reference']/following-sibling::input");
            ClearAndTypeText(bookingReferenceInput, "Automated");
        }
        private void FillTrainBookingForm()
        {
            var priceInput = By.XPath("//div[contains(@id,'book-panel-Train-')]//label[.='Price (VAT Incl.)']/following-sibling::input");
            ClearAndTypeText(priceInput, "50");
            var supplierReferenceInput = By.XPath("//div[contains(@id,'book-panel-Train-')]//label[.='Supplier Reference']/following-sibling::input");
            ClearAndTypeText(supplierReferenceInput, "Automate");
            var bookingReferenceInput = By.XPath("//div[contains(@id,'book-panel-Train-')]//label[.='Booking Reference']/following-sibling::input");
            ClearAndTypeText(bookingReferenceInput, "Automated");
            var compartmentInput = By.XPath("//div[contains(@id,'book-panel-Train-')]//label[.='Compartment']/following-sibling::input");
            ClearAndTypeText(compartmentInput, "Automate");
            var seatInput = By.XPath("//div[contains(@id,'book-panel-Train-')]//label[.='Seat']/following-sibling::input");
            ClearAndTypeText(seatInput, "Automate");
        }
        private void FillCarRentalBookingForm()
        {
            var priceInput = By.XPath("//div[contains(@id,'book-panel-CarRental-')]//label[.='Price (VAT Incl.)']/following-sibling::input");
            ClearAndTypeText(priceInput, "50");
            var bookingReferenceInput = By.XPath("//div[contains(@id,'book-panel-CarRental-')]//label[.='Booking Reference']/following-sibling::input");
            ClearAndTypeText(bookingReferenceInput, "Automated");
        }
        public void BookRequestPendingOnSupplier(string requestId)
        {
            var flightTab = By.XPath("//li[contains(@class,'bknav-itm bnav-fly')]/a/i");
            if (IsVisibled(flightTab))
            {
                Click(flightTab);
                FillFlightBookingForm();
            }
            var hotelTab = By.XPath("//li[contains(@class,'bknav-itm bnav-hotel')]/a");
            if (IsVisibled(hotelTab))
            {
                Click(hotelTab);
                FillHotelBookingForm();
            }
            var carRentalTab = By.XPath("//li[contains(@class,'bknav-itm bnav-carRental')]");
            if (IsVisibled(carRentalTab))
            {
                Click(carRentalTab);
                FillCarRentalBookingForm();
            }
            var taxiTab = By.XPath("//li[contains(@class,'bknav-itm bnav-taxi')]");
            if (IsVisibled(taxiTab))
            {
                Click(taxiTab);
                FillTaxiBookingForm();
            }
            var trainTab = By.XPath("//li[contains(@class,'bknav-itm bnav-train')]");
            if (IsVisibled(trainTab))
            {
                Click(trainTab);
                FillTrainBookingForm();
            }
        }
        public void SelectSendBookingInformationButton()
        {
            var sendOutLookEvent = By.XPath("//button[contains(text(),'Send Booking Information')]");
            Click(sendOutLookEvent);
            WaitElementIsInvisibled(loadingOverlay);
        }
        public void CheckSuccessSendBookingInfoRequestStatus(string requestId, string status)
        {
            var statuslabel = By.XPath(string.Format("id('RequestEmployeeId{0}')/td[4]", requestId));            
            Assert.AreEqual(status, GetText(statuslabel));
        }
        public void SelectSaveDraftButton()
        {
            var saveDraftButton = By.XPath("//button[.='Save Draft']");
            Click(saveDraftButton);
        }
        public void SelectBookUnfinishedRequestFilter()
        {
            var bookUnfinishedRequestLabel = By.XPath("//label[@for='Request_Booked']");
            Click(bookUnfinishedRequestLabel);
            WaitElementIsInvisibled(loaddingOverlay);
        }
        public void SelectRequestPendingOnTravellerFilter()
        {
            var requestPendingOnTravellerLabel = By.XPath("//label[@for='Request_Estimated_ProposalCreated']");
            Click(requestPendingOnTravellerLabel);
            WaitPageLoadReady();
        }
    }
}
