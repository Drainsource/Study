using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class PersonModel
    {
        public PersonModel()
        {

        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //public int Age { get; set; }

        private int _age;

        public int Age
        {
            get 
            { 
                return _age; 
            }
            set 
            {
                if (value >= 0 && value < 126)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value", "Age needs to be in a valid range.");
                }
            }
        }

        //public string SSN { get; set; }

        private string _ssn;

        public string SSN
        {
            get 
            { 
                string output = "***-**-" + _ssn.Substring(_ssn.Length - 4);
                return output; 
            }
            set { _ssn = value; }
        }



    }
}
