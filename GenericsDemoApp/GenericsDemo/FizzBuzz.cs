using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    public class FizzBuzz
    {
        public static string Fizzbuzz<T>(T item)
        {
           int itemLenght = item.ToString().Length;
            string output = "";
            if (itemLenght % 3 == 0)
            {
                output += "Fizz";
            }

            if (itemLenght % 5 == 0)
            {
                output += "Buzz";
            }

            return output;
        }
    }
}
