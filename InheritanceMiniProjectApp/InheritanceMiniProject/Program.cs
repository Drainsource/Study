
List<InventoryItemModel> inventory = new();
List<IRentalable> rentalables = new();
List<IPurchasable> purchasables = new();

var vehicle = new VehicleModel { DealerFee = 25, ProductName = "Kia Optima" };
var book = new BookModel { ProductName = "A Tale of Two Cities", NumberOfPages = 350 };
var excavator = new ExcavatorModel { ProductName = "Bulldozer", QuantityStock = 2 };


rentalables.Add(vehicle);
rentalables.Add(excavator);


purchasables.Add(book);
purchasables.Add(vehicle);

Console.WriteLine("Do you want to rent or purchase");
string rentalDecision = Console.ReadLine();


if (rentalDecision.ToLower() == "rent")
{
    foreach (var item in rentalables)
    {
        Console.WriteLine($"Item: { item.ProductName }");
        Console.Write("Do you want to rent this item: ");
        string wantToRent = Console.ReadLine();

        if (wantToRent.ToLower() == "yes")
        {
            item.Rent();
        }

        Console.Write("Do you want to return this item: ");
        string wantToReturn = Console.ReadLine();

        if (wantToReturn.ToLower() == "yes")
        {
            item.ReturnRental();
        }
    }
}
else
{
    foreach (var item in purchasables)
    {
        Console.WriteLine($"Item: {item.ProductName}");
        Console.WriteLine("Do you want to purchase this product: ");
        string wantToPurchase = Console.ReadLine();

        if (wantToPurchase.ToLower() == "yes")
        {
            item.Purchase();
        }
    }
}
Console.ReadLine();
