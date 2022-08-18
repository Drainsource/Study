using GuestBookLibrary.Models;


List<GuestModel> guests = new();
string moreMoreGuest = "";
do
{
    GuestModel guest = new GuestModel();
    Console.Write("What is your first name: ");
    guest.FirstName = Console.ReadLine();

    Console.Write("What is your last name: ");
    guest.LastName = Console.ReadLine();

    Console.Write("What message would you like to tell your host: ");
    guest.MessageToHost = Console.ReadLine();

    Console.Write("Are more guests comming (yes/no) : ");
    moreMoreGuest = Console.ReadLine();

    guests.Add(guest);

} while (moreMoreGuest.ToLower() == "yes");

foreach (var guest in guests)
{
    Console.WriteLine(guest.GuestInfo);
}

Console.ReadLine();

