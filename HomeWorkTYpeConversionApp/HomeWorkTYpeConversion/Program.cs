

Console.Write("How old are you: ");
string ageText = Console.ReadLine();

bool isValidNumber = int.TryParse(ageText, out int age);

if (isValidNumber)
{
    Console.WriteLine($"Your will be {age + 25} in 25 years and you were {age - 25} in 25 yeayrs ago");
}
else { Console.WriteLine("It is not a valid number"); }


