
using System.Text.RegularExpressions;

string pattern = "Mate";
//string toSearch = "Mate Toth";

Console.WriteLine("Mate Toth "+ Regex.IsMatch("Mate Toth", pattern));
Console.WriteLine("Mateka Toth " + Regex.IsMatch("Mate Toth", pattern));
