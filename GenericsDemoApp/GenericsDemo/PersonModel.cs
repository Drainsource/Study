


using GenericsDemo;

public class PersonModel : IErrorCheck
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool HasError { get; set; }
}
