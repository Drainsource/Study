using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI;

public class RequestData
{
    public static string GetAString(string message)
    {
        Console.WriteLine(message);
        string value = Console.ReadLine();
        return value;
    }
    public static double GetANumber(string message)
    {
        Console.WriteLine(message);
        string numberText = Console.ReadLine();
        double value;

        bool isDouble = double.TryParse(numberText, out value);

        while (isDouble == false)
        {
            Console.WriteLine("That was not a valid number. Please try again.");
            Console.WriteLine(message);
            numberText = Console.ReadLine();

            isDouble = double.TryParse(numberText, out value);
        }
        return value;
    }
}
