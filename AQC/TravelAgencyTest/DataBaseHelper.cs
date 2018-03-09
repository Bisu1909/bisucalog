using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.Common;
using System.Configuration;
using AQC;
using System.Data;
using System.Data.SqlClient;

namespace TravelAgencyTest
{
    public class DataBasehelper
    {
        DbConnection conn;
        string connectionString = "Data Source=localhost;Initial Catalog=SMART_Amaris;Integrated Security=True";
        DbProviderFactory factory;
        public DataBasehelper()
        {
            this.connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            factory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings[0].ProviderName.ToString());
        }
        public DataBasehelper(string connectionString, string connectionProviderName)
        {
            this.connectionString = connectionString;
            factory = DbProviderFactories.GetFactory(connectionProviderName);
        }

        string query = "select * from dbo.employee where employeeid = 2";

        public void CustomExecuteQuery()
        {
            IDbConnection db = new SqlConnection(connectionString);
            
        }

    }
}
