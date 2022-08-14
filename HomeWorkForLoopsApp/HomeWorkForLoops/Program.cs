

Console.WriteLine("Please add names separeated with ','");
string nameData = Console.ReadLine();

List<string> nameList = nameData.Split(',').ToList();

for (int i = 0; i < nameList.Count; i++)
{
    Console.WriteLine($"Hello {nameList[i]}");
}



