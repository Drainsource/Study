using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorkLibrary
{
    public class Generators
    {
        public string WellcomeMessage(string prefix, string lastName) 
        {
            return $"Welcome to our demo application {prefix} {lastName}";
        }

        public string FarwellMessage(string prefix, string lastName)
        {
            return $"I hope you enjoyed your time with us {prefix} {lastName}. Please come back soon.";
        }
    }
}
