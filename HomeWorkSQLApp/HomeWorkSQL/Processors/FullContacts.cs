using HomeWorkSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkSQL.Processors
{
    public class FullContacts
    {
        private readonly string _connectionStringName;

        private DataAccess _dataAccess = new();
        public FullContacts(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
        }

        public int Add(FullContactModel fullContact)
        {
            string sql = "insert into dbo.People (FirstName, LastName, IsActive) values (@FirstName, @LastName, @IsActive) select @@IDENTITY";
            var personId = _dataAccess.SaveData(sql, fullContact.person, _connectionStringName);
            
            sql = @"insert into dbo.Addresses (PersonId, StreetAddress, City, State, ZipCode) 
                    values (@PersonId, @StreetAddress, @City, @State, @ZipCode)
                    select @@IDENTITY";
            foreach (var item in fullContact.addresses)
            {
                item.PersonId = personId;
                _dataAccess.SaveData(sql, item, _connectionStringName);
            }

            return personId;
        }


        public FullContactModel Load(int personId)
        {
            FullContactModel fullContact = new FullContactModel();
            string sql = "select Id, FirstName, LastName, IsActive from dbo.People where Id = @Id";
            fullContact.person = _dataAccess.LoadData<PersonModel, dynamic>(sql, new { Id = personId }, _connectionStringName).FirstOrDefault();

            sql = "select a.* from dbo.Addresses a where PersonId = @PersonId";
            fullContact.addresses = _dataAccess.LoadData<AddressModel, dynamic>(sql, new { PersonId = personId }, _connectionStringName).ToList();

            return fullContact;
        }
    }
}
