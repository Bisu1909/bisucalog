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
    public class EditionPage : BasePage
    {
        public EditionPage(IFixture fixture) : base(fixture)
        {
        }

        public override string PageUrl => Setting.BaseUrl + "Invoicing/Invoicing/Edit";

        #region elements
        private By userMenu = By.XPath("//li[@id='userMenu']/a");
        private By userMenuSearchField = By.XPath("//div[@class='select2-drop select2-display-none " +
            "select2-with-searchbox select2-drop-active']/div/input");
        private By usernameList = By.XPath("//ul[@role='listbox']/li");
        private By searchingLabel = By.XPath("//li[.='Searching…']");
        private By popupMessage = By.XPath("//p[@class='content']");
        private By searchInput = By.XPath("id('select2-drop')/div/input");
        private By messageLabel = By.XPath("//div[@id='error-content']");
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
        public void CheckIsAt()
        {
            WaitPageLoadReady();
            var editInvoiceLabel = By.XPath("//h2[contains(text(),'Edit Invoice')]");
            if (!IsVisibled(editInvoiceLabel))
            {
                Assert.IsFalse(true);
            }
        }
        public void SelectRegenerateButton()
        {
            var RegenerateButton = By.XPath("//i[@class='fa fa-refresh']");
            Click(RegenerateButton);
        }
        public void CheckAttentionPopup()
        {
            var messageLabel = By.XPath("//h4[contains(text(),' If you regenerate this invoice, " +
                "you will lose all the editions made')]");
            WaitElementIsVisibled(messageLabel);
        }
        public void SelectRegenerateButtonOnPopup()
        {
            var regenerateButton = By.XPath("//button[@type='submit']");
            Click(regenerateButton);
            WaitPageLoadReady();
        }
        public void SelectClientCode()
        {
            var clientCodeField = By.XPath("//span[@data-name='ClientCodeId']");
            if (!GetText(clientCodeField).Equals("Empty"))
            {
                LogInfo("Client Code populated! Skipping client code selection ...");
                return;
            }
            DoubleClick(clientCodeField);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
            Assert.Equals(GetText(messageLabel), "Saved");
        }
        private void CheckAndUnlockButton()
        {
            var lockButton = By.XPath("//i[@class='fa  fa-lock']");
            var unlockButton = By.XPath("//i[@class='fa  fa-unlock']");
            WaitPageLoadReady();
            if (IsVisibled(lockButton))
            {
                Click(lockButton);
                WaitElementIsVisibled(unlockButton);
            }
        }
        public void UpdateItemsDescription(string description)
        {
            CheckAndUnlockButton();
            var descriptionField = By.XPath("//span[@data-name='Description']");
            Click(descriptionField);
            var descriptionInput = By.XPath("//input[@class='form-control input-large']");
            TypeText(descriptionInput, description);
            PressEnter(descriptionInput);
            Assert.AreEqual(GetText(messageLabel), "Saved");
        }
        public void UpdateNbUnit(string unit)
        {
            CheckAndUnlockButton();
            var nbUnitField = By.XPath("//span[@data-name='NbUnit']");
            Click(nbUnitField);
            var nbUnitInput = By.XPath("//input[@class='form-control input-large']");
            TypeText(nbUnitInput, unit);
            PressEnter(nbUnitInput);
            Assert.AreEqual(GetText(messageLabel), "Saved");
        }
        public void SelectBankInformation()
        {
            var bankInformationField = By.XPath("//span[@data-name='BankInformationId']");
            var bankInformationFieldEditable = By.XPath("//span[@class='editable-container editable-inline']");
            string bankName = GetText(bankInformationField);
            if (!bankName.Equals("Select Bank Information..."))
            {
                LogInfo("Bank Information already populated! Selecting another Bank to trigger validate button");
                ScrollToElement(bankInformationField);
                Click(bankInformationField);
                Click(bankInformationFieldEditable);
                
                WaitElementIsInvisibled(searchingLabel);
                var listBankReturn = By.XPath("//li[@role='presentation']");
                foreach (var element in Finds(listBankReturn))
                {
                    if (!GetText(element).Contains(bankName))
                    {
                        Click(element);
                        Assert.AreEqual(GetText(messageLabel), "Saved");
                        break;
                    }
                }
                return;
            }
            Click(bankInformationField);
            Click(bankInformationFieldEditable);
            WaitElementIsInvisibled(searchingLabel);
            PressEnter(searchInput);
            Assert.AreEqual(GetText(messageLabel), "Saved");
        }
        public void CheckValidateInvoiceButton()
        {
            var validateInvoiceButton = By.XPath("//a[@class='btn btn-sm btn-success']");
            ScrollToTop();
            WaitElementIsVisibled(validateInvoiceButton);
        }
        public void CheckInvoiceStatus(string status)
        {
            var invoiceStatuslabel = By.XPath("//span[@id='InvoiceStatus']");
            WaitPageLoadReady();
            string actualStatus = GetText(invoiceStatuslabel);
            Assert.AreEqual(status, actualStatus);
        }
        public void SelectValidateInvoiceButton()
        {
            var validateInvoiceButton = By.XPath("//a[contains(@class,'btn btn-sm btn-success')]");
            Click(validateInvoiceButton);
            WaitPageLoadReady();
        }
        public void CheckMessage(string message)
        {
            var messagelabelOnPage = By.XPath("//div[@class='alert alert-success']");
            WaitPageLoadReady();
            string actualMessage = GetText(messagelabelOnPage).Substring(3);
            Assert.AreEqual(message, actualMessage);
        }
        public string GetOurRefName()
        {
            var outRefNameLabel = By.XPath("//span[@data-name='OurReferenceId']");
            string refName = GetText(outRefNameLabel);
            return refName;
        }
        public string GetInvoiceId()
        {
            var headerLabel = By.XPath("//div[@id='editionheader']");
            string InvoiceIdString = GetText(headerLabel);
            int pFrom = InvoiceIdString.IndexOf("Edit Invoice ") + "Edit Invoice ".Length;
            int pTo = InvoiceIdString.LastIndexOf(" - ");
            String result = InvoiceIdString.Substring(pFrom, pTo - pFrom);
            return result;
        }
        public void CreateItemRebate()
        {
            CheckAndUnlockButton();
            var newItemButton = By.XPath("//a[@class='btn btn-success dropdown-toggle ']");
            Click(newItemButton);
            var rebateOption = By.XPath("//a[contains(@data-href,'Rebate')]");
            Click(rebateOption);
            var descriptionTextArea = By.XPath("//textarea[@class='descriptioninput form-control required']");
            TypeText(descriptionTextArea, "Automated Text");
            var poNumberInput = By.XPath("//input[@class='ponumberinput form-control']");
            TypeText(poNumberInput, "Automated text");
            var nbUnitInput = By.XPath("//input[@class='unitinput form-control']");
            TypeText(nbUnitInput, "1");
            var rateInput = By.XPath("//input[@class='rateinput form-control']");
            TypeText(rateInput, "1");
            var saveItemButton = By.XPath("//p[@class='btn btn-success btn-sm saveitem']");
            Click(saveItemButton);
            var loaddingLabel = By.XPath("//p[@class='btn btn-success btn-sm saveitem loading']");
            WaitElementIsInvisibled(loaddingLabel);
        }
        public List<string> GetListItemInfo()
        {
            List<String> itemInfo = new List<string>();
            for(int i = 1; i <= 9; i++)
            {
                var textValue = By.XPath(string.Format("//tbody[@id='EditBodyItemTable']/tr[1]//td[{0}]", i));
                itemInfo.Add(GetText(textValue));
            }
            return itemInfo;
        }
        public void CheckTextItem()
        {
            var cancelInvoiceLabel = By.XPath("//span[@data-name='Description' and contains(text(),'Cancel invoice')]");
            string actualText = GetText(cancelInvoiceLabel);
            Assert.IsTrue(actualText.Contains("Cancel invoice"));
        }
        public void CheckAndCompareCreditNoteItem(List<string> actualList)
        {
            List<string> expectList = GetListItemInfo();
            for (int i = 0; i < actualList.Count; i++)
            {
                if (!actualList[i].Equals(expectList[i]))
                {
                    LogError(string.Format("List item not match! {0} <> {1} ", expectList[i], actualList[i]));
                    Assert.True(false);
                }                
            }
            
        }
        public void ChangeConsultantFormat(string format)
        {
            var consultantFormatButton = By.XPath("//strong[.='Consultant Format']");
            Click(consultantFormatButton);
            var consultantFormatOption = By.XPath(string.Format("//a[@id='consultantFormat' and contains(@data-href,'{0}')]", format));
            Click(consultantFormatOption);
            var formatChangedSuccessMessage = By.XPath("//p[@class='content']");
            WaitElementIsVisibled(formatChangedSuccessMessage);
            RefreshPage();
        }

    }
}
