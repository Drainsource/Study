bool isNumber;
int age;
string? name;

do
{
    Console.Write("What is your name: ");
    name = Console.ReadLine();
} while (name == "");

do
{
    Console.Write("How old are you: ");
    string? ageText = Console.ReadLine();
    isNumber = int.TryParse(ageText, out age);
} while (!isNumber);

if (name.ToLower() == "bob" || name.ToLower() == "sue")
{
    Console.WriteLine($"Hello Professor {name}");
}
if (isNumber && age < 21)
{
    Console.WriteLine($"Please wait {21 - age} to start this class");
}
else
{
    Console.WriteLine($"Welcome to class {name}");
}
