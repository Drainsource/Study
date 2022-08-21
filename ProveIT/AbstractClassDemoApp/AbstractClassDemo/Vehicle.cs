using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassDemo
{
    public abstract class Vehicle
    {
        public string VIN { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int YearManufactured { get; set; }
    }
}
