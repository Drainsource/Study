using HomeWorkTextFiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWorkTextFiles
{
    public static class TextFile
    {
       
        public static void WriteAllPeople(List<PersonModel> people, string textFile, char deliminator)
        {



            StringBuilder stringBuilder = new StringBuilder();

            foreach (PersonModel person in people)
            {
                stringBuilder.Append(person.FirstName);
                stringBuilder.Append(deliminator);
                stringBuilder.Append(person.LastName);
                stringBuilder.Append(deliminator);
                stringBuilder.Append(person.Email);
                stringBuilder.Append(deliminator);
                stringBuilder.Append(person.IsActive);
                stringBuilder.AppendLine();
            }
            
            File.WriteAllText(textFile, stringBuilder.ToString());
        }

        public static List<PersonModel> ReadAllPeople(string textFile, char deliminator)
        {
            List<PersonModel> people = new List<PersonModel>();

            var lines = File.ReadAllLines(textFile);

            foreach (var item in lines)
            {
                PersonModel person = new PersonModel();
                var cell = item.Split(deliminator);
                person.FirstName = cell[0];
                person.LastName = cell[1];
                person.Email = cell[2];
                person.IsActive = bool.Parse(cell[3]);
                people.Add(person);
            }



            return people;
        }
    }
}
