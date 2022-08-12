

// - Welcome User to App
Console.WriteLine("Welcome to the Greeting Applipication");
Console.WriteLine("This application was built by Mate");
Console.WriteLine("-------------------------------------");
Console.WriteLine();

// - Ask for First Name
Console.WriteLine("Please enter your first name");
string? name = Console.ReadLine();
while (name == "")
{
    Console.WriteLine("That is not a valid name!");
    Console.WriteLine("Please enter your first name");
    name = Console.ReadLine();
}
// - Greet user by name
Console.WriteLine($"Hello { name }");
Console.ReadLine();

