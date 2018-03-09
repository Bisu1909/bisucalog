using AQC.Implement;
using InvoicingTest.POM;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace InvoicingTest.Stepdefs
{
    [Binding]
    [Scope(Feature = "CreateInvoice")]
    public sealed class CreateInvoiceSteps : BDDFixture
    {
        public static string invoiceId;
        public static List<string> listInvoiceItemInfo;

        [Given(@"User go to Manage page")]
        public void GivenUserGoToManagePage()
        {
            CurrentPage.GoTo<ManagePage>();
        }

        [When(@"User fake authen as ""(.*)""")]
        public void WhenUserFakeAuthenAs(string username)
        {
            CurrentPage.As<ManagePage>().FakeAuthenTo(username);
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
            invoiceId = CurrentPage.As<EditionPage>().GetInvoiceId();
        }

        [Given(@"User click on Regenerate with Project button")]
        public void GivenUserClickOnRegenerateWithProjectButton()
        {
            CurrentPage.As<EditionPage>().SelectRegenerateButton();
        }
        [Then(@"User should see attention pop up")]
        public void ThenUserShouldSeeAttentionPopUp()
        {
            CurrentPage.As<EditionPage>().CheckAttentionPopup();
        }
        [Given(@"User select Regenerate button on pop up")]
        public void GivenUserSelectRegenerateButtonOnPopUp()
        {
            CurrentPage.As<EditionPage>().SelectRegenerateButtonOnPopup();
        }
        [Given(@"User select Client Code")]
        public void GivenUserSelectClientCode()
        {
            CurrentPage.As<EditionPage>().SelectClientCode();
        }
        [Given(@"User update Description as ""(.*)""")]
        public void GivenUserUpdateDescriptionAs(string description)
        {
            CurrentPage.As<EditionPage>().UpdateItemsDescription(description);
        }
        [Given(@"User update NbUnit information as ""(.*)""")]
        public void GivenUserUpdateNbUnitInformationAs(string unit)
        {
            CurrentPage.As<EditionPage>().UpdateNbUnit(unit);
        }
        [Given(@"User select Bank Information")]
        public void GivenUserSelectBankInformation()
        {
            CurrentPage.As<EditionPage>().SelectBankInformation();
        }
        [Then(@"User should see Validate Invoice button")]
        public void ThenUserShouldSeeValidateInvoiceButton()
        {
            CurrentPage.As<EditionPage>().CheckValidateInvoiceButton();
        }
        [Then(@"User should see invoice status as ""(.*)""")]
        public void ThenUserShouldSeeInvoiceStatusAs(string status)
        {
            CurrentPage.As<EditionPage>().CheckInvoiceStatus(status);
        }
        [When(@"User click on Validate Invoice button")]
        [Given(@"User click on Validate Invoice button")]
        public void GivenUserClickOnValidateInvoiceButton()
        {
            CurrentPage.As<EditionPage>().SelectValidateInvoiceButton();
        }
        [Then(@"User should see message on Edition page: ""(.*)""")]
        public void ThenUserShouldSeeMessageOnEditionPage(string message)
        {
            CurrentPage.As<EditionPage>().CheckMessage(message);
        }
        [Given(@"User fake authen as Manager of Invoice")]
        public void GivenUserFakeAuthenAsManagerOfInvoice()
        {
            string managername = CurrentPage.As<EditionPage>().GetOurRefName();
            CurrentPage.As<EditionPage>().FakeAuthenTo(managername);
        }
        [When(@"User expanded Advance Search section")]
        public void WhenUserExpandedAdvanceSearchSection()
        {
            CurrentPage.As<ManagePage>().SelectToExpandAdvanceSearch();
        }
        [When(@"User input Invoice ID into Search Query")]
        public void WhenUserInputInvoiceIdIntoSearchQuery()
        {
            CurrentPage.As<ManagePage>().FillSearchQueryAdvanceSearch(invoiceId);
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
        [Given(@"User perform send invoice")]
        public void GivenUserPerformSendInvoice()
        {
            CurrentPage.As<ManagePage>().SendInvoice(invoiceId);
        }
        [Then(@"User should see Invoice To Send pop up")]
        public void ThenUserShouldSeeInvoiceToSendPopUp()
        {
            CurrentPage.As<ManagePage>().CheckInvoicesToSendPopup();
        }
        [Given(@"User select Send button on Invoice To Send pop up")]
        public void GivenUserSelectSendButtonOnInvoiceToSendPopUp()
        {
            CurrentPage.As<ManagePage>().SelectSendOnInvoicesToSendPopup();
        }
        [Then(@"User should see message on manage page: ""(.*)""")]
        public void ThenUserShouldSeeMessageOnManagePage(string message)
        {
            CurrentPage.As<ManagePage>().CheckMessage(message);
        }
        [When(@"User select Create Credit Note button")]
        public void WhenUserSelectCreateCreditNoteButton()
        {
            CurrentPage.As<ManagePage>().SelectCreateCreditNoteButton();
        }
        [Then(@"User should see Generate Credit Note pop-up")]
        public void ThenUserShouldSeeGenerateCreditNotePop_Up()
        {
            CurrentPage.As<ManagePage>().CheckGenerateCreditNotePopup();
        }
        [Given(@"User select Reason as ""(.*)"" on Generate Credit Note pop-up")]
        public void GivenUserSelectReasonAsOnGenerateCreditNotePop_Up(string reason)
        {
            CurrentPage.As<ManagePage>().SelectReasonOnCreditNotePopup(reason);
        }
        [Then(@"User should see Generate Credit Note pop up is extented with extra information")]
        public void ThenUserShouldSeeGenerateCreditNotePopUpIsExtentedWithExtraInformation()
        {
            CurrentPage.As<ManagePage>().CheckGenerateCreditNotePopupExtented();
        }
        [Given(@"User fill in generate credit note project ID as ""(.*)"" and select project extension")]
        public void GivenUserFillInGenerateCreditNoteProjectIDAsAndSelectProjectExtension(string projectId)
        {
            CurrentPage.As<ManagePage>().FillProjectIdOnCreateNewInvoicePopup(projectId);
            CurrentPage.As<ManagePage>().SelectProjectExtensionOnCreateNewInvoicePopup();
        }
        [Given(@"select period month as ""(.*)"", year as ""(.*)""")]
        public void GivenSelectPeriodMonthAsYearAs(string month, string year)
        {
            CurrentPage.As<ManagePage>().FillInvoicingPeriodOnCreateNewInvoicePopup(month, year);
        }
        [Given(@"User select on Generate Credit Note button")]
        public void GivenUserSelectOnGenerateCreditNoteButton()
        {
            CurrentPage.As<ManagePage>().SelectGenerateCreditNoteButton();
        }
        [Given(@"User Create new Rebate Item")]
        public void GivenUserCreateNewRebateItem()
        {
            CurrentPage.As<EditionPage>().CreateItemRebate();
        }
        [When(@"User input ""(.*)"" into Company")]
        public void WhenUserInputIntoCompany(string company)
        {
            CurrentPage.As<ManagePage>().FillCompanyAdvanceSearch(company);
        }
        [When(@"User select Status as ""(.*)""")]
        public void WhenUserSelectStatusAs(string status)
        {
            CurrentPage.As<ManagePage>().SelectStatusAdvanceSearch(status);
        }
        [Given(@"User fill in generate credit note pop up: invoice ID with company specified as ""(.*)""")]
        public void GivenUserFillInGenerateCreditNotePopUpInvoiceIDWithCompanySpecifiedAs(string company)
        {
            CurrentPage.As<ManagePage>().FillInvoiceIdOnGenerateCreditNotePopup(company, invoiceId);
        }
        [Given(@"User perform edit first invoice")]
        public void GivenUserPerformEditFirstInvoice()
        {
            invoiceId = CurrentPage.As<ManagePage>().GetFirstInvoiceId();
            CurrentPage.As<ManagePage>().EditInvoice(invoiceId);
        }
        [Given(@"User note the Invoice ID and info of invoice's items")]
        public void GivenUserNoteTheInvoiceIDAndInfoOfInvoiceSItems()
        {
            
            listInvoiceItemInfo = CurrentPage.As<EditionPage>().GetListItemInfo();
            NavigationManager.SwitchToTab(0);
        }
        [Given(@"User navigate to new opened tab")]
        public void GivenUserNavigateToNewOpenedTab()
        {
            NavigationManager.SwitchToTab(1);
        }
        [Given(@"User navigate back to first tab")]
        public void GivenUserNavigateBackToFirstTab()
        {
            NavigationManager.SwitchToTab(0);
        }
        [Then(@"User should see Text Item is auto-generated")]
        public void ThenUserShouldSeeTextItemIsAuto_Generated()
        {
            CurrentPage.As<EditionPage>().CheckTextItem();
        }
        [Then(@"User should see Item list is coppied from the sent invoice")]
        public void ThenUserShouldSeeItemListIsCoppiedFromTheSentInvoice()
        {
            CurrentPage.As<EditionPage>().CheckAndCompareCreditNoteItem(listInvoiceItemInfo);
        }
        [Given(@"User change Consultant Format to ""(.*)""")]
        public void GivenUserChangeConsultantFormatTo(string format)
        {
            CurrentPage.As<EditionPage>().ChangeConsultantFormat(format);
        }

































    }
}
