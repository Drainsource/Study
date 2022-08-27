using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkExtensionMethod
{
    public static class ExtensionMethods
    {
        public static Person SetDefaultAge(this Person person)
        {
            person.Age = 18;
            return person;
        }

        public static Person PrintInfo(this Person person)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age}");
            return person;
        }
    }
}
