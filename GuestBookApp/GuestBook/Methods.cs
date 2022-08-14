using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook;

public static class Methods
{
    public static (string, int) NewGuestFamily()
    {
        int faimilySize;
        bool isValid;
        Console.Write("Family Name: ");
        string familyName = Console.ReadLine();
        do
        {
            Console.Write("How many people comming: ");
            string faimilySizeText = Console.ReadLine();
            isValid = int.TryParse(faimilySizeText, out faimilySize);
        } while (!isValid);

        return (familyName, faimilySize);
    }

    public static bool AreNewFamiliesComming()
    {
        string statement;
        do
        {
            Console.WriteLine("Are new families comming to the party? y/n");
            statement = Console.ReadLine();
            if (statement == "y")
            {
                return true;
            }
            else if (statement == "n")
            {
                return false;
            }
        } while (true);
        
    }

    public static void PrintOutFamilies(List<(string, int)> families)
    {
        int totalGuests = 0;
        foreach (var family in families)
        {
            Console.WriteLine($"Family name is: {family.Item1} and they are {family.Item2}");
            totalGuests += family.Item2;
        }
        Console.WriteLine($"The total number of guests is {totalGuests}");
    }

}
