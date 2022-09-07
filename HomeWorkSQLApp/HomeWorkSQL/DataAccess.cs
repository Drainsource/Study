using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkSQL
{
    public class DataAccess
    {

        public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionString)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                return cnn.Query<T>(sqlStatement, parameters).ToList();
            }
        }

        public int SaveData<T>(string sqlStatement, T parameters, string connectionString)
        {
            using (IDbConnection cnn = new SqlConnection(connectionString))
            {
                return cnn.ExecuteScalar<int>(sqlStatement, parameters);
            }
        }
    }
}
