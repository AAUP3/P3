using Dapper;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "Default";

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);

                return data.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task<T> LoadDataSingle<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);

                return data.FirstOrDefault();
            }
        }

        public async Task SaveDataTest(string sql)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql);
            }
        }


        public List<UnionActivityModel> LoadDataTest(string sql)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = connection.Query(sql);

                //data = data.ToList();

                //return (List<UnionActivityModel>)data;
                if (data != null)
                {
                    return data.OfType<UnionActivityModel>().ToList();
                }
                else
                {
                    throw new Exception("Tom");
                }
            }
        }


        public List<T> LoadDataNew<T>(string sql)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                var output = cnn.Query<T>(sql, new DynamicParameters());
                return output.ToList();
            }
        }


    }
}
