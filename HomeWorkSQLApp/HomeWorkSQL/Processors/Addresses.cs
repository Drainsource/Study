using HomeWorkSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkSQL.Processors
{
    public class Addresses
    {
        private readonly string _connectionString;

        private DataAccess _dataAccess = new();
        public Addresses(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(AddressModel address)
        {
                string sql = @"insert into dbo.Addresses (PersonId, StreetAddress, City, State, ZipCode) 
                                                  values (@PersonId, @StreetAddress, @City, @State, @ZipCode) select @@IDENTITY";
                return _dataAccess.SaveData(sql, address, _connectionString);
    
        }
    }
}
