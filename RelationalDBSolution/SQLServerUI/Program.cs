using Microsoft.Extensions.Configuration;
using DataAccessLibrary;
using DataAccessLibrary.Models;




SqlCrud sql = new SqlCrud(GetConnectionString());

//ReadAllContacts(sql);

//ReadAllContact(sql, 1);
//CreateNewContact(sql);
//UpdateContact(sql);
RemovePhoneNumberFromContact(sql, 1, 1);



Console.WriteLine("Done");
Console.ReadLine();



static void RemovePhoneNumberFromContact(SqlCrud sql, int contactId, int phoneNumberId)
{
    sql.RemovePhoneNumberFromContact(contactId, phoneNumberId);
}

static void UpdateContact(SqlCrud sql)
{
    BasicContactModel contactModel = new BasicContactModel
    {
        Id = 1,
        FirstName = "Mateka",
        LastName = "Toth"
    };

    sql.UpdateContactName(contactModel);
}

static void CreateNewContact(SqlCrud sql)
{
    FullContactModel model = new FullContactModel
    {
        BasicInfo = new BasicContactModel
        {
            FirstName = "Fanni",
            LastName = "Jurasits"
        }
    };

    model.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "test@test.com" });
    model.EmailAddresses.Add(new EmailAddressModel { Id = 2, EmailAddress = "me@test.com" });


    model.PhoneNumbers.Add(new PhoneNumberModel { Id = 3, PhoneNumber = "12345678" });
    model.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "9876543" });

    sql.CreateContact(model);
}

static void ReadAllContacts(SqlCrud sql)
{
    var rows = sql.GetAllContacts();

    foreach (var row in rows)
    {
        Console.WriteLine($"{row.Id}: {row.FirstName} {row.LastName}");
    }
}

static void ReadAllContact(SqlCrud sql, int contactId)
{
    var contact = sql.GetFullContactById(contactId);

    Console.WriteLine($"{contact.BasicInfo.Id}: {contact.BasicInfo.FirstName} {contact.BasicInfo.LastName}");
   
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
