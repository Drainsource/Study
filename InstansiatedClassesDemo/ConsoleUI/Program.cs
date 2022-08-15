namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

        //    List<PersonModel> people = new List<PersonModel>();


        //    PersonModel person = new PersonModel();
        //    person.firstName = "Tim";
        //    people.Add(person);

        //    person = new PersonModel();
        //    person.firstName = "Sue";
        //    people.Add(person);

        //    foreach (var item in people)
        //    {
        //        Console.WriteLine(item.firstName);
        //    }
            List<PersonModel> people = new List<PersonModel>();
            string firstName = "";
            do
            {
                Console.WriteLine("What is your first name (or type exit to stop): ");
                firstName = Console.ReadLine();

                Console.WriteLine("What is your last name: ");
                string lastname = Console.ReadLine();

                if (firstName.ToLower() != "exit")
                {
                    PersonModel person = new PersonModel();
                    person.FirstName = firstName;
                    person.LastName = lastname;
                    people.Add(person);
                }

                foreach (var item in people)
                {
                    ProcessPerson.GreetPerson(item);
                }

            } while (true);

            Console.ReadLine();



        }
    }
}