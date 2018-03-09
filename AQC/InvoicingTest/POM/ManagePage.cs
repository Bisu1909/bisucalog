using AQC.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQC.Interface;
using OpenQA.Selenium;
using NUnit.Framework;

namespace InvoicingTest.POM
{
    public class ManagePage : BasePage
    {
        public ManagePage(IFixture fixture) : base(fixture)
        {
        }

        public override string PageUrl => Setting.BaseUrl + "invoicing";
        #region elements
        private By userMenu = By.XPath("//li[@id='userMenu']/a");
        private By userMenuSearchField = By.XPath("//div[@class='select2-drop select2-display-none select2-with-searchbox select2-drop-active']/div/input");
        private By usernameList = By.XPath("//ul[@role='listbox']/li");
        private By searchingLabel = By.XPath("//li[.='Searching…']");
        private By popupMessage = By.XPath("//p[@class='content']");
        private By searchInput = By.XPath("id('select2-drop')/div/input");
        #endregion
        public void FakeAuthenTo(string username)
        {
            username = username.ToLower();
            WaitPageLoadReady();
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
        }
        private void SelectAndSearch(By searchField, string textToSearch)
        {
            Click(searchField);
            TypeText(searchInput, textToSearch);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
        }
        public void SelectCreateInvoiceButton()
        {
            var createInvoiceButton = By.XPath("//a[@href='/Invoicing/Invoicing/Create']");
            Click(createInvoiceButton);
        }
        public void CheckCreateNewInvoicePopup()
        {
            WaitPageLoadReady();
            var createNewInvoiceLabel = By.XPath("//h3[.='Create new Invoice']");
            Assert.IsTrue(IsVisibled(createNewInvoiceLabel));
        }
        public void FillProjectIdOnCreateNewInvoicePopup(string projectId)
        {
            var projectField = By.XPath("//div[@id='s2id_ProjectId']//span[@class='select2-chosen']");
            SelectAndSearch(projectField, projectId);
        }
        public void FillInvoicingPeriodOnCreateNewInvoicePopup(string month, string year)
        {
            var generateCreditNoteLabel = By.XPath("//h4[.='Generate Credit Note']");
            var periodInput = By.XPath("//div[@id='InvoicingPeriod']//input[@placeholder='Choose a month']");
            if (IsVisibled(generateCreditNoteLabel))
            {
                periodInput = By.XPath("//label[@for='Period']/following-sibling::div//input[@placeholder='Choose a month']");
            }
            Click(periodInput);
            ClearText(periodInput);
            TypeText(periodInput, string.Format("{0} {1}", month, year));
            Find(periodInput).SendKeys(Keys.Tab);
            //var monthLabel = By.XPath(string.Format("//span[@class='month' and .='{0}']", month));
            //Click(monthLabel);
            //var activeMonthLabel = By.XPath("//span[@class='month active']");
            //Click(activeMonthLabel);
            //var calendarIcon = By.XPath("//input[@id='InvoicingPeriod']/following-sibling::span");
            //Click(calendarIcon);
        }
        public void CheckCreateNewInvoicePopupExtented()
        {
            var clientLabel = By.XPath("//label[@class='col-md-4 control-label' and .='Client']");
            var companyLabel = By.XPath("//label[@class='col-md-4 control-label' and .='Company']");
            var pExtLabel = By.XPath("//label[@class='col-md-4 control-label' and .='PExt']");
            var createButton = By.XPath("//button[@type='submit' and .='Create']");
            WaitElementIsVisibled(clientLabel);
            WaitElementIsVisibled(companyLabel);
            WaitElementIsVisibled(pExtLabel);

        }
        public void SelectProjectExtensionOnCreateNewInvoicePopup()
        {
            var pExtField = By.XPath("//div[@id='s2id_ProjectExtensionId']");
            Click(pExtField);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
        }
        public void SelectCreateNewInvoiceOnCreateInvoicePopup()
        {
            var createButton = By.XPath("//button[@type='submit' and .='Create']");
            Click(createButton);
            WaitPageLoadReady();
        }
        public void SelectToExpandAdvanceSearch()
        {
            var AdvanceSearchLabelColapsed = By.XPath("//span[@id='filterArrow']");
            Click(AdvanceSearchLabelColapsed);
            WaitPageLoadReady();
        }
        public void FillSearchQueryAdvanceSearch(string input)
        {
            var searchQueryInput = By.XPath("//input[@id='Filters_Query']");
            TypeText(searchQueryInput, input);
        }
        public void FillCompanyAdvanceSearch(string input)
        {
            var companyInput = By.XPath("//div[@id='s2id_Filters_CompanyId']//input");
            TypeText(companyInput, input);
            WaitElementIsInvisibled(searchingLabel);
            var companyResult = By.XPath(string.Format("//div[@class='select2-result-label' and text()='{0}']", input));
            Click(companyResult);
        }
        public void SelectStatusAdvanceSearch(string status)
        {
            var statusField = By.XPath("//div[@id='s2id_Filters_StatusId']//span[@class='select2-chosen']");
            Click(statusField);
            TypeText(searchInput, status);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
        }
        public void SelectSearchButton()
        {
            var searchButton = By.XPath("//button[@id='searchFormBtn']");
            Click(searchButton);
        }
        public void CheckSearchResult()
        {
            var noMatchingRecordLabel = By.XPath("//h3[.='No matching records found']");
            WaitPageLoadReady();
            if (IsVisibled(noMatchingRecordLabel))
            {
                LogWarning("No matching records found");
                Assert.True(false);
            }
        }
        public void SendInvoice(string invoiceId)
        {
            var ActionsDropdownButton = By.XPath(string.Format("//tr[@id='Invoice-{0}']//button[@id='dropdownMenu1']", invoiceId));
            Click(ActionsDropdownButton);
            var sendOption = By.XPath("//a[contains(@href,'ConfirmSend?')]");
            Click(sendOption);
            WaitPageLoadReady();
        }
        public void EditInvoice(string invoiceId)
        {
            var ActionsDropdownButton = By.XPath(string.Format("//tr[@id='Invoice-{0}']//button[@id='dropdownMenu1']", invoiceId));
            Click(ActionsDropdownButton);
            var editOption = By.XPath("//a[contains(@href,'Edit?')]");
            Click(editOption);
            WaitPageLoadReady();
        }
        public void CheckInvoicesToSendPopup()
        {
            var popupTitleLabel = By.XPath("//h4[@id='commentModalLabel']");
            string popupTitle = GetText(popupTitleLabel);
            Assert.AreEqual("Invoices To Send", popupTitle);                
        }
        public void SelectSendOnInvoicesToSendPopup()
        {
            var sendButton = By.XPath("//button[@class='btn btn-primary' and .='Send']");
            Click(sendButton);
        }
        public void CheckMessage(string message)
        {
            var messagelabelOnPage = By.XPath("//div[@class='alert alert-success']");
            WaitPageLoadReady();
            string actualMessage = GetText(messagelabelOnPage).Substring(3);
            Assert.IsTrue(actualMessage.Contains(message));
        }
        public void SelectCreateCreditNoteButton()
        {
            var createCreditNoteButton = By.XPath("//a[@href='/Invoicing/CreditNote/GetModal']");
            Click(createCreditNoteButton);
        }
        public void CheckGenerateCreditNotePopup()
        {
            var popupTitleLabel = By.XPath("//h4[.='Generate Credit Note']");
            string actualPopupTitle = GetText(popupTitleLabel);
            Assert.AreEqual("Generate Credit Note", actualPopupTitle);
        }
        public void SelectReasonOnCreditNotePopup(string reason)
        {
            var reasonField = By.XPath("//div[@id='s2id_Reason']//span[.='Select Reason']");
            Click(reasonField);
            TypeText(searchInput, reason);
            PressEnter(searchInput);
        }
        public void CheckGenerateCreditNotePopupExtented()
        {          
            //var projectLabel = By.XPath("//label[@for='ProjectId']");
            //var projectPextLabel = By.XPath("//label[@for='ProjectExtensionId']");
            var createCreditNoteButton = By.XPath("//button[@class='btn btn-success fa fa-plus generate-credit']");
            //WaitElementIsVisibled(projectLabel);
            //WaitElementIsVisibled(projectPextLabel);
            WaitElementIsVisibled(createCreditNoteButton);
        }
        public void SelectGenerateCreditNoteButton()
        {
            var GenerateCreditNoteButton = By.XPath("//button[@class='btn btn-success fa fa-plus generate-credit']");
            Click(GenerateCreditNoteButton);
            WaitPageLoadReady();
        }
        public void FillInvoiceIdOnGenerateCreditNotePopup(string company, string invoiceId)
        {
            var invoiceIdField = By.XPath("//div[@id='s2id_slInvoiceLink']//span[@class='select2-chosen']");
            Click(invoiceIdField);
            TypeText(searchInput, invoiceId);
            WaitElementIsInvisibled(searchingLabel);
            var invoiceIdResultList = By.XPath("id('select2-drop')//li");
            foreach(var element in Finds(invoiceIdResultList))
            {
                if (GetText(element).Contains(company))
                {
                    Click(element);
                    break;
                }
            }
        }
        public string GetFirstInvoiceId()
        {
            var firstActionButton = By.XPath("//tbody[@id='tableBody']/tr[1]");
            string idString = Find(firstActionButton).GetAttribute("id");
            string invoiceId = idString.Substring(8);
            return invoiceId;
        }
        public void CheckOnInvoiceWithId(List<string> listInvoiceId)
        {
            foreach(var invoiceId in listInvoiceId)
            {
                var checkBox = By.XPath(string.Format("//input[@data-value='{0}']", invoiceId));
                Click(checkBox);
            }            
        }
        public void SelectMergeInvoicesButton()
        {
            var mergeInvoicesButton = By.XPath("//button[@type='submit' and .='Merge Invoices']");
            Click(mergeInvoicesButton);
        }
        public void CheckMergingPopupMessage(string message)
        {
            var mergingLabel = By.XPath("//h3[.=' Merging']");
            WaitElementIsVisibled(mergingLabel);
            if(message.Equals("none"))
            {
                var mergeButton = By.XPath("//button[@class='btn btn-warning']");
                WaitElementIsVisibled(mergeButton);
            }
            else
            {                
                var warningMessageLabel = By.XPath("//div[@class='alert alert-danger']");
                string ActualMessage = GetText(warningMessageLabel);
                Assert.AreEqual(message, ActualMessage);
            }            
        }
        public void SelectMergeButtonOnMergingPopup()
        {
            var mergeButton = By.XPath("//button[@class='btn btn-warning']");
            Click(mergeButton);
            WaitPageLoadReady();
        }

    }
}
