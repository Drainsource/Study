using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public class DiceLogic
    {
        public List<Counter> Probability(int a1, int b1, int a2, int b2)
        {
            List<Counter> result = new List<Counter>();
            int side1 = b1 - a1 + 1;
            int side2 = b2 - a2 + 1;
            double[] items = new double[side1 * side2];
            double[] probability = new double[side1 * side2];
            int k =0;
            for (int i = a1; i < b1+1; i++)
            {
                for (int j = a2; j < b2 + 1; j++)
                {
                    if (items.Contains(i + j))
                    {
                        var index = items.ToList().FindIndex(x => x == i + j);
                        probability[index]++;
                    }
                    else
                    {
                        
                        items[k] = (i + j);
                        probability[k]++;
                        k++;
                    }
                }
            }

            int l = 0;
            foreach (var item in probability)
            {
                Counter counter = new Counter();
                counter.Number = items[l];
                counter.Items = item;
                counter.Probability = Math.Round(item / (side1 * side2), 5);
                result.Add(counter);
                l++;
            }
            result.RemoveAll(x => x.Items == 0);
            return result;
        }
    }
}
