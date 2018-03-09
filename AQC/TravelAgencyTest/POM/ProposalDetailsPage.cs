using AQC.Interface;
using AQC.Page;
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
    class ProposalDetailsPage : BasePage
    {
        public ProposalDetailsPage(IFixture fixture) : base(fixture)
        {
        }
        public override string PageUrl => Setting.BaseUrl + "TravelAgency/Proposal/Index/";
        #region element
        private By travellerProfileFormSaveButton = By.XPath("//form[@id='traveller-profile-form']//button[@id='btn-save']");
        private By PolicyFormCheckBox = By.XPath("//form[@id='accept-policy-form']//input[@type='checkbox']");
        private By PolicyFormConfirmButton = By.XPath("//form[@id='accept-policy-form']//button[@id='btn-Confirm']");
        private By newTransportProposalButton = By.XPath("//a[@id='addNewTransportProposalV2']");
        private By newHotelProposalButton = By.XPath("//a[@id='addNewHotelProposalV2']");
        private By supplierField = By.XPath("//div[contains(@id,'OneSupplierViewModel_OneSupplierStrId')]/a/span[1]");
        private By searchInput = By.XPath("id('select2-drop')/div/input");
        private By searchingLabel = By.XPath("//li[.='Searching…']");
        private By sameAsSupplierCheckbox = By.XPath("//label[@for='OneSupplierViewModel_OneSupplierProposal_SameSupplier']");
        private By totalPriceField = By.XPath("id('OneSupplierViewModel_OneSupplierProposal_PriceModel_TotalPrice')");
        private By createButton = By.Id("createNewTransportProposalButtonV2");
        private By chooseProposalButton = By.XPath("//button[.='Choose Proposal']");
        private By popupMessage = By.XPath("//p[@class='content']");
        private By flightNoField = By.XPath("id('SegmentModel_SegmentInformations_0__IdentificationNumber')");
        private By nextSegmentButton = By.XPath("//button[@name='SubmitToNext']");
        private By fromDateInput = By.XPath("//input[@placeholder='From Date']");
        private By toDateInput = By.XPath("//input[@placeholder='To Date']");
        private By finishSegmentButton = By.XPath("//button[@name='SubmitToFinish']");
        private By newHotelSupplierButton = By.XPath("id('createNewHotelButtonV2')");
        private By newHotelNameInput = By.Id("newHotelSupplierId");
        private By countryField = By.XPath("//div[@id='s2id_HotelInformation_CountryId']/a/span[1]");
        private By cityField = By.Id("s2id_HotelInformation_CityId");
        private By validateHotelButton = By.Id("createNewHotelAgreeButtonV2");
        private By nextHotelProposalButton = By.Id("nextToHotelProposalButtonV2");
        private By checkinDateInput = By.XPath("//input[@placeholder='Checkin']");
        private By checkoutDateInput = By.XPath("//input[@placeholder='Checkout']");
        private By totalPriceInput = By.Id("HotelBookingOptions_TotalPrice");
        private By hotelCurrencyField = By.XPath("//div[@id='s2id_HotelBookingOptions_Currency']/a/span[1]");
        private By createHotelProposalButton = By.Id("createNewHotelProposalButtonV2");
        private By airlineLabel = By.XPath("//h2[.='Airline']");
        private By hotelLabel = By.XPath("//h2[.='Hotel']");
        private By taxiLabel = By.XPath("//h2[.='Taxi']");
        private By carRentalLabel = By.XPath("//h2[.='Car Rental']");
        private By transportTypeField = By.XPath("//div[@id='s2id_TransportTypeId']/a/span[1]");
        private By transportTypeResultList = By.XPath("//div[@id='select2-drop']/ul/li/div");
        private By carRentalCompanyField = By.XPath("//div[@id='s2id_Segment_TransportCompanyId']/a/span[.='Company']");
        private By carRentalIdentityInput = By.XPath("//input[@value='CarRental']/following-sibling::div/input");
        private By carRentalFromField = By.XPath("//span[.='From']");
        private By carRentalVendorField = By.XPath("//div[@id='s2id_SupplierStrId']/a/span[.='Vendor']");
        private By carRentalToField = By.XPath("//span[.='To']");
        private By loaddingOverlay = By.XPath("//div[contains(@class,'blockUI blockMsg')]");
        private By userMenu = By.XPath("//li[@id='userMenu']/a");
        private By userMenuSearchField = By.XPath("//div[@class='select2-drop select2-display-none select2-with-searchbox select2-drop-active']/div/input");
        private By usernameList = By.XPath("//ul[@role='listbox']/li");
        #endregion
        public void FakeAuthento(string username)
        {
            username = username.ToLower();
            WaitPageLoadReady();
            if (IsVisibled(travellerProfileFormSaveButton)) Click(travellerProfileFormSaveButton); WaitPageLoadReady();
            if (IsVisibled(PolicyFormCheckBox)) { Click(PolicyFormCheckBox); Click(PolicyFormConfirmButton); WaitPageLoadReady(); }
            string currentUser = GetText(userMenu).ToLower();
            if (currentUser.Contains(username))
            {
                return;
            }
            Click(userMenu);
            TypeText(userMenuSearchField, username);
            WaitElementIsInvisibled(searchingLabel);
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
        public string CreateFlightProposal(string supplier = "Amadeus", string totalPrice = "50")
        {
            if (!(IsVisibled(airlineLabel)))
            {
                LogInfo("Skipping Airline proposal creation ....");
                return null;
            }
            ScrollToTop();
            Click(newTransportProposalButton);
            int i = 0;
            while (GetText(transportTypeField).Equals(" "))
            {
                Wait(200);
                i += 200;
                if (i >= Setting.ImplicitWaitInmilliseconds) break;
            }
            Click(transportTypeField);
            WaitElementIsInvisibled(searchingLabel);
            WaitElementIsVisibled(transportTypeResultList);
            foreach (var element in Finds(transportTypeResultList))
            {
                if (GetText(element).Equals("Flight"))
                {
                    Click(element);
                    break;
                }
            }
            Click(supplierField);
            TypeText(searchInput, supplier);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
            Click(sameAsSupplierCheckbox);
            TypeText(totalPriceField, totalPrice);
            Click(createButton);
            string message = GetText(popupMessage);
            Assert.IsTrue(message.Contains("Transport proposal was added successfully."));
            //To get newly created flight proposal ID
            return GetNewFlightProposalId();
        }
        public string GetNewFlightProposalId()
        {
            WaitPageLoadReady();
            var ProposalId = By.XPath("//h2[contains(text(),'Airline')]/../../..//span[contains(text(),'New')]/../../../../parent::div[contains(@id,'TravelProposal')]");
            WaitElementIsVisibled(ProposalId);
            string proposalId = Finds(ProposalId).Last().GetAttribute("id");
            proposalId = Regex.Match(proposalId, @"\d+").Value;
            return proposalId;
        }
        public void CreateFlightSegment(string proposalId, string fromDate, string toDate, string fromCity = "Singapore", string toCity = "zurich")
        {
            if (!(IsVisibled(airlineLabel)))
            {
                LogInfo("Skipping Airline segments creation ....");
                return;
            }
            MoveMouseToElement(newTransportProposalButton);
            var newSegmentButton = By.XPath(string.Format("//div[@id='TravelProposal{0}']//a[@id='addNewTransportSegmentV2']", proposalId));
            Click(newSegmentButton);
            WaitPageLoadReady();
            TypeText(flightNoField, "Automated test flight");

            var fromTimeZoneOutbound = By.XPath("//div[@id='s2id_FromTimeZone_Outbound_1']//span[@class='select2-chosen']");
            Click(fromTimeZoneOutbound);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
            var toTimeZoneOutbound = By.XPath("//div[@id='s2id_ToTimeZone_Outbound_1']//span[@class='select2-chosen']");
            Click(toTimeZoneOutbound);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
            var fromCityField = By.XPath("//div[@id='s2id_SegmentModel_SegmentInformations[0]_FromDestination_DestinationStrId']/a");
            if (GetText(fromCityField) == "")
            {
                Click(fromCityField);
                TypeText(searchInput, fromCity);
                WaitElementIsInvisibled(searchingLabel);
                PressEnter(searchInput);
            }
            var toCityField = By.XPath("//div[@id='s2id_SegmentModel_SegmentInformations[0]_ToDestination_DestinationStrId']/a");
            if (GetText(toCityField) == "")
            {
                Click(toCityField);
                TypeText(searchInput, toCity);
                WaitElementIsInvisibled(searchingLabel);
                PressEnter(searchInput);
            }
            WaitPageLoadReady();
            ClearAndTypeText(fromDateInput, fromDate);
            ClearAndTypeText(toDateInput, fromDate);

            if (IsVisibled(nextSegmentButton))
            {
                Click(nextSegmentButton);
                WaitPageLoadReady();
                TypeText(flightNoField, "Automated test flight");
                if (GetText(fromCityField) == "")
                {
                    Click(fromCityField);
                    TypeText(searchInput, fromCity);
                    WaitElementIsInvisibled(searchingLabel);
                    PressEnter(searchInput);
                }
                if (GetText(toCityField) == "")
                {
                    Click(toCityField);
                    TypeText(searchInput, toCity);
                    WaitElementIsInvisibled(searchingLabel);
                    PressEnter(searchInput);
                }

                if (GetText(fromCityField) == "")
                {
                    Click(fromCityField);
                    TypeText(searchInput, fromCity);
                    WaitElementIsInvisibled(searchingLabel);
                    PressEnter(searchInput);
                }
                if (GetText(toCityField) == "")
                {
                    Click(toCityField);
                    TypeText(searchInput, toCity);
                    WaitElementIsInvisibled(searchingLabel);
                    PressEnter(searchInput);
                }
                var fromTimeZoneReturn = By.XPath("//div[@id='s2id_FromTimeZone_Return_1']//span[@class='select2-chosen']");
                Click(fromTimeZoneReturn);
                WaitElementIsInvisibled(searchingLabel);
                PressEnter(searchInput);
                var toTimeZoneReturn = By.XPath("//div[@id='s2id_ToTimeZone_Return_1']//span[@class='select2-chosen']");
                Click(toTimeZoneReturn);
                WaitElementIsInvisibled(searchingLabel);
                PressEnter(searchInput);
                ClearAndTypeText(fromDateInput, toDate);
                ClearAndTypeText(toDateInput, toDate);
                WaitPageLoadReady();
            }
            Click(finishSegmentButton);
            string result = GetText(popupMessage);
            Assert.IsTrue(result.Equals("Segment was created successfully."));
            WaitElementIsVisibled(By.XPath(string.Format("//div[contains(@id,'TravelProposal{0}')]//div[@class='segmentsListContainer']//span[contains(text(),'New')]", proposalId)));
            WaitPageLoadReady();
        }
        public void CreateTrainSegment(string proposalId, string fromCity, string toCity, string fromDate, string toDate)
        {
            var trainLabel = By.XPath("//h2[.=' Train']");
            if (!(IsVisibled(trainLabel)))
            {
                LogInfo("Skipping Train segment creation ....");
                return;
            }
            var newSegmentButton = By.XPath(string.Format("//div[@id='TravelProposal{0}']//a[@id='addNewTransportSegmentV2']", proposalId));
            Click(newSegmentButton);
            WaitPageLoadReady();
            var trainNoField = By.XPath("id('SegmentModel_SegmentInformations_0__IdentificationNumber')");
            TypeText(trainNoField, "Automated test train");
            
            var fromTimeZoneOutbound = By.XPath("//div[@id='s2id_FromTimeZone_Outbound_1']//span[@class='select2-chosen']");
            Click(fromTimeZoneOutbound);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
            var toTimeZoneOutbound = By.XPath("//div[@id='s2id_ToTimeZone_Outbound_1']//span[@class='select2-chosen']");
            Click(toTimeZoneOutbound);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
            var fromCityField = By.XPath("//div[@id='s2id_SegmentModel_SegmentInformations[0]_FromDestination_DestinationStrId']/a");
            if(GetText(fromCityField) == "")
            {
                Click(fromCityField);
                TypeText(searchInput, fromCity);
                WaitElementIsInvisibled(searchingLabel);
                PressEnter(searchInput);
            }
            var toCityField = By.XPath("//div[@id='s2id_SegmentModel_SegmentInformations[0]_ToDestination_DestinationStrId']/a");
            if (GetText(toCityField) == "")
            {
                Click(toCityField);
                TypeText(searchInput, toCity);
                WaitElementIsInvisibled(searchingLabel);
                PressEnter(searchInput);
            }
            ClearAndTypeText(fromDateInput, fromDate);
            ClearAndTypeText(toDateInput, fromDate);
            if (IsVisibled(nextSegmentButton))
            {
                Click(nextSegmentButton);
                WaitPageLoadReady();
                TypeText(flightNoField, "Automated test flight");
                
                if (GetText(fromCityField) == "")
                {
                    Click(fromCityField);
                    TypeText(searchInput, fromCity);
                    WaitElementIsInvisibled(searchingLabel);
                    PressEnter(searchInput);
                }                
                if (GetText(toCityField) == "")
                {
                    Click(toCityField);
                    TypeText(searchInput, toCity);
                    WaitElementIsInvisibled(searchingLabel);
                    PressEnter(searchInput);
                }
                
                var fromTimeZoneReturn = By.XPath("//div[@id='s2id_FromTimeZone_Return_1']//span[@class='select2-chosen']");
                Click(fromTimeZoneReturn);
                WaitElementIsInvisibled(searchingLabel);
                PressEnter(searchInput);
                var toTimeZoneReturn = By.XPath("//div[@id='s2id_ToTimeZone_Return_1']//span[@class='select2-chosen']");
                Click(toTimeZoneReturn);
                WaitElementIsInvisibled(searchingLabel);
                PressEnter(searchInput);
                ClearAndTypeText(fromDateInput, toDate);
                ClearAndTypeText(toDateInput, toDate);

            }
            Click(finishSegmentButton);
            string result = GetText(popupMessage);
            Assert.IsTrue(result.Equals("Segment was created successfully."));
            WaitElementIsVisibled(By.XPath(string.Format("//div[contains(@id,'TravelProposal{0}')]//div[@class='segmentsListContainer']//span[contains(text(),'New')]", proposalId)));
            WaitPageLoadReady();

        }
        public string CreateTrainProposal(string supplier = "train", string totalPrice = "50")
        {
            var trainLabel = By.XPath("//h2[.=' Train']");
            if (!(IsVisibled(trainLabel)))
            {
                LogInfo("Skipping Train proposal creation ....");
                return null;
            }
            ScrollToTop();
            Click(newTransportProposalButton);
            int i = 0;
            while (GetText(transportTypeField).Equals(" "))
            {
                Wait(200);
                i += 200;
                if (i >= Setting.ImplicitWaitInmilliseconds) break;
            }
            Click(transportTypeField);
            WaitElementIsInvisibled(searchingLabel);
            WaitElementIsVisibled(transportTypeResultList);
            foreach (var element in Finds(transportTypeResultList))
            {
                if (GetText(element).Equals("Train"))
                {
                    Click(element);
                    break;
                }
            }
            Click(supplierField);
            TypeText(searchInput, supplier);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
            Click(sameAsSupplierCheckbox);
            TypeText(totalPriceField, totalPrice);
            Click(createButton);
            string message = GetText(popupMessage);
            Assert.IsTrue(message.Contains("Transport proposal was added successfully.") || message.Contains("Please take note that the proposed price is higher than the approved estimation"));
            //To get newly created flight proposal ID
            return GetNewTrainProposalId();
        }
        
        public string GetNewTrainProposalId()
        {
            WaitPageLoadReady();
            var ProposalId = By.XPath("//h2[contains(text(),'Train')]/../../..//span[contains(text(),'New')]/../../../../parent::div[contains(@id,'TravelProposal')]");
            WaitElementIsVisibled(ProposalId);
            string proposalId = Finds(ProposalId).Last().GetAttribute("id");
            proposalId = Regex.Match(proposalId, @"\d+").Value;
            return proposalId;
        }
        
        public void CreateHotelProposal(string checkinDate, string checkoutDate, string totalPrice = "50", string currency = "EUR")
        {
            if (!(IsVisibled(hotelLabel)))
            {
                LogInfo("Hotel Label not found! Skipping Hotel proposal creation ....");
                return;
            }
            ScrollToTop();
            Click(newHotelProposalButton);
            WaitPageLoadReady();
            Click(newHotelSupplierButton);
            TypeText(newHotelNameInput, "AutomateHotel");
            Click(countryField);
            TypeText(searchInput, "Singapore");
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
            Click(cityField);
            TypeText(searchInput, "Singapore");
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
            Click(validateHotelButton);
            WaitPageLoadReady();
            Click(nextHotelProposalButton);
            WaitPageLoadReady();
            ClearAndTypeText(checkinDateInput, checkinDate);
            ClearAndTypeText(checkoutDateInput, checkoutDate);
            TypeText(totalPriceInput, totalPrice);
            Click(hotelCurrencyField);
            TypeText(searchInput, currency);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
            var timeZoneField = By.XPath("//div[@id='s2id_HotelBookingOptions_TimeZoneId']//span[@class='select2-chosen']");
            Click(timeZoneField);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
            Click(createHotelProposalButton);
            string result = GetText(popupMessage);
            Assert.AreEqual("Hotel proposal was added successfully.", result);
            WaitPageLoadReady();
            RefreshPage();
        }
        public string CreateTaxiProposal(string supplier = "taxi", string totalPrice = "50")
        {
            if (!(IsVisibled(taxiLabel)))
            {
                LogInfo("Skipping Taxi proposal creation ....");
                return null;
            }
            ScrollToTop();
            Click(newTransportProposalButton);
            int i = 0;
            while (GetText(transportTypeField).Equals(" "))
            {
                Wait(200);
                i += 200;
                if (i >= Setting.ImplicitWaitInmilliseconds) break;
            }
            Click(transportTypeField);
            WaitElementIsInvisibled(searchingLabel);
            foreach (var element in Finds(transportTypeResultList))
            {
                if (GetText(element).Equals("Taxi"))
                {
                    Click(element);
                    break;
                }
            }
            Click(supplierField);
            TypeText(searchInput, supplier);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
            Click(sameAsSupplierCheckbox);
            TypeText(totalPriceField, totalPrice);
            Click(createButton);
            string message = GetText(popupMessage);
            Assert.IsTrue(message.Contains("Transport proposal was added successfully."));
            //To get newly created taxi proposal ID
            var ProposalId = By.XPath("//h2[contains(text(),'Taxi')]/" +
                "../..//span[contains(text(),'New')]/../../../../parent::div[contains(@id,'TravelProposal')]");
            WaitElementIsVisibled(ProposalId);
            string proposalId = Finds(ProposalId).Last().GetAttribute("id");
            proposalId = Regex.Match(proposalId, @"\d+").Value;
            WaitElementIsInvisibled(popupMessage);
            return proposalId;
        }
        public void CreateTaxiSegment(string proposalId, string from, string to, string fromDate = "", string toDate = "", bool isReturned = false)
        {
            if (string.IsNullOrEmpty(proposalId)) return;
            WaitPageLoadReady();

            ScrollToTop();
            var newSegmentButton = By.XPath(string.Format("//div[@id='TravelProposal{0}']//button[contains(@class,'newSegmentButton')]", proposalId));
            Click(newSegmentButton);
            WaitElementIsInvisibled(loaddingOverlay);

            if (isReturned)
            {
                var isReturnCheck = By.XPath(string.Format("//div[@id='TravelProposal{0}']//input[@class='IsReturn']", proposalId));
                Click(isReturnCheck);
                WaitElementIsInvisibled(loaddingOverlay);
            }
            var companyField = By.XPath(string.Format("//div[@id='TravelProposal{0}']//span[.='Company']", proposalId));
            ScrollToElement(By.XPath(string.Format("//div[@id='TravelProposal{0}']//h3[.='Segment']", proposalId)));
            Click(companyField);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);

            var vendorField = By.XPath(string.Format("//div[@id='TravelProposal{0}']//span[.='Vendor']", proposalId));
            Click(vendorField);
            TypeText(searchInput, "taxi");
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);

            var identityInput = By.XPath(string.Format("//div[@id='TravelProposal{0}']//input[@placeholder='Identification Number']", proposalId));
            TypeText(identityInput, "Automated test");

            var fromField = By.XPath(string.Format("//div[@id='TravelProposal{0}']//span[.='From']", proposalId));
            Click(fromField);
            TypeText(searchInput, from);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);

            var toField = By.XPath(string.Format("//div[@id='TravelProposal{0}']//span[.='To']", proposalId));
            Click(toField);
            TypeText(searchInput, to);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);

            var taxiSegmentSaveButton = By.XPath(string.Format("//div[@id='TravelProposal{0}']//button[.='Save']", proposalId));
            WaitPageLoadReady();
            Click(taxiSegmentSaveButton);
            string message = GetText(popupMessage);
            Assert.IsTrue(message.Contains("Segment was created successfully."));
            WaitElementIsInvisibled(popupMessage);
            WaitPageLoadReady();
        }
        public string CreateCarRentalProposal(string supplier = "cab", string totalPrice = "50")
        {
            if (!(IsVisibled(carRentalLabel)))
            {
                LogInfo("Car Rental label not found! Skipping Car Rental proposal creation ....");
                return null;
            }
            ScrollToTop();
            Click(newTransportProposalButton);
            int i = 0;
            while (GetText(transportTypeField).Equals(" "))
            {
                Wait(200);
                i += 200;
                if (i >= Setting.ImplicitWaitInmilliseconds) break;
            }
            Click(transportTypeField);
            WaitElementIsInvisibled(searchingLabel);
            foreach (var element in Finds(transportTypeResultList))
            {
                if (GetText(element).Equals("Car Rental"))
                {
                    Click(element);
                    break;
                }
            }
            Click(supplierField);
            TypeText(searchInput, supplier);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
            Click(sameAsSupplierCheckbox);
            TypeText(totalPriceField, totalPrice);
            Click(createButton);
            string message = GetText(popupMessage);
            Assert.IsTrue(message.Contains("Transport proposal was added successfully."));
            //To get newly created car Rental proposal ID
            var ProposalId = By.XPath("//h2[contains(text(),'Car Rental')]/../../..//span[contains(text(),'New')]/../../../../parent::div[contains(@id,'TravelProposal')]");
            WaitElementIsVisibled(ProposalId);
            string proposalId = Finds(ProposalId).Last().GetAttribute("id");
            proposalId = Regex.Match(proposalId, @"\d+").Value;
            return proposalId;
        }
        public void CreateCarRentalSegment(string proposalId, string from, string to, string fromDate = "", string toDate = "")
        {
            if (string.IsNullOrEmpty(proposalId)) return;
            ScrollToTop();
            var newSegmentButton = By.XPath(string.Format("//div[@id='TravelProposal{0}']//button[contains(@class,'newSegmentButton')]", proposalId));
            Click(newSegmentButton);
            WaitElementIsInvisibled(loaddingOverlay);

            var companyField = By.XPath(string.Format("//div[@id='TravelProposal{0}']//span[.='Company']", proposalId));
            Click(companyField);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);

            var vendorField = By.XPath(string.Format("//div[@id='TravelProposal{0}']//span[.='Vendor']", proposalId));
            Click(vendorField);
            TypeText(searchInput, "car");
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);

            var IdentityInput = By.XPath(string.Format("//div[@id='TravelProposal{0}']//input[@id='Segment_IdentificationNumber']", proposalId));
            TypeText(IdentityInput, "Automated test");

            var fromField = By.XPath(string.Format("//div[@id='TravelProposal{0}']//span[.='From']", proposalId));
            Click(fromField);
            TypeText(searchInput, from);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);

            var toField = By.XPath(string.Format("//div[@id='TravelProposal{0}']//span[.='To']", proposalId));
            Click(toField);
            TypeText(searchInput, to);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);

            WaitPageLoadReady();
            var carRentalSaveButton = By.XPath(string.Format("//div[@id='TravelProposal{0}']//button[.='Save']", proposalId));
            Click(carRentalSaveButton);

            string message = GetText(popupMessage);
            Assert.IsTrue(message.Contains("Segment was created successfully."));
            WaitElementIsInvisibled(popupMessage);
        }
        public void ChooseProposal()
        {
            WaitPageLoadReady();
            ScrollToTop();
            Click(chooseProposalButton);
            string message = GetText(popupMessage);
            Assert.AreEqual("Update selected proposals successfully.", message);
            WaitPageLoadReady();
        }
        public void SelectSendProposalEmail()
        {
            var sendProposalEmailButton = By.XPath("//button[@value='Send Proposal Email']");
            WaitPageLoadReady();
            ScrollToTop();
            Click(sendProposalEmailButton);

        }
        public void CheckEmailSentSuccessMessage()
        {
            string message = GetText(popupMessage);
            Assert.AreEqual("Your proposal email has been successfully sent.", message);
            WaitPageLoadReady();
        }
        public void CheckRequestStatus(string status)
        {
            WaitPageLoadReady();
            RefreshPage();
            var statusLabel = By.XPath("//span[@id='RequestStateLabel']");
            string actualStatus = GetText(statusLabel);
            //actualStatus = Regex.Replace(actualStatus, @"\s+", "");
            Assert.AreEqual(status, actualStatus);
        }
        public string OpenChangePopupBookedFlightRequest()
        {
            var changeButton = By.XPath("//h2[.='Airline']/../../..//a[@id='changeValidatedProposalV2']");
            string temp = Find(changeButton).GetAttribute("href");
            Click(changeButton);
            string prefix = "&proposalId=";
            string afterfix = "&optionIndex=";
            int startIndex = temp.IndexOf(prefix) + prefix.Length;
            int endIndex = temp.IndexOf(afterfix);
            return temp.Substring(startIndex, endIndex - startIndex);
        }
        public void FillChangePopup(string additionalCost)
        {
            var reasonInput = By.XPath("//input[@id='Reason']");
            ClearAndTypeText(reasonInput, "Automated");
            var additionalCostInput = By.XPath("//input[@placeholder='Amount (VAT Incl.)']");
            if (!IsVisibled(additionalCostInput)) return;
            ClearAndTypeText(additionalCostInput, additionalCost);
        }
        public void SelectChangeProposalButton()
        {
            var changeProposalButton = By.XPath("//button[@name='SubmitToValidate']");
            Click(changeProposalButton);
        }
        public void CheckSuccessChangeRequestMessage()
        {
            string actualMessage = GetText(popupMessage);
            string expectMessage = "Validate proposal change request successfully. You can now click on \"Create Proposal For Changes\" for traveller to choose the proposed changes.";
            Assert.AreEqual(expectMessage, actualMessage);
        }
        public void CheckStatusOfFlightProposal(string proposalId, string status)
        {
            var statusLabel = By.XPath(string.Format("//div[@id='TravelProposal{0}']//small[@id='ProposalStatus']/span", proposalId));
            string actualStatus = GetText(statusLabel);
            Assert.AreEqual(status, actualStatus);
        }
        public void CheckStatusOfFlightSegments(string proposalId, string status)
        {
            var statusLabel = By.XPath(string.Format("id('TravelProposal{0}')//div[2]/span[1]", proposalId));
            foreach (var element in Finds(statusLabel).Skip(1))
            {
                string actualStatus = GetText(element);
                Assert.AreEqual(status, actualStatus);
            }
        }
        public void SelectCreateProposalForChanges(string proposalId)
        {
            var createProposalForChanges = By.XPath(string.Format("//div[@id='TravelProposal{0}']//button[contains(text(),'Create Proposal For Changes')]", proposalId));
            Click(createProposalForChanges);
        }
        public void CheckSuccessCreateProposalForChangesMessage()
        {
            string actualMessage = GetText(popupMessage);
            Assert.AreEqual("Transport proposal with traveller changes was added successfully.", actualMessage);
        }
    }
}
