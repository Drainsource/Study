



List<PersonModel> people = new List<PersonModel>
{
    new PersonModel { FirstName = "Toth", LastName = "Matedarnit", Email = "tothmat@outlook.hu"},
    new PersonModel { FirstName = "Sue", LastName = "Strom", Email = "suestorm@outlook.hu"},
    new PersonModel { FirstName = "John", LastName = "Smith", Email = "johnsmith@outlook.hu"}
};

List<CarModel> cars = new List<CarModel>
{
    new CarModel { Manufacturer = "BMW", Model = "M5" },
    new CarModel { Manufacturer = "Mercedes", Model = "S Class" },
    new CarModel { Manufacturer = "Audi", Model = "A8" },
    new CarModel { Manufacturer = "Audi", Model = "A1" }

};

DataAccess<PersonModel> peopleData = new();
peopleData.BadEntryFound += PeopleData_BadEntryFound;



peopleData.SaveToCSV(people, @"C:\Temp\SavedFiles\people.csv");

DataAccess<CarModel> carData = new();
carData.BadEntryFound += CarData_BadEntryFound;



carData.SaveToCSV(cars, @"C:\Temp\SavedFiles\cars.csv");

Console.ReadLine();


void PeopleData_BadEntryFound(object? sender, PersonModel e)
{
    Console.WriteLine($"Bad entry was found for { e.FirstName } { e.LastName }");
}

void CarData_BadEntryFound(object? sender, CarModel e)
{
    Console.WriteLine($"Bad entry was found for {e.Manufacturer} {e.Model}");
}

public class DataAccess<T> where T : new()
{
    public event EventHandler<T> BadEntryFound;
    public void SaveToCSV(List<T> items, string filePath)
    {   
        List<string> rows = new List<string>();
        T entry = new T();
        var cols = entry.GetType().GetProperties();

        string row = "";
        bool badWordDetected = false; 
        foreach (var col in cols)
        {
            row += $",{ col.Name }";
        }
        row = row.Substring(1);
        rows.Add(row);

        foreach (var item in items)
        {
            row = "";
            foreach (var col in cols)
            {
                string val = col.GetValue(item, null).ToString();
                badWordDetected = BadWordDecetor(val);
                if (badWordDetected == true)
                {
                    BadEntryFound?.Invoke(this, item);
                    break;

                }
                row += $",{val}";
            }

            if (badWordDetected == false)
            {
                row = row.Substring(1);
                rows.Add(row);
            }
        }

        File.WriteAllLines(filePath, rows);
    }

    private bool BadWordDecetor(string stringToTest)
    {
        bool output = false;
        string lowerCaseTest = stringToTest.ToLower();

        if (lowerCaseTest.Contains("darn") || lowerCaseTest.Contains("heck"))
        {
            output = true;
        }
        return output;
    }
}
