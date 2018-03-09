using AQC.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQC.Interface;
using OpenQA.Selenium;
using NUnit.Framework;

namespace TravelAgencyTest.POM
{
    class PriceGuidelinePage : BasePage
    {
        public PriceGuidelinePage(IFixture fixture) : base(fixture)
        {
        }

        public override string PageUrl => Setting.BaseUrl + "Travelagency/priceguideline";

        private By travellerProfileFormSaveButton = By.XPath("//form[@id='traveller-profile-form']//button[@id='btn-save']");
        private By PolicyFormCheckBox = By.XPath("//form[@id='accept-policy-form']//input[@type='checkbox']");
        private By PolicyFormConfirmButton = By.XPath("//form[@id='accept-policy-form']//button[@id='btn-Confirm']");
        private By userMenu = By.XPath("//li[@id='userMenu']/a");
        private By userMenuSearchField = By.XPath("//div[@class='select2-drop select2-display-none select2-with-searchbox select2-drop-active']/div/input");
        private By usernameList = By.XPath("//ul[@role='listbox']/li");
        private By searchingLabel = By.XPath("//li[.='Searching…']");
        private By popupMessage = By.XPath("//p[@class='content']");
        private By searchInput = By.XPath("id('select2-drop')/div/input");

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
        public void SelectToOpenNewGuidelinePopup()
        {
            var newGuidelineButton = By.XPath("//span[@class='createBtn']/a");
            Click(newGuidelineButton);
        }
        public void SelectService(string service)
        {
            if(service == "Flight")
            {
                SelectFlightService();
            }            
        }
        private void SelectFlightService()
        {
            var serviceField = By.XPath("//div[@id='s2id_TravelType']//span[@class='select2-chosen']");
            Click(serviceField);
            var flightLabel = By.XPath("//ul[@class='select2-results']//div[.='Flight']");
            Click(flightLabel);
        }
        public void FillFlightFromAndToPlace(string from, string to)
        {
            var fromField = By.XPath("//div[@id='s2id_FromAirportId']//span[@class='select2-chosen']");
            Click(fromField);
            TypeText(searchInput, from);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);

            var toField = By.XPath("//div[@id='s2id_ToAirportId']//span[@class='select2-chosen']");
            Click(toField);
            TypeText(searchInput, to);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
        }
        public void FillPrices(string lowPrice, string averagePrice, string highPrice)
        {
            var lowPriceInput = By.XPath("//input[@id='LowPrice']");
            TypeText(lowPriceInput, lowPrice);
            var averagePriceInput = By.XPath("//input[@id='AveragePrice']");
            TypeText(averagePriceInput, averagePrice);
            var highPriceInput = By.XPath("//input[@id='HighPrice']");
            TypeText(highPriceInput, highPrice);
        }
        public void SelectCreatePriceGuideline()
        {
            var createButton = By.XPath("//button[.='Create']");
            Click(createButton);
        }
        private void SelectFlightBusinessClass()
        {
            var businessClassCheckbox = By.XPath("//input[@id='cabinClass1']");
            Click(businessClassCheckbox);
        }
        public void SelectFlightClass(string classType)
        {
            if(classType == "Business Class")
            {
                SelectFlightBusinessClass();
            }
        }
        public void CheckSuccessCreateMessage()
        {
            string actualMessage = GetText(popupMessage);
            Assert.AreEqual("New Price Guideline is created successfully.", actualMessage);
        }

        public void SearchFlight(string from, string to, string classType)
        {
            var flightTab = By.XPath("//li[contains(@class,'bknav-itm bnav-fly')]");
            Click(flightTab);

            var fromField = By.XPath("//div[@id='s2id_SearchFrom']//span[@class='select2-chosen']");
            Click(fromField);
            TypeText(searchInput, from);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);

            var toField = By.XPath("//div[@id='s2id_SearchTo']//span[@class='select2-chosen']");
            Click(toField);
            TypeText(searchInput, to);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);

            var classField = By.XPath("//div[@id='s2id_Class']//span[@class='select2-chosen']");
            Click(classField);

 
            var economyClassLabel = By.XPath("//div[@class='select2-result-label' and .='Economy Class']");
            var businessClassLabel = By.XPath("//div[@class='select2-result-label' and .='Business Class']");
            if(classType == "Economy Class")
            {
                Click(economyClassLabel);
            }
            else
            {
                Click(businessClassLabel);
            }
            var filterButton = By.XPath("//button[@id='BtnFilter']");
            Click(filterButton);
            WaitPageLoadReady();
        }
        public void DeleteFirstPriceGuidelineRecords()
        {
            var trashButton = By.XPath("//i[@class='fa fa-trash']");
            Click(Finds(trashButton)[0]);
            var deleteButton = By.XPath("//button[contains(text(),'Delete')]");
            Click(deleteButton);            
        }
        public void CheckSuccessDeleteMessage()
        {
            string actualMessage = GetText(popupMessage);
            Assert.AreEqual("Price Guideline was deleted.", actualMessage);
            WaitElementIsInvisibled(popupMessage);
        }
    }
}
