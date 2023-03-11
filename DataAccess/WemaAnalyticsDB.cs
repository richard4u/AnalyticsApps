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
    public class WemaAnalyticsDB
    {
        private readonly IConfiguration config;
        private static string connectionString;

        public WemaAnalyticsDB(IConfiguration configuration)
        {
            config = configuration;
            connectionString = config.GetConnectionString("WemaAnalyticsDB");
    }


        public async Task<IEnumerable<T>> LoadData<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return await connection.QueryAsync<T>(sql);
            }
        }

        public async Task<IEnumerable<T>> LoadData<T>(string sql, T parameters)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return await connection.QueryAsync<T>(sql, parameters, commandType: CommandType.StoredProcedure);
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