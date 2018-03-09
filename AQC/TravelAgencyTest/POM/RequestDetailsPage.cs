using AQC.Interface;
using AQC.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyTest.POM
{
    class RequestDetailsPage : BasePage
    {
        public RequestDetailsPage(IFixture fixture) : base(fixture)
        {
        }

        public override string PageUrl => Setting.BaseUrl + "TravelAgency/TravelAgency/Details/";

        private By travellerProfileFormSaveButton = By.XPath("//form[@id='traveller-profile-form']//button[@id='btn-save']");
        private By PolicyFormCheckBox = By.XPath("//form[@id='accept-policy-form']//input[@type='checkbox']");
        private By PolicyFormConfirmButton = By.XPath("//form[@id='accept-policy-form']//button[@id='btn-Confirm']");
        private By userMenu = By.XPath("//li[@id='userMenu']/a");
        private By userMenuSearchField = By.XPath("//div[@class='select2-drop select2-display-none select2-with-searchbox select2-drop-active']/div/input");
        private By usernameList = By.XPath("//ul[@role='listbox']/li");
        private By searchingLabel = By.XPath("//li[.='Searching…']");
        private By popupMessage = By.XPath("//p[@class='content']");

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
        public void SelectManageProposalsButton()
        {
            var managedProposalButton = By.XPath("//a[contains(@href,'/TravelAgency/Proposal/Index/')]");
            Click(managedProposalButton);
        }
        public string GetTravellerName()
        {
            var travellerNameLabel = By.XPath("//span[@data-onsave='OnTravelRequestTypeChange']/following-sibling::span[1]");
            return GetText(travellerNameLabel);
        }
        public void SelectFlightOption()
        {
            var flightOption1Label = By.XPath("//h2[.='Flight']/..//span[.='Option 1']");
            if (IsVisibled(flightOption1Label))
            {
                Click(flightOption1Label);
            }            
        }
        public void SelectHotelOption()
        {
            var hotelOption1Label = By.XPath("//h2[.='Hotel']/..//span[.='Option 1']");
            if (IsVisibled(hotelOption1Label))
            {
                Click(hotelOption1Label);
            }
        }
        public void SelectTrainOption()
        {
            var trainOption1Label = By.XPath("//h2[.='Train']/..//span[.='Option 1']");
            if (IsVisibled(trainOption1Label))
            {
                Click(trainOption1Label);
            }
        }
        public void SelectTaxiOption()
        {
            var taxiOption1Label = By.XPath("//h2[.='Taxi']/..//span[.='Option 1']");
            if (IsVisibled(taxiOption1Label))
            {
                Click(taxiOption1Label);
            }
        }
        public void SelectCarRentalOption()
        {
            var carRentalOption1Label = By.XPath("//h2[.='Car Rental']/..//span[.='Option 1']");
            if (IsVisibled(carRentalOption1Label))
            {
                Click(carRentalOption1Label);
            }
        }
        public void SelectSubmitSelection()
        {
            var submitSelectionButton = By.XPath("//button[@class='btn btn-success']/i");
            Click(submitSelectionButton);
        }        
        public void CheckSuccessUpdateProposalMessage()
        {
            string actualMessage = GetText(popupMessage);
            Assert.AreEqual("Update selected proposals successfully.", actualMessage);
            var closeButton = By.XPath("//h4[.='Proposal Survey']/../..//button[@class='btn btn-default']");            
            WaitElementIsInvisibled(popupMessage);
            Click(closeButton);
        }
        public void CheckRequestStatus(string expectStatus)
        {
            WaitPageLoadReady();
            var statuslabel = By.XPath("//span[@id='RequestStateLabel']");
            string actualStatus = GetText(statuslabel);
            Assert.AreEqual(expectStatus, actualStatus);
        }

    }
}
