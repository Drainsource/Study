using Foreach;

List<Person> people = new List<Person>();

people.Add(new Person { FirstName = "Mate", LastName = "Toth"});
people.Add(new Person { FirstName = "Fanni", LastName = "Jurasits" });
people.Add(new Person { FirstName = "Merci", LastName = "Toth" });


foreach (var person in people)
{
    Console.WriteLine($"The person name is { person.FirstName } { person.LastName }");
}

Console.ReadLine();

