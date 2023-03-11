using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WemaAnalyticsAPI.DataAccess
{
    public class SqlDataAccess
    {
        private readonly IConfiguration config;
        private readonly string connectionString;

        public SqlDataAccess(IConfiguration configuration)
        {
            config = configuration;
            connectionString = config.GetConnectionString("WemaAnalyticsDB");
        }


        public async Task<IEnumerable<T>> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(config.GetConnectionString("WemaAnalyticsDB")))
            {
                return await cnn.QueryAsync<T>(sql);
            }
        }

        public async Task<IEnumerable<T>> SPLoadData<T>(string spName, T parameters)
        {
            using (IDbConnection cnn = new SqlConnection(config.GetConnectionString("WemaAnalyticsDB")))
            {
                return await cnn.QueryAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure, commandTimeout: 0);
            }
        }        
        
        public async Task<IEnumerable<T>> SPLoadData<T>(string spName)
        {
            using (IDbConnection cnn = new SqlConnection(config.GetConnectionString("WemaAnalyticsDB")))
            {
                return await cnn.QueryAsync<T>(spName, null, commandType: CommandType.StoredProcedure, commandTimeout: 0 );
            }
        }

        public async Task<IEnumerable<T>> LoadQueryData<T>(string sql, T parameters)
        {
            using (IDbConnection cnn = new SqlConnection(config.GetConnectionString("WemaAnalyticsDB")))
            {
                return await cnn.QueryAsync<T>(sql, parameters, null, commandTimeout: 0);
            }
        }


        //public async Task<string> LoadSingleData<T>(string sql, T parameters)
        //{
        //    using (IDbConnection cnn = new SqlConnection(_con.GetConnectionString("DefaultConnection")))
        //    {
        //        return await cnn.QueryAsync<T>(sql, parameters);
        //    }
        //}
    }
}
