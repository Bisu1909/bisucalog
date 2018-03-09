using AQC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace AQC
{
    public class DbConnectionManager : IDbConnectionManager
    {
        private string _defaultConnectionStringName = "DapperConnectionString";

        public void SetDefaultConnectionStringName(string connectionStringName)
        {
            _defaultConnectionStringName = connectionStringName;
        }

        public T ExecuteScalar<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = this.GetConnection(_defaultConnectionStringName))
            {
                return connection.ExecuteScalar<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public T ExecuteScalar<T>(string connectionStringName, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = this.GetConnection(connectionStringName))
            {
                return connection.ExecuteScalar<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = this.GetConnection(_defaultConnectionStringName))
            {
                return connection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
            }
        }

        public IEnumerable<T> Query<T>(string connectionStringName, string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = this.GetConnection(connectionStringName))
            {
                return connection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
            }
        }

        public T QueryFirst<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = this.GetConnection(_defaultConnectionStringName))
            {
                return connection.QueryFirst<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public T QueryFirst<T>(string connectionStringName, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = this.GetConnection(connectionStringName))
            {
                return connection.QueryFirst<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public T QueryFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = this.GetConnection(_defaultConnectionStringName))
            {
                return connection.QueryFirstOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public T QueryFirstOrDefault<T>(string connectionStringName, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = this.GetConnection(connectionStringName))
            {
                return connection.QueryFirstOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public T QuerySingle<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = this.GetConnection(_defaultConnectionStringName))
            {
                return connection.QuerySingle<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public T QuerySingle<T>(string connectionStringName, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = this.GetConnection(connectionStringName))
            {
                return connection.QuerySingle<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public T QuerySingleOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = this.GetConnection(_defaultConnectionStringName))
            {
                return connection.QuerySingleOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public T QuerySingleOrDefault<T>(string connectionStringName, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = this.GetConnection(connectionStringName))
            {
                return connection.QuerySingleOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
            }
        }

        private IDbConnection GetConnection(string connectionStringName)
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString);
        }
    }
}
