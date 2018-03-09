using AQC.Implement;
using FunctionsManagementTest.POM;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace FunctionsManagementTest.Stepdefs
{
    [Binding]
    [Scope(Feature = "CreateFunction")]
    public sealed class CreateFunctionSteps : BDDFixture
    {
        [Given(@"User go to Function Management page")]
        public void GivenUserGoToFunctionManagementPage()
        {
            CurrentPage.GoTo<FunctionsManagementPage>();            
        }

        [Given(@"User login with right auth")]
        public void GivenUserLoginWithRightAuth()
        {
            CurrentPage.As<LoginPage>().Login();
        }

        [When(@"User fake authen as ""(.*)""")]
        public void WhenUserFakeAuthenAs(string username)
        {
            CurrentPage.As<FunctionsManagementPage>().FakeAuthenTo(username);
        }

        [When(@"User click on \(\+Function\) button")]
        public void WhenUserClickOnFunctionButton()
        {
            CurrentPage.As<FunctionsManagementPage>().CreateFunction();
        }

        [Then(@"User should be redirected to new function page")]
        public void ThenUserShouldBeRedirectedToNewFunctionPage()
        {
            CurrentPage.As<FunctionsManagementPage>().CheckIsAtFunctionProfilePage();
        }

        [Given(@"User is at New Function profile page")]
        public void GivenUserIsAtNewFunctionProfilePage()
        {
            CurrentPage.As<FunctionsManagementPage>().CheckIsAtFunctionProfilePage();
        }

        [When(@"User click on General Information to expand info")]
        public void GivenUserClickOnGeneralInformationToExpandInfo()
        {
            CurrentPage.As<FunctionsManagementPage>().ExpandGeneralInfo();
        }

        [When(@"User select Department name as ""(.*)""")]
        public void WhenUserSelectDepartmentNameAs(string departmentname)
        {
            CurrentPage.As<FunctionsManagementPage>().SelectDept(departmentname);
        }

        [When(@"User input new Function name as ""(.*)""")]
        public void WhenUserInputNewFunctionNameAs(string newfunctionname)
        {
            CurrentPage.As<FunctionsManagementPage>().InputFunctionName(newfunctionname);
        }

        [When(@"User select Function type")]
        public void WhenUserSelectFunctionType()
        {
            CurrentPage.As<FunctionsManagementPage>().SelectFunctionType();
        }

        [When(@"User select Function Parent name as ""(.*)""")]
        public void WhenUserSelectFunctionParentNameAs(string parentfunctionname)
        {
            CurrentPage.As<FunctionsManagementPage>().SelectParentFunction(parentfunctionname);
        }

        [When(@"User input Short Definition as ""(.*)""")]
        public void WhenUserInputShortDefinitionAs(string shortdefinition)
        {
            CurrentPage.As<FunctionsManagementPage>().InputShortDefinition(shortdefinition);
        }

        [When(@"User input Responsibility as ""(.*)""")]
        public void WhenUserInputResponsibilityAs(string responsibility)
        {
            CurrentPage.As<FunctionsManagementPage>().InputResponsibility(responsibility);
        }

        [When(@"User select Focus")]
        public void WhenUserSelectFocus()
        {
            CurrentPage.As<FunctionsManagementPage>().SelectFocus();
        }

        [When(@"User click on \(Create as Validated\) button")]
        public void WhenUserClickOnCreateAsValidatedButton()
        {
            CurrentPage.As<FunctionsManagementPage>().ClickValidateButton();
        }

        [Then(@"User should be redirected to Function Management page")]
        public void ThenUserShouldBeRedirectedToFunctionManagementPage()
        {
            CurrentPage.As<FunctionsManagementPage>().CheckIsAtFunctionsManagementPage();
        }

        [Then(@"New Function ""(.*)"" is created successfully")]
        public void ThenNewFunctionIsCreatedSuccessfully(string validatedfunction)
        {            
            CurrentPage.As<FunctionsManagementPage>().ValidateNewFunction(validatedfunction);
        }

        [When(@"User search function ""(.*)""")]
        public void WhenUserSearchFunctionToEdit(string functionname)
        {
            CurrentPage.As<FunctionsManagementPage>().SearchFunction(functionname);
        }

        [When(@"User open profile page of function ""(.*)""")]
        public void WhenUserOpenProfilePageOfFunction(string functionname)
        {
            CurrentPage.As<FunctionsManagementPage>().OpenFunctionProfilePage(functionname);
        }

        [Then(@"User should be redirected to function profile page of function ""(.*)""")]
        public void ThenUserShouldBeRedirectedToFunctionProfilePageOfFunction(string functionname)
        {
            CurrentPage.As<FunctionsManagementPage>().CheckIsAtFunctionProfilePage();
            CurrentPage.As<FunctionsManagementPage>().CheckFunctionProfilePageTitle(functionname);
        }

        [Given(@"User is at ""(.*)"" Function profile page")]
        public void GivenUserIsAtFunctionProfilePage(string functionname)
        {
            CurrentPage.As<FunctionsManagementPage>().CheckIsAtFunctionProfilePage();
            CurrentPage.As<FunctionsManagementPage>().CheckFunctionProfilePageTitle(functionname);
        }

        [When(@"User input ""(.*)"" to Function Title field")]
        public void WhenUserInputToFunctionTitleField(string text)
        {
            CurrentPage.As<FunctionsManagementPage>().AddTextToFunctionTitleField(text);
        }

        [When(@"User clear and type text in Short Definition field as ""(.*)""")]
        public void WhenUserClearAndTypeTextInShortDefinitionFieldAs(string text)
        {
            CurrentPage.As<FunctionsManagementPage>().ClearAndTypeTextShortDefinition(text);
        }

        [When(@"User clear and type text in Responsibility field as ""(.*)""")]
        public void WhenUserClearAndTypeTextInResponsibilityFieldAs(string text)
        {
            CurrentPage.As<FunctionsManagementPage>().ClearAndTypeTextResponsibility(text);
        }

        [Then(@"User should see the notification for editing successfully")]
        public void ThenUserShouldSeeTheNotificationForEditingSuccessfully()
        {
            CurrentPage.As<FunctionsManagementPage>().ValidateEditingSuccessfully();
        }


    }
}
