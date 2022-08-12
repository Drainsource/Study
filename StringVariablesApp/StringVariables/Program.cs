

string firstName = string.Empty;
string lastName = string.Empty;
string filePath = string.Empty;

firstName = "Mate";
lastName = "Toth";
filePath = "C:\\Temp\\Demo";
filePath = @"C:\Temp\Demo";

//firstName = "123";

//Console.WriteLine(firstName + " " + lastName);

string testString = $@"The file for {firstName} is at C:\SampleFiles";


Console.WriteLine($"{firstName} {lastName}");
Console.WriteLine(filePath);
  