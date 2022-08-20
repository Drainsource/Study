
public class VehicleModel : InventoryItemModel, IPurchasable, IRentalable
{
    public decimal DealerFee { get; set; }

    public void Purchase()
    {
        QuantityStock -= 1;
        Console.WriteLine("This Car has been purchased");
    }
    public void Rent()
    {
        QuantityStock -= 1;
        Console.WriteLine("This Car has been rented");
    }

    public void ReturnRental()
    {
        QuantityStock += 1;
        Console.WriteLine("This Car has been returned");
    }
}
