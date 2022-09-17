using HomeWorkTextFiles;
using HomeWorkTextFiles.Models;




List<PersonModel> people = new();
string textfile = "D:\\Demos\\Person.csv";
people.Add(new PersonModel { FirstName = "Mate", LastName = "Toth", IsActive = true, Email = "tohmat@outlook.hu" });
people.Add(new PersonModel { FirstName = "Fanni", LastName = "Jurasits", IsActive = true, Email = "jurasitsfanni@gmail.hu" });

//TextFile.WriteAllPeople(people,textfile, ',');
TextFile.ReadAllPeople(textfile, ',');

Console.ReadLine();


