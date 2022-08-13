
using System.Globalization;

DateTime today = DateTime.Now;

//DateTime birthday = DateTime.Parse("1988/6/23");

DateTime birthday = DateTime.ParseExact("6/11/1988", "d/MM/yyyy", CultureInfo.InvariantCulture);


Console.WriteLine(today.ToString("MMM dd, yyyy hh:mm tt zzz"));

