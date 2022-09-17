using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataAccessLibrary
{
    public class TextFileDataAccess
    {
        public List<ContactModel> ReadAllRecords(string textFile)
        {
            if (File.Exists(textFile) == false)
            {
                return new List<ContactModel>();
            }


            var lines = File.ReadAllLines(textFile);
            List<ContactModel> output = new List<ContactModel>();

            foreach (var line in lines)
            {
                ContactModel contact = new ContactModel();
                var vals = line.Split(',');
                if (vals.Length < 4)
                {
                    throw new Exception($"Invalid row of data: { line }");
                }

                contact.FirstName = vals[0];
                contact.LastName = vals[1];
                contact.EmailAddresses = vals[2].Split(';').ToList();
                contact.PhoneNumbers = vals[3].Split(';').ToList();

                output.Add(contact);
            }

            return output;
        }

        public void WriteAllRecords(List<ContactModel> contacts, string textFile)
        {
            List<string> lines = new List<string>();

            foreach (var item in contacts)
            {
                lines.Add($"{ item.FirstName },{ item.LastName },{ String.Join(';', item.EmailAddresses) },{String.Join(';', item.PhoneNumbers) }");
            }

            File.WriteAllLines(textFile, lines);
        }
    }
}
