//using AQC;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TravelAgencyTest.POM;

//namespace TravelAgencyTest
//{
//    [TestFixture]
//    public class UnitTest : AFixture
//    {
//        string requestId = null;
//        [Test]
//        public void CreatePage()
//        {
//            CurrentPage.GoTo<CreatePage>();
//            CurrentPage.As<LoginPage>().Login("mnguyen3@amaris.com", "Amaris2017");
//            CurrentPage.As<CreatePage>().IsAt();
//            CurrentPage.As<CreatePage>().FakeAuthento("Nguyen Manh Dong");
//            //CurrentPage.As<CreatePage>().SelectTransportationAndSercices("train", "", "", "");
//            CurrentPage.As<CreatePage>().FillTravelDate("20/01/2018", "21/01/2018");
//            CurrentPage.As<CreatePage>().FillFromAndToPlace("Ho Chi Minh", "Singapore");
//            CurrentPage.As<CreatePage>().SelectContinueButton();
//            CurrentPage.As<CreatePage>().FillHotelDetails("Singapore", "20/01/2018", "22/01/2018");
//            CurrentPage.As<CreatePage>().FillTaxiDetails();
//            CurrentPage.As<CreatePage>().FillCarRentalDetails("Ho Chi Minh", "Singapore", "20/01/2018", "22/01/2018");
//            //CurrentPage.As<CreatePage>().CheckSucessCreateRequestMessage();
//            //requestId = CurrentPage.As<CreatePage>().GetRequestId();
//        }
//        [Test]
//        public void HandleRequestPage()
//        {
//            CurrentPage.GoTo<HandleRequestPage>();
//            CurrentPage.As<LoginPage>().Login(Setting.UserName, Setting.Password);
//            CurrentPage.As<HandleRequestPage>().FakeAuthento("perianu vasilica");
//            CurrentPage.As<HandleRequestPage>().CheckPendingOnAllocationTabVisibled();
//            //CurrentPage.As<HandleRequestPage>().AllocatedRequest("15216", "LAZAR Roxana");

//            CurrentPage.As<HandleRequestPage>().SelectMyTasksTab();
//            CurrentPage.As<HandleRequestPage>().BookRequestPendingOnSupplier("15360");
//        }
//        [Test]
//        public void MyteamPage()
//        {
//            CurrentPage.GoTo<MyTeamPage>();
//            CurrentPage.As<LoginPage>().Login(Setting.UserName, Setting.Password);
//            CurrentPage.As<MyTeamPage>().FakeAuthento("Nguyen thanh Viet");
//        }
//        [Test]
//        public void ProposalDetailPage()
//        {
//            CurrentPage.GoTo<ProposalDetailsPage>("https://qaarp.amaris.com/TravelAgency/Proposal/Index/15352");
//            CurrentPage.As<LoginPage>().Login(Setting.UserName, Setting.Password);
//            CurrentPage.GoTo<ProposalDetailsPage>("https://qaarp.amaris.com/TravelAgency/Proposal/Index/15352");
//            string proposalId = CurrentPage.As<ProposalDetailsPage>().CreateFlightProposal();
//            Logger.LogInfo("flight proposalId" + proposalId);
//            CurrentPage.As<ProposalDetailsPage>().CreateFlightSegment(proposalId, "15/01/2018", "20/01/2018");
//            CurrentPage.As<ProposalDetailsPage>().CreateHotelProposal("15/01/2018", "20/01/2018");
//            proposalId = CurrentPage.As<ProposalDetailsPage>().CreateTaxiProposal();
//            Logger.LogInfo("taxi " + proposalId);
//            CurrentPage.As<ProposalDetailsPage>().CreateTaxiSegment(proposalId, "Ho Chi Minh", "Singapore");
//            CurrentPage.As<ProposalDetailsPage>().CreateTaxiSegment(proposalId, "Ho Chi Minh", "Singapore", "", "", true);
//            proposalId = CurrentPage.As<ProposalDetailsPage>().CreateCarRentalProposal();
//            Logger.LogInfo("carrental " + proposalId);
//            CurrentPage.As<ProposalDetailsPage>().CreateCarRentalSegment(proposalId, "Ho Chi Minh", "Singapore");

//        }

//        [Test]
//        public void MyRequestPageTest()
//        {
//            CurrentPage.GoTo<MyRequestPage>();
            
//        }
//    }
//}
