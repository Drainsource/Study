

DateTime today = DateTime.Now;

DateOnly birthday = DateOnly.Parse("6/11/1988");

Console.WriteLine(birthday.ToString("MMMM dd, yyyy"));

Console.WriteLine($"Today full format: {today}");
Console.WriteLine($"Today just date {today.Date}");
Console.WriteLine($"Birthday full format {birthday}");


// Practice



DateTime tomorow = DateTime.Now + TimeSpan.FromDays(1);
Console.WriteLine(tomorow);

DateOnly nextYear = DateOnly.FromDateTime(DateTime.Now + TimeSpan.FromDays(365));
Console.WriteLine(nextYear);