using NUnit.Framework;
using System;
using AQC.Interface;
using Dapper;

namespace AQC.Demo
{
    [TestFixture]
    public class GoogleSiteTest : AFixture
    {
        [Test]
        public void GoToGoogle()
        {
            DbConnectionManager.SetDefaultConnectionStringName("DapperConnectionString");
            var count = DbConnectionManager.ExecuteScalar<int>("Select count(*) from dbo.Employee");
            CurrentPage.GoTo<GooglePage>();
        }

        //[Test]
        //public void SearchAmarisOnGoogle()
        //{
        //    CurrentPage.GoTo<GooglePage>();
        //    //CurrentPage.As<GooglePage>().Search("Amaris");
        //    CurrentPage.As<GooglePage>().EnterSearch();
        //}
    }
}
