using Microsoft.Extensions.Configuration;
using HomeWorkSQL.Models;
using HomeWorkSQL.Processors;


People peopleProcessor = new(GetConnectionString());
FullContacts fullContactsProcessor = new(GetConnectionString());
//PersonModel model = new PersonModel
//{
//    FirstName = "Mate",
//    LastName = "Toth",
//    IsActive = true
//};

FullContactModel model = new FullContactModel
{
    addresses = new List<AddressModel>
    { 
        new AddressModel {
        StreetAddress = "Vaci ut 132/B 2/9",
        City = "Budapest",
        State = "Budapest",
        ZipCode = "1138"
        }
    },
    person = new PersonModel
    {
        FirstName = "Mate",
       LastName = "Toth",
       IsActive = true
    }
};

PersonModel fanni = new PersonModel
{
    FirstName = "Fanni",
    LastName = "Jurasits",
    IsActive = true
};

//AddPerson(peopleProcessor, fanni);

FullContactModel fullmodel = LoadFullContact(fullContactsProcessor, 2);

//AddFullContact(fullContactsProcessor, model);
//AddPerson(peopleProcessor, model);

Console.WriteLine("Done");

Console.ReadLine();


static FullContactModel LoadFullContact(FullContacts fullContactsProcessor, int personId)
{
    return fullContactsProcessor.Load(personId);
}


static void AddFullContact(FullContacts fullContactsProcessor, FullContactModel fullContact)
{
    var id = fullContactsProcessor.Add(fullContact);
}


static void AddPerson(People peopleProcessor, PersonModel person)
{
    var id = peopleProcessor.Add(person);
}




static string GetConnectionString(string connectionStringName = "Default")
{
    string output = "";

    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json");

    var config = builder.Build();

    output = config.GetConnectionString(connectionStringName);

    return output;
}