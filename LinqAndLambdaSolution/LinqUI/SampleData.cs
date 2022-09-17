using LinqUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUI
{
    public static class SampleData
    {
        public static List<ContactModel> GetSampleData()
        {
            List<ContactModel> output = new List<ContactModel>
            {
                new ContactModel { Id = 1, FirstName = "Mate", LastName = "Toth", Addresses = new List<int> { 1, 2, 3 }},
                new ContactModel { Id = 2, FirstName = "Mary", LastName = "Smith", Addresses = new List<int> { 1 }},
                new ContactModel { Id = 3, FirstName = "Jane", LastName = "Jones", Addresses = new List<int> { 2 }},
                new ContactModel { Id = 4, FirstName = "Sue", LastName = "Storm", Addresses = new List<int> { 3 }},
                new ContactModel { Id = 5, FirstName = "Bilbo", LastName = "Baggins", Addresses = new List<int> { 2, 3 }}
            };

            return output;
        }

        public static List<AddressModel> GetAddressData()
        {
            List<AddressModel> output = new List<AddressModel>
            {
                new AddressModel { Id = 1, ContactId = 1, City = "Scranton", State ="PA" },
                new AddressModel { Id = 2, ContactId = 1, City = "Virgina Beach", State ="VA" },
                new AddressModel { Id = 3, ContactId = 2, City = "Philadelphia", State ="PA" },
                new AddressModel { Id = 4, ContactId = 5, City = "Virgina Beach", State ="VA" },
                new AddressModel { Id = 5, ContactId = 5, City = "Philadelphia", State ="PA" },
                new AddressModel { Id = 6, ContactId = 4, City = "Virgina Beach", State ="VA" },
                new AddressModel { Id = 7, ContactId = 3, City = "Philadelphia", State ="PA" },
            };

            return output;
        }
    }
}
