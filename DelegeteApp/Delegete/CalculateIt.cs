using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Delegete
{
    public class CalculateIt<T> where T : INumber<T>
    {
        public delegate T MathOperation(T x, T y);

        public T SumOrSub(MathOperation mathOperation, T x, T y)
        {
            return mathOperation(x, y);
        }

    }
}
