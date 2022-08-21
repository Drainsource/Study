

Console.Write("Enter a date (yyyy mm dd format): ");
string date = Console.ReadLine();

DateTime.TryParse(date, out DateTime dateTime);
var timeSpan = DateTime.Now - dateTime;



Console.WriteLine($"This was { timeSpan.Days }");

Console.Write("Enter a the time (HH:mm): ");
string time = Console.ReadLine();


TimeOnly.TryParse(time, out TimeOnly datetimePrase);

Console.WriteLine($"{TimeOnly.FromDateTime(DateTime.Now) - datetimePrase }");



