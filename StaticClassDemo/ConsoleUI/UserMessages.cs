using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI;

public class UserMessages
{
    public static void ApplicitionStartMessage(string name)
    {
        Console.WriteLine("Welcome to the static Class Demo App");

        int hourOfDay = DateTime.Now.Hour;

        if (hourOfDay < 12)
        {
            Console.WriteLine($"Good morning {name}!");
        }
        else if (hourOfDay < 19)
        {
            Console.WriteLine($"Good afternoon {name}!");
        }
        else
        {
            Console.WriteLine($"Good evening {name}!");
        }
    }

    public static void PrintResultMessage(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine();
        Console.WriteLine("Thank you for using our app to calculate for you!");
    }
}
