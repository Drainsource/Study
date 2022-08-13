
Console.Write("What is your first name: ");
string? firstName = Console.ReadLine();

Console.Write("What is your last name: ");
string? lastName = Console.ReadLine();

if (firstName.ToLower() == "mate" &&
    lastName.ToLower() == "toth")
{
    Console.WriteLine("Hell Toth Mate");
}
else if (firstName.ToLower() == "mate" ||
         lastName.ToLower() == "toth")
{
    Console.WriteLine("You have a great name.");
}



//if (firstName.ToLower() == "mate" && 
//    lastName.ToLower() == "toth")
//{
//    Console.WriteLine("Hello Mr. Toth");
//}
//else if (firstName.ToLower() == "mate")
//{
//    Console.WriteLine("You have a cool name!");
//}
//else if (firstName.ToLower() == "toth")
//{
//    Console.WriteLine("You have a great last name!");
//}
//else
//{
//    Console.WriteLine("noob");
//}

//if (firstName == "mate")
//{
//    Console.WriteLine("You have a cool name!");
//}

//int age = 100;

//if (age >= 100)
//{
//    Console.WriteLine("You are up there in years");
//}

//if (age >= 40 && age < 50)
//{
//    Console.WriteLine("You are in your 40's");
//}