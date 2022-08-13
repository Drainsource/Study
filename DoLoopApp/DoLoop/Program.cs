
bool isValidAge;
int age;
do
{
	Console.WriteLine("Whait is your age: ");
	string? ageText = Console.ReadLine();
	isValidAge = int.TryParse(ageText, out age);

	if (!isValidAge)
	{
		Console.WriteLine("Thats was an ivalid age.");
	}

} while (!isValidAge);

Console.WriteLine($"Your age is {age}");



//do
//{

//} while (true);

//while (true)
//{

//}
