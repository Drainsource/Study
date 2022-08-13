

//bool isComplete = false;


//if (isComplete)
//{
//    Console.WriteLine("The statment was true.");
//}
//else
//{
//    Console.WriteLine("The statement was false.");
//    Console.WriteLine("This also run.");
//}

//Console.WriteLine("End of program.");

Console.Write("What is your first name: ");
string? firstName = Console.ReadLine();

if (firstName.ToLower() == "mate")
{
    Console.WriteLine("Hello Mr. Toth");
}
else
{
    Console.WriteLine($"Hello {firstName}");
}

Console.WriteLine("End of program.");

