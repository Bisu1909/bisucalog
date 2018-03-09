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
    [Scope(Feature = "MyTeam")]
    public sealed class MyTeamSteps : BDDFixture
    {
        private static string requestId = null;
        [Given(@"User go to Travel Agency My Team Page")]
        public void GivenUserGoToTravelAgencyMyTeamPage()
        {
            CurrentPage.GoTo<MyTeamPage>();
            //Helper.Listener(By.XPath("//form[@id='traveller-profile-form']//button[@id='btn-save']"));
            //Helper.Listener(By.XPath("//form[@id='accept-policy-form']//input[@type='checkbox']"));
            //Helper.Listener(By.XPath("//form[@id='accept-policy-form']//button[@id='btn-Confirm']"));
        }

        [When(@"User Login with username and password")]
        public void WhenUserLoginWithUsernameAndPassword()
        {
            CurrentPage.As<LoginPage>().Login(Setting.UserName, Setting.Password);
        }
        
        [Given(@"User fake authen as ""(.*)"" in My team page")]
        public void GivenUserFakeAuthenAsInMyTeamPage(string user)
        {
            CurrentPage.As<MyTeamPage>().FakeAuthento(user);
        }

        [When(@"User select approve button on first request pending on my validation")]
        public void WhenUserSelectApproveButtonOnFirstRequestPendingOnMyValidation()
        {
            requestId = CurrentPage.As<MyTeamPage>().GetFirstRequestByStatus("Estimated");
            CurrentPage.As<MyTeamPage>().ApprovedRequest(requestId);
        }

        [Then(@"User should see request approved successfully message")]
        public void ThenUserShouldSeeRequestApprovedSuccessfullyMessage()
        {
            CurrentPage.As<MyTeamPage>().CheckSucessApprovedMessage(requestId);
        }

        [Then(@"User should see request status bar as ""(.*)""")]
        public void ThenUserShouldSeeRequestStatusBarAs(string status)
        {
            CurrentPage.As<MyTeamPage>().CheckStatusBar(requestId, status);
        }

        [Given(@"User select Undo validate button")]
        public void GivenUserSelectUndoValidateButton()
        {
            CurrentPage.As<MyTeamPage>().SelectUndoValidateButton(requestId);
        }

    }
}
