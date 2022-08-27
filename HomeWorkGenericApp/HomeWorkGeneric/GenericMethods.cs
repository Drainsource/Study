using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkGeneric
{
    public class GenericMethods<T> where T : class, IGeneric
    {

        public List<T> StuffList { get; set; } = new List<T>();

        public void PrintStuffList()
        {
            foreach (var item in StuffList)
            {
                Console.WriteLine($"{item.Stuff}");
            }
        }

    }
}
