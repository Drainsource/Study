﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkAbstract
{
    public abstract class Vehicle : IVehicle
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
    }
}
