

Console.Write("What is your age: ");
string? ageText = Console.ReadLine();


bool isValidInt = int.TryParse(ageText, out int age);

Console.WriteLine($"This is valid: {isValidInt}. The number was {age}.");

Console.WriteLine(age + 15);

