
using HomeWorkGeneric;



GenericMethods<Person> generic = new GenericMethods<Person>();

generic.StuffList.Add(new Person { FirstName = "Mate", LastName = "Toth", Email = "tothmat@outlook.hu", Stuff = "I got lot of stuff" });
generic.StuffList.Add(new Person { FirstName = "Fanni", LastName = "Jurasits", Email = "fannijurasits@outlook.hu", Stuff = "I got even more" });

generic.PrintStuffList();


Console.ReadLine();







