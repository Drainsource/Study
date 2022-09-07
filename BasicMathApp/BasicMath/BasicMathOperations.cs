using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMath
{
    public class BasicMathOperations
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }

        public double Multiple(double x, double y)
        {
            return x * y;
        }

        public double Divide(double x, double y)
        {
            if (y != 0)
            {
                return x / y;
            }
            else
            {
               throw new DivideByZeroException();
            }
            
        }
    }
}
