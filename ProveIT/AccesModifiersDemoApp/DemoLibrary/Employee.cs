using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary;

public class Employee : Person
{
    public string GetFormerLastName()
    {
        return _formerLastName;
    }
}
