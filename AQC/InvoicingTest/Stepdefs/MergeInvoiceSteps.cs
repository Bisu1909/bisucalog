using AQC.Implement;
using InvoicingTest.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace InvoicingTest.Stepdefs
{
    [Binding]
    [Scope(Feature = "MergeInvoice")]
    public sealed class MergeInvoiceSteps : BDDFixture
    {
        private static List<string> listMergedInvoiceId;
        private static List<string> listMergedInvoiceItemList;
        [Given(@"User go to Manage page")]
        public void GivenUserGoToManagePage()
        {
            CurrentPage.GoTo<ManagePage>();
        }

        [When(@"User fake authen as ""(.*)""")]
        public void WhenUserFakeAuthenAs(string user)
        {
            CurrentPage.As<ManagePage>().FakeAuthenTo(user);
        }

        [When(@"User select on create invoice button")]
        public void WhenUserSelectOnCreateInvoiceButton()
        {
            CurrentPage.As<ManagePage>().SelectCreateInvoiceButton();
        }

        [Then(@"User should see create new invoice pop up")]
        public void ThenUserShouldSeeCreateNewInvoicePopUp()
        {
            CurrentPage.As<ManagePage>().CheckCreateNewInvoicePopup();
        }

        [Given(@"User input project ID as ""(.*)"", select invoice period month as ""(.*)"", year as ""(.*)""")]
        public void GivenUserInputProjectIDAsSelectInvoicePeriodMonthAsYearAs(string projectId, string month, string year)
        {
            CurrentPage.As<ManagePage>().FillProjectIdOnCreateNewInvoicePopup(projectId);
            CurrentPage.As<ManagePage>().FillInvoicingPeriodOnCreateNewInvoicePopup(month, year);
        }

        [Then(@"User should see create new invoice pop up is extented with extra information")]
        public void ThenUserShouldSeeCreateNewInvoicePopUpIsExtentedWithExtraInformation()
        {
            CurrentPage.As<ManagePage>().CheckCreateNewInvoicePopupExtented();
        }

        [Given(@"User select PExt information")]
        public void GivenUserSelectPExtInformation()
        {
            CurrentPage.As<ManagePage>().SelectProjectExtensionOnCreateNewInvoicePopup();
        }

        [Given(@"User click on Create button")]
        public void GivenUserClickOnCreateButton()
        {
            CurrentPage.As<ManagePage>().SelectCreateNewInvoiceOnCreateInvoicePopup();
        }

        [Then(@"User should be redirected to Edition page")]
        public void ThenUserShouldBeRedirectedToEditionPage()
        {
            CurrentPage.As<EditionPage>().CheckIsAt();
        }

        [Then(@"User note the Invoice ID and info of invoice's items")]
        public void ThenUserNoteTheInvoiceIDAndInfoOfInvoiceSItems()
        {
            listMergedInvoiceId.Add(CurrentPage.As<EditionPage>().GetInvoiceId());
            listMergedInvoiceItemList.AddRange(CurrentPage.As<EditionPage>().GetListItemInfo());
        }

        [When(@"User expanded Advance Search section")]
        public void WhenUserExpandedAdvanceSearchSection()
        {
            CurrentPage.As<ManagePage>().SelectToExpandAdvanceSearch();
        }

        [When(@"User input project ID as ""(.*)"" into Search Query")]
        public void WhenUserInputProjectIDAsIntoSearchQuery(string projectId)
        {
            CurrentPage.As<ManagePage>().FillSearchQueryAdvanceSearch(projectId);
        }

        [When(@"User select Search button")]
        public void WhenUserSelectSearchButton()
        {
            CurrentPage.As<ManagePage>().SelectSearchButton();
        }

        [Then(@"User should see search result")]
        public void ThenUserShouldSeeSearchResult()
        {
            CurrentPage.As<ManagePage>().CheckSearchResult();
        }

        [Given(@"User check on 3 newly created invoices")]
        public void GivenUserCheckOnNewlyCreatedInvoices()
        {
            CurrentPage.As<ManagePage>().CheckOnInvoiceWithId(listMergedInvoiceId);
        }

        [Given(@"User select Merge Invoices button")]
        public void GivenUserSelectMergeInvoicesButton()
        {
            CurrentPage.As<ManagePage>().SelectMergeInvoicesButton();
        }
        [Then(@"User should see Merging pop up with warning message is ""(.*)""")]
        public void ThenUserShouldSeeMergingPopUpWithWarningMessageIs(string message)
        {
            CurrentPage.As<ManagePage>().CheckMergingPopupMessage(message);
        }

        [Given(@"User select Merge button on Merging pop up")]
        public void GivenUserSelectMergeButtonOnMergingPopUp()
        {
            CurrentPage.As<ManagePage>().SelectMergeButtonOnMergingPopup();
        }

        [Then(@"User should see message on manage page: ""(.*)""")]
        public void ThenUserShouldSeeMessageOnManagePage(string message)
        {
            CurrentPage.As<ManagePage>().CheckMessage(message);
        }

        [When(@"User input Invoice ID into Search Query")]
        public void WhenUserInputInvoiceIDIntoSearchQuery()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"User perform edit first invoice")]
        public void GivenUserPerformEditFirstInvoice()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"User navigate to new opened tab")]
        public void GivenUserNavigateToNewOpenedTab()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"User change Consultant Format to ""(.*)""")]
        public void GivenUserChangeConsultantFormatTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User should see Item list is coppied from the merged invoice")]
        public void ThenUserShouldSeeItemListIsCoppiedFromTheMergedInvoice()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
