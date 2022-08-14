
string[] names = new string[] { "Mate", "Fanni", "Merci" };
int nameNumber;
bool isValidNumber;
do
{
    Console.WriteLine("Choose a name 0-2: ");
    string? nameText = Console.ReadLine(); 
    isValidNumber = int.TryParse(nameText, out nameNumber);
} while (!isValidNumber || !(nameNumber >= 0) || !(nameNumber <= (names.Length-1)));
Console.WriteLine($"The name yo choose is {names[nameNumber]}");






