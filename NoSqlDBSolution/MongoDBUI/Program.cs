using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver.Core.Authentication;

internal class Program
{
    private static MongoDBDataAccess db;
    private static readonly string tableName = "Contacts";
    private static void Main(string[] args)
    {
       db = new MongoDBDataAccess("MongoContactsDB", GetConnectionString());

        ContactModel contactModel = new ContactModel
        {
            FirstName = "Mate",
            LastName = "Toth"
        };
        contactModel.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "tothmat@outlook.hu" });
        contactModel.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "test@outlook.hu" });
        contactModel.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "06203837701" });
        contactModel.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "1234567789" });

        //CreateContact(contactModel);


        Console.ReadLine();
        
    }

    public static void RemoveUser(string id)
    {
        Guid guid = new Guid(id);
        db.DeleteRecord<ContactModel>(tableName, guid);
    }

    public static void RemovePhoneNumberFromUser(string phoneNumber, string id)
    {
        Guid guid = new Guid(id);
        var contact = db.LoadRecordById<ContactModel>(tableName, guid);

        contact.PhoneNumbers = contact.PhoneNumbers.Where(x => x.PhoneNumber != phoneNumber).ToList();

        db.UpsertRecord(tableName, contact.Id, contact);
    }


    private static void UpdateContactFirstName(string firstName, string id)
    {
        Guid guid = new Guid(id);
        var contact = db.LoadRecordById<ContactModel>(tableName, guid);

        contact.FirstName = firstName;

        db.UpsertRecord(tableName, contact.Id, contact);
    }


    private static void GetContactById(string id)
    {
        Guid guid = new Guid(id);
        var contact = db.LoadRecordById<ContactModel>(tableName, guid);
        Console.WriteLine($"{contact.Id},{contact.FirstName} {contact.LastName}");
    }

    private static void GetAllContacts()
    {
        var contacts = db.LoadAllRecords<ContactModel>(tableName);
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{ contact.Id },{ contact.FirstName } { contact.LastName }");
        }
    }


    private static void CreateContact(ContactModel contact)
    {
        db.UpsertRecord(tableName, contact.Id, contact);
    }

    private static string GetConnectionString(string connectionStringName = "Default")
    {
        string output = "";

        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        var config = builder.Build();

        output = config.GetConnectionString(connectionStringName);

        return output;
    }
}