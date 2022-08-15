using ConsoleUI;



string firstName = RequestData.GetAString("What is your first name?");

UserMessages.ApplicitionStartMessage(firstName);

double x = RequestData.GetANumber("Please enter your first number: ");
double y = RequestData.GetANumber("Please enter your second number: ");

double result = CalculateData.Add(x, y);
UserMessages.PrintResultMessage($"The sum of {x} and {y} is {result}");

Console.ReadLine();





