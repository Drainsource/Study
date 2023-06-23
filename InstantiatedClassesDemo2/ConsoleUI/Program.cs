using ConsoleUI;







List<PersonModel> people = new List<PersonModel>();
PersonModel person = new PersonModel();

person.FirstName = "Tim";
people.Add(person);

person = new PersonModel();
person.FirstName = "Sue";
people.Add(person);

foreach (PersonModel p in people)
{
    Console.WriteLine(p.FirstName);
}





