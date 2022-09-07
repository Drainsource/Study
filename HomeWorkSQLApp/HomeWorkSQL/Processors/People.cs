using HomeWorkSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkSQL.Processors
{
    public class People
    {
        private readonly string _connectionString;

        private DataAccess _dataAccess = new();

        public People(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(PersonModel personModel)
        {
            string sql = "insert into dbo.People (FirstName, LastName, IsActive) values (@FirstName, @LastName, @IsActive) select @@IDENTITY;";
            return _dataAccess.SaveData(sql, personModel, _connectionString);
        }


    }
}
