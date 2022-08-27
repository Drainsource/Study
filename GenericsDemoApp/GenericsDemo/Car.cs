using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    public class Car : IErrorCheck
    {
        public string Manufacturer { get; set; }
        public int YearOfManufaterd { get; set; }
        public bool HasError { get; set; }
    }
}
