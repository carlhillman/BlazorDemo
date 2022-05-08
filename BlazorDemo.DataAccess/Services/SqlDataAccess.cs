using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Dapper;

namespace BlazorDemo.DataAccess.Services
{
    public class SqlDataAccess:ISqlDataAccess
    {
        private readonly IConfiguration _config;
        private string ConnectionString { get; set; } = "BlazorDemoConnection";
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
            ConnectionString = _config.GetConnectionString(ConnectionString);
        }
        public async Task<T> LoadDataNoParameterAsync<T>(string sql)
        {
    
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                var data = await connection.QueryFirstOrDefaultAsync<T>(sql);
                return data;
            }
        }

        public async Task<T> LoadDataEntityAsync<T, TU>(string sql, TU parameters)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                var data = await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
                return data;
            }
        }

        public async Task<List<T>> LoadDataListAsync<T, TU>(string sql, TU parameters)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }

        public async Task <bool>ExecuteSqlAsync<T>(string sql, T parameters)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    await connection.ExecuteAsync(sql, parameters);
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}
