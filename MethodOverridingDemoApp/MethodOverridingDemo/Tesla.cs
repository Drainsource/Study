public class Tesla : Car
{
    public override void SetClock()
    {
        Console.WriteLine("It sets itself");
    }

    public override void StartCar()
    {
        Console.WriteLine("Think about your destination");
    }
}