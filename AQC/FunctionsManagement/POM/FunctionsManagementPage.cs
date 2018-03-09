using AQC.Interface;
using AQC.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace FunctionsManagementTest.POM
{
    public class FunctionsManagementPage : BasePage
    {
        public FunctionsManagementPage(IFixture fixture) : base(fixture)
        {
        }

        public override string PageUrl => Setting.BaseUrl + "FunctionsManagement/";
        #region elements
        private By userMenu = By.XPath("//li[@id='userMenu']/a");
        private By userMenuSearchField = By.XPath("//div[@class='select2-drop select2-display-none select2-with-searchbox select2-drop-active']/div/input");
        private By usernameList = By.XPath("//ul[@role='listbox']/li");
        private By searchingLabel = By.XPath("//li[.='Searching…']");
        private By popupMessage = By.XPath("//p[@class='content']");
        private By searchInput = By.XPath("id('select2-drop')/div/input");
        private By searchResultLabel = By.XPath("//ul[@role='listbox']//div");
        private By functionTitleField = By.XPath("//input[contains(@data-url,'CheckForNewFunctionAccess')]");
        private By shortDefinitionInput = By.XPath("//textarea[@id='Description']");
        private By responsibilityInput = By.XPath("//textarea[@id='Responsibilities']");
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
            WaitElementIsVisibled(searchResultLabel);
            List<IWebElement> listUsername = Finds(searchResultLabel);
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
        public void CreateFunction()
        {
            var createFunctionButton = By.XPath("//a[@class='btn btn-success']");
            Click(createFunctionButton);
        }
        public void CheckIsAtFunctionProfilePage()
        {
            WaitPageLoadReady();
            var createFunctionLabel = By.XPath("//h2[contains(text(),'Function Profile')]");
            if (!IsVisibled(createFunctionLabel))
            {
                Assert.IsFalse(true);
            }
        }
        public void CheckIsAtFunctionsManagementPage()
        {
            WaitPageLoadReady();
            string currentUrl = BroswerUrl;
            LogInfo(currentUrl);
            LogInfo(PageUrl);
            var result = currentUrl.Equals(PageUrl);
            Assert.IsTrue(result, string.Format("This is not FunctionsManagement page"));
        }
        public void ExpandGeneralInfo()
        {
            var generalInfo = By.XPath("//h5[@class='accordion-toggle']//b[contains(text(),'GENERAL')]");
            Click(generalInfo);
            var generalInfoSectionExpanded = By.XPath("//div[@class='panel-body collapse in']");
            WaitElementIsVisibled(generalInfoSectionExpanded);
        }
        public void SelectDept(string deptname)
        {
            var departmentField = By.XPath("//div[@id='s2id_DepartmentId']//span[@class='select2-chosen']");
            Click(departmentField);
            TypeText(searchInput, deptname);
            WaitElementIsVisibled(searchResultLabel);
            PressEnter(searchInput);
        }
        public void InputFunctionName(string functionname)
        {
            TypeText(functionTitleField, functionname);
        }
        public void SelectFunctionType()
        {
            var typeField = By.XPath("//span[@id='select2-chosen-5']");
            var optionStaff = By.XPath("//div[.='Staff']");
            Click(typeField);
            Click(optionStaff);
        }
        public void SelectParentFunction(string parentfunctionname)
        {
            var parentfunctionField = By.XPath("//span[@id='select2-chosen-6']");
            Click(parentfunctionField);
            TypeText(searchInput, parentfunctionname);
            WaitElementIsVisibled(searchResultLabel);
            parentfunctionname = parentfunctionname.ToLower();
            List<IWebElement> listParent = Finds(searchResultLabel);
            foreach (var returnParent in listParent)
            {
                if (GetText(returnParent).ToLower().Equals(parentfunctionname))
                {
                    Click(returnParent);
                    break;
                }
            }
            WaitPageLoadReady();
        }
        public void InputShortDefinition(string definitioncontent)
        {
            TypeText(shortDefinitionInput, definitioncontent);
        }
        public void InputResponsibility(string responsibilitycontent)
        {
            TypeText(responsibilityInput, responsibilitycontent);
        }
        public void SelectFocus()
        {
            var focusField = By.XPath("//span[@id='select2-chosen-8']");
            var optionCorporate = By.XPath("//div[.='Corporate']");
            Click(focusField);
            Click(optionCorporate);
        }
        public void SelectInheritedFunction(string inheritedfunction)
        {
            var inheritanceField = By.XPath("//div[@id='s2id_InheritancePermissions']");
            //Click(inheritanceField);
            TypeText(inheritanceField, inheritedfunction);
            WaitElementIsVisibled(searchResultLabel);
            inheritedfunction = inheritedfunction.ToLower();
            List<IWebElement> listInheritance = Finds(searchResultLabel);
            foreach (var returninheritancet in listInheritance)
            {
                if (GetText(returninheritancet).ToLower().Equals(inheritedfunction))
                {
                    Click(returninheritancet);
                    break;
                }
            }
            WaitPageLoadReady();
            Wait(10000);
        }
        public void ClickValidateButton()
        {
            var validateButton = By.XPath("//input[@id='button1']");
            Click(validateButton);
        }
        public void SearchFunction(string functionname)
        {
            var searchField = By.XPath("//input[@class='form-control hasclear']");            
            TypeText(searchField, functionname);
            PressEnter(searchField);
            var loadingIcon = By.XPath("//div[@class='loadingInfiniteScroll']");
            WaitElementIsInvisibled(loadingIcon);           
        }
        public void ValidateNewFunction(string newfunctionname)
        {
            var functionList = By.XPath("//tbody[@id='functionList']//tr//td//div[@class='tooltip-wrapper']");
            newfunctionname = newfunctionname.ToLower();
            List<IWebElement> listfunction = Finds(functionList);
            foreach (var returnfunction in listfunction)
            {
                if (GetText(returnfunction).ToLower().Equals(newfunctionname))
                {
                    LogInfo("New function is created successfully");
                    break;
                }
            }
            return;
        }
        public void OpenFunctionProfilePage(string functionname)
        {
            var functionList = By.XPath("//tbody[@id='functionList']//td[@width='26%']/div[@class='tooltip-wrapper']");
            functionname = functionname.ToLower();
            List<IWebElement> listfunction = Finds(functionList);
            int trIndex = 0;
            foreach (var returnfunction in listfunction)
            {
                trIndex = trIndex + 1;
                if (GetText(returnfunction).ToLower().Equals(functionname))
                {                    
                     break;
                }
            }
            var infoButton = By.XPath(string.Format("//tbody[@id='functionList']//tr[{0}]//div[@data-original-title='Function Profile']", trIndex));
            Click(infoButton);
            return;
        }
        public void CheckFunctionProfilePageTitle(string functionname)
        {
            var functiontitle = By.XPath("//h2[contains(text(),'Function Profile')]/following-sibling::div[3]");
            functionname = functionname.ToLower();
            //if (GetText(functiontitle).ToLower().Contains(functionname))
            //{
            //    Assert.IsTrue(true);
            //}
            //else
            //{
            //    LogInfo(string.Format("This is not {0} profile page", functionname));
            //    Assert.IsTrue(false);
            //}
            var result = GetText(functiontitle).ToLower().Contains(functionname);
            Assert.IsTrue(result, string.Format("This is not {0} profile page", functionname));
        }
        public void AddTextToFunctionTitleField(string text)
        {
            TypeText(functionTitleField, text);
        }
        public void ClearAndTypeTextShortDefinition(string text)
        {
            ClearAndTypeText(shortDefinitionInput, text);
        }
        public void ClearAndTypeTextResponsibility(string text)
        {
            ClearAndTypeText(responsibilityInput, text);
        }
        public void ValidateEditingSuccessfully()
        {
            var notification = By.XPath("//div[@class='alert alert-success']");
            Assert.IsTrue(IsVisibled(notification), string.Format("Editing unsuccessfully"));
        }
    }
}

