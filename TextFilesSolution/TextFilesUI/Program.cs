using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;







internal class Program
{
    private static IConfiguration _config;
    private static string textFile;
    private static TextFileDataAccess _access = new TextFileDataAccess();
    private static void Main(string[] args)
    {
        InitializeConfiguration();
        textFile = _config.GetValue<string>("TextFile");
        ContactModel user1 = new ContactModel();
        user1.FirstName = "Mate";
        user1.LastName = "Toth";
        user1.EmailAddresses.Add("tothmat@outlook.hu");
        user1.EmailAddresses.Add("tothmat3@gmail.com");
        user1.PhoneNumbers.Add("06203837701");
        user1.PhoneNumbers.Add("123456789");


        ContactModel user2 = new ContactModel();
        user2.FirstName = "Fanni";
        user2.LastName = "Jurasits";
        user2.EmailAddresses.Add("test@outlook.hu");
        user2.EmailAddresses.Add("test@gmail.com");
        user2.PhoneNumbers.Add("06303040507");
        user2.PhoneNumbers.Add("123456789");


        //CreateContact(user1);
        //CreateContact(user2);   
        //GetAllContacts();

        //UpdateContactsFirstName("Mat");
        //GetAllContacts();

        //Console.WriteLine();

        //RemovePhoneNumberFromUser("06203837701");
        //GetAllContacts();

        //Console.WriteLine("Done");
        //Console.ReadLine();

        RemoveUser();
        GetAllContacts();

    }
    private static void RemoveUser()
    {
        var contacts = _access.ReadAllRecords(textFile);
        contacts.RemoveAt(0);
        _access.WriteAllRecords(contacts, textFile);
    }

    private static void RemovePhoneNumberFromUser(string phoneNumber)
    {
        var contacts = _access.ReadAllRecords(textFile);
        contacts[0].PhoneNumbers.Remove(phoneNumber);
        _access.WriteAllRecords(contacts, textFile);
    }

    private static void GetAllContacts()
    {
        var contacts = _access.ReadAllRecords(textFile);

        foreach (var contact in contacts)
        {
            Console.WriteLine($"{ contact.FirstName } { contact.LastName }");
        }
    }

    private static void CreateContact(ContactModel contact)
    {
        var contacts = _access.ReadAllRecords(textFile);

        contacts.Add(contact);

        _access.WriteAllRecords(contacts, textFile);
    }

    private static void UpdateContactsFirstName(string firstName)
    {
         var contacts = _access.ReadAllRecords(textFile);
        contacts[0].FirstName = firstName;
        _access.WriteAllRecords(contacts, textFile);
    }

    private static void InitializeConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        _config = builder.Build();

    }
}