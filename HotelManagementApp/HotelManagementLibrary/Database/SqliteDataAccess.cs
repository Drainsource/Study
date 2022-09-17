using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;

namespace HotelManagementLibrary.Database
{
    public class SqliteDataAccess : ISqliteDataAccess
    {
        private readonly IConfiguration _config;
        public SqliteDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public List<T> LoadData<T, U>(string sql, U parameters, string connectionStringName = "Default")
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        public int SaveData<T>(string sql, T parameters, string connectionStringName = "Default")
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                return connection.ExecuteScalar<int>(sql, parameters);
            }
        }
    }
}
