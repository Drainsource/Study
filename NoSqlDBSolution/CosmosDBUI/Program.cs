using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Azure.Cosmos.Serialization.HybridRow.Layouts;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static CosmosDBDataAccess _dataAccess;
    private static async Task Main(string[] args)
    {
        var c = GetCosmosInfo();
        _dataAccess = new CosmosDBDataAccess(c.endPointUrl, c.primaryKey, c.databaseName, c.contianerName);

        ContactModel contactModel = new ContactModel
        {
            FirstName = "Mate",
            LastName = "Toth"
        };
        contactModel.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "tothmat@outlook.hu" });
        contactModel.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "test@outlook.hu" });
        contactModel.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "06203837701" });
        contactModel.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "1234567789" });


        await CreateContact(contactModel);



        Console.WriteLine("Done Cosmos DB");
        Console.ReadLine();

    }

    private static async Task RemoveUser(string id, string lastName)
    {
        await _dataAccess.DeleteRecordAsync<ContactModel>(id, lastName);
    }

    private static async Task RemovePhoneNumberFromUser(string phoneNumber, string id)
    {
        var contact = await _dataAccess.LoadRecordByIdAsync<ContactModel>(id);

        contact.PhoneNumbers = contact.PhoneNumbers.Where(x => x.PhoneNumber != phoneNumber).ToList();

        await _dataAccess.UpsertRecord(contact);
    }

    private static async Task UpdateContactFirstName(string firstName, string id)
    {
        var contact = await _dataAccess.LoadRecordByIdAsync<ContactModel>(id);

        contact.FirstName = firstName;

        await _dataAccess.UpsertRecord(contact);
    }

    private static async Task GetContactById(string id)
    {
        var contacts = await _dataAccess.LoadRecordByIdAsync<ContactModel>(id);
    }

    private static async Task GetAllContacts()
    {
        var contacts = await _dataAccess.LoadAllRecordsAsync<ContactModel>();
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.Id},{contact.FirstName} {contact.LastName}");
        }
    }

    private static async Task CreateContact(ContactModel contact)
    {
        await _dataAccess.UpsertRecord(contact);
    }

    private static (string endPointUrl, string primaryKey, string databaseName, string contianerName) GetCosmosInfo()
    {
        (string endPointUrl, string primaryKey, string databaseName, string contianerName) output;

        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        var config = builder.Build();

        output.endPointUrl = config.GetValue<string>("CosmosDB:EndpointUrl");
        output.primaryKey = config.GetValue<string>("CosmosDB:PrimaryKey");
        output.databaseName = config.GetValue<string>("CosmosDB:DataBase");
        output.contianerName = config.GetValue<string>("CosmosDB:Container");

        return output;
    }
}