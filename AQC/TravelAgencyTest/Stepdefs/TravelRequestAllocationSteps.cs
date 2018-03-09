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
    [Scope(Feature = "TravelRequestAllocation")]
    public sealed class TravelRequestAllocationSteps : BDDFixture
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

        [Given(@"User go to Travel Agency Handle Request Page")]
        public void GivenUserGoToTravelAgencyHandleRequestPage()
        {
            CurrentPage.GoTo<HandleRequestPage>();
        }

        [When(@"User fake authen as ""(.*)"" in HandleRequest Page")]
        public void WhenUserFakeAuthenAsInHandleRequestPage(string user)
        {
            CurrentPage.As<HandleRequestPage>().FakeAuthento(user);
        }

        [Then(@"User should see Pending On Allocation tab")]
        public void ThenUserShouldSeePendingOnAllocationTab()
        {
            CurrentPage.As<HandleRequestPage>().CheckPendingOnAllocationTabVisibled();
        }

        [Given(@"User allocate new request to ""(.*)""")]
        public void GivenUserAllocateNewRequestTo(string userName)
        {
            CurrentPage.As<HandleRequestPage>().AllocatedFirstRequest(userName);
        }

        [Then(@"User should see success allocated message with requestID")]
        public void ThenUserShouldSeeSuccessAllocatedMessageWithRequestID()
        {
            CurrentPage.As<HandleRequestPage>().CheckSucessAllocatedMessage();
        }

    }
}
