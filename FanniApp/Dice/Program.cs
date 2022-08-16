using System.Linq;

namespace Dice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DiceLogic gunar = new();
            DiceLogic emma = new();
            bool isa1;
            bool isb1;
            bool isa2;
            bool isb2;
            int a1;
            int b1;
            int a2;
            int b2;
            do
            {
                Console.Write("Please add the Gunar dice parameter a1 b1 a2 b2: ");
                string? firstPlayer = Console.ReadLine();
                var array1 = firstPlayer.Split(' ');
                isa1 = int.TryParse(array1[0], out a1);
                isb1 = int.TryParse(array1[1], out b1);
                isa2 = int.TryParse(array1[2], out a2);
                isb2 = int.TryParse(array1[3], out b2); 
            } while (!isa1 || !isb1 || !isa2 || !isb2);
            List<Counter> result1 = gunar.Probability(a1, b1, a2, b2);
            int resultGunter = 0;
            for (int i = (int)result1.Max(m => m.Number); i > 0; i--)
            {
                var test = result1.Where(m => m.Number >= i).ToList().Sum(m => m.Probability).CompareTo(0.5);
                if (test >= 1)
                {
                    resultGunter = i;
                    i = 0;

                }      
            }
            Console.WriteLine(resultGunter);
           
            do
            {
                Console.Write("Please add the Emma dice parameter a1 b1 a2 b2: ");
                string? secondPlayer = Console.ReadLine();
                var array1 = secondPlayer.Split(' ');
                isa1 = int.TryParse(array1[0], out a1);
                isb1 = int.TryParse(array1[1], out b1);
                isa2 = int.TryParse(array1[2], out a2);
                isb2 = int.TryParse(array1[3], out b2);
            } while (!isa1 || !isb1 || !isa2 || !isb2);
            List<Counter> result2 = emma.Probability(a1, b1, a2, b2);
            int resultEmma = 0;
            for (int i = (int)result2.Max(m => m.Number); i > 0; i--)
            {
                var test = result2.Where(m => m.Number >= i).ToList().Sum(m => m.Probability).CompareTo(0.5);
                if (test >= 1)
                {
                    resultEmma = i;
                    i = 0;
                }
                
            }
            Console.WriteLine(resultEmma);

            if (resultGunter == resultEmma)
            {
                Console.WriteLine("Tie");
            }
            else if (resultGunter > resultEmma)
            {
                Console.WriteLine("Gunter");
            }
            else if (resultGunter < resultEmma)
            {
                Console.WriteLine("Emma");
            }


            Console.ReadLine();
        }
    }
}