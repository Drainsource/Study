List<string?> studentList = new List<string>();
string? answer;


do
{
	Console.WriteLine("Add a student: ");
	studentList.Add(Console.ReadLine());
	Console.Write("Are there more Students? type 'y' if you want to continue? ");
	answer = Console.ReadLine(); 
} while (answer == "y");

Console.WriteLine($"The number of students you added  {studentList.Count}");

