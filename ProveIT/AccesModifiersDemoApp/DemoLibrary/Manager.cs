using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class Manager : Employee
    {
        public string GetAllNames()
        {
            return $"{FirstName}, {LastName}, {_formerLastName}";
        }
    }
}
