using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods;

public static class ConsoleMessages
{
    public static void SayHi(string firstName)
    {
        Console.WriteLine($"Hello {firstName}!");
        Console.WriteLine("asd");
    }

    public static string GetUserName()
    {
        Console.Write("What is your name: ");
        string name = Console.ReadLine();

        return name;
    }

    public static (string lastName, string firstName) GetFullName()
    {
        Console.Write("What is your first name: ");
        string firstName = Console.ReadLine();

        Console.Write("What is last name: ");
        string lastName = Console.ReadLine();

        return (firstName, lastName);

    }


    public static void SayGoodbay()
    {
        Console.WriteLine("Goodbye");
    }
}
