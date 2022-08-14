//string[] firstNames = new string[5];

//firstNames[0] = "Tim";
//firstNames[1] = "Sue";
//firstNames[2] = "Bob";
//firstNames[4] = "Jane";

//Console.WriteLine($"{firstNames[0]}");

string data = "Tim,Sue,Bob,Jane,Frank";
string[] firstNames = data.Split(',');

Console.WriteLine(firstNames.Length);

Console.WriteLine(firstNames[firstNames.Length-1]);

string[] lastNames = new string[] { "Corey", "Smith", "Jones" };

int[] ages = new int[] { 1, 2, 3, 4 };
