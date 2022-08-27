


using GenericsDemo;

List<string> stringlist = new List<string>();
List<int> intList = new List<int>();

//Console.WriteLine(FizzBuzz.Fizzbuzz("testtesttest123"));


//Console.WriteLine(FizzBuzz.Fizzbuzz(new PersonModel { FirstName = "Tom", LastName = "Corey" }));

GenericHelper<PersonModel> peopleHelper = new GenericHelper<PersonModel>();

peopleHelper.CheckItemAndAdd(new PersonModel { FirstName = "Tim", HasError = true });

foreach (var item in peopleHelper.RejectedItems)
{
    Console.WriteLine($"{item.FirstName} {item.LastName} was rejected.");
}


Console.ReadLine();
