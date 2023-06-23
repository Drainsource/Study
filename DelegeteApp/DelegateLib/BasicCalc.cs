using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace DelegateLib
{
    public static class BasicCalc
    {
        public static T Add<T>(T x, T y) where T : INumber<T>
        {
            return x + y;
        }

        public static T Subtract<T>(T x, T y) where T : INumber<T>
        { 
            return x - y; 
        }
    }
}
