

List<ICoumputerController> controllers = new List<ICoumputerController>();

Keyboard keyboard = new();
GameController gameController = new GameController();
BattryPoweredGameController battryPoweredGameController = new BattryPoweredGameController();
BatteryPoweredKeyboard battryPoweredKeyboard = new BatteryPoweredKeyboard();

controllers.Add(keyboard);
controllers.Add(gameController);
controllers.Add(battryPoweredGameController);

foreach (var controller in controllers)
{
    if (controller is GameController gc)
    {

    }

}


List<IBatteryPowered> powered = new List<IBatteryPowered>();

powered.Add(battryPoweredGameController);
powered.Add(battryPoweredKeyboard);





using(GameController gc = new GameController())
{

}

Console.ReadLine();


public interface ICoumputerController : IDisposable
{
    void Connect();
    void CurrentKeyPressed();
}

public class Keyboard : ICoumputerController, IDisposable
{
    public void Connect()
    {

    }
    public void CurrentKeyPressed()
    {

    }

    public void Dispose()
    {
        // do whaterver shotdon task needed
    }

    public string ConnectionType { get; set; }
}

public interface IBatteryPowered
{
    public int BatteryLevel { get; set; }

}


public class BatteryPoweredKeyboard : Keyboard, IBatteryPowered
{
    public int BatteryLevel { get; set; }
}


public class GameController : ICoumputerController, IDisposable
{
    public void Connect()
    {

    }
    public void CurrentKeyPressed()
    {

    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
 
}


public class BattryPoweredGameController : GameController, IBatteryPowered
{
    public int BatteryLevel { get; set; }
}