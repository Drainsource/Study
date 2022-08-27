using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    public interface IErrorCheck
    {
        public bool HasError { get; set; }
    }
}
