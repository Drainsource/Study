
EventTest eventTest = new EventTest();

eventTest.Event += EventTest_Event;

eventTest.Hello();






void EventTest_Event(object? sender, string e)
{
    EventTest model = (EventTest)sender;
    Console.WriteLine(e);
}

Console.ReadLine();




public class EventTest
{
    public event EventHandler<string> Event;

    public string Message { get; set; } = "This was sent from the Event class";
    public void Hello()
    {
        Console.WriteLine("Hello");
        Event?.Invoke(this, "Hello has been sended");
    }


}





