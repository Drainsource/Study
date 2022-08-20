





public class BookModel : InventoryItemModel, IPurchasable
{
    public int NumberOfPages { get; set; }

    public void Purchase()
    {
        QuantityStock -= 1;
        Console.WriteLine("This Book has been purchased");
    }

}
