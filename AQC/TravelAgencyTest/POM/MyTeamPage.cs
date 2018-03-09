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
    class MyTeamPage : BasePage
    {
        public MyTeamPage(IFixture fixture) : base(fixture)
        {
        }

        public override string PageUrl => Setting.BaseUrl + "TravelAgency/myteam";
        #region elements
        private By travellerProfileFormSaveButton = By.XPath("//form[@id='traveller-profile-form']//button[@id='btn-save']");
        private By PolicyFormCheckBox = By.XPath("//form[@id='accept-policy-form']//input[@type='checkbox']");
        private By PolicyFormConfirmButton = By.XPath("//form[@id='accept-policy-form']//button[@id='btn-Confirm']");
        private By userMenu = By.XPath("//li[@id='userMenu']/a");
        private By userMenuSearchField = By.XPath("//div[@class='select2-drop select2-display-none select2-with-searchbox select2-drop-active']/div/input");
        private By searchinglabel = By.XPath("//li[.='Searching…']");
        private By usernameList = By.XPath("//ul[@role='listbox']/li");
        private By popupMessage = By.XPath("//p[@class='content']");
        private By loaddingOverlay = By.XPath("//div[contains(@class,'blockUI blockMsg')]");
        #endregion
        public void FakeAuthento(string username)
        {
            if (IsVisibled(travellerProfileFormSaveButton)) Click(travellerProfileFormSaveButton); WaitPageLoadReady();
            if (IsVisibled(PolicyFormCheckBox)) { Click(PolicyFormCheckBox); Click(PolicyFormConfirmButton); WaitPageLoadReady(); }
            username = username.ToLower();
            WaitPageLoadReady();
            var loaddingOverlayFakeauthen = By.XPath("//div[@class='blockUI blockMsg blockPage']");
            //some time loading overlay finished after pageloadready 
            //WaitElementIsInvisibled(loaddingOverlayFakeauthen);
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
                    WaitElementIsInvisibled(loaddingOverlay);
                    break;
                }
            }
            if (IsVisibled(travellerProfileFormSaveButton)) Click(travellerProfileFormSaveButton); WaitPageLoadReady();
            if (IsVisibled(PolicyFormCheckBox)) { Click(PolicyFormCheckBox); Click(PolicyFormConfirmButton); WaitPageLoadReady(); }
        }
        public string GetFirstRequestByStatus(string status)
        {
            var listRequestPendingEstimated = By.XPath(string.Format("//span[@data-tooltip='{0}']",status));
            string tempString= Finds(listRequestPendingEstimated)[0].GetAttribute("data-ajax-reload-action");
            string requestId = Regex.Match(tempString, @"\d+").Value;
            return requestId;
        }
        public void ApprovedRequest(string requestId)
        {
            var approvedButton = By.XPath(string.Format("id('RequestEmployeeId{0}')/div[1]/div[1]/div[1]/ul[2]/li[1]/a[1]/i[1]", requestId));
            Wait(5000);
            Click(approvedButton);
        }
        public void CheckSucessApprovedMessage(string requestId)
        {
            string message = GetText(popupMessage);
            Assert.AreEqual(string.Format("Request {0} was Approved successfully.", requestId), message);
        }
        public void CheckStatusBar(string requestId, string status)
        {
            var requestStatusBar = By.XPath(string.Format("//div[@id='RequestEmployeeId{0}']//span[@data-tooltip='{1}']", requestId, status));
            WaitElementIsVisibled(requestStatusBar);
            return;
        }
        public void SelectUndoValidateButton(string requestId)
        {
            var undoValidateButton = By.XPath(string.Format("//div[@id='RequestEmployeeId{0}']//i[@class='fa fa-undo']", requestId));
            Click(undoValidateButton);
            WaitPageLoadReady();
        }
    }
}
