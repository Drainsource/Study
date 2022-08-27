using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    public class GenericHelper<T> where T : IErrorCheck
    {
        public List<T> Items { get; set; } = new List<T>();
        public List<T> RejectedItems { get; set; } = new List<T>();

        public void CheckItemAndAdd(T item)
        {
            if (item.HasError == false)
            {
                Items.Add(item);
            }
            else
            {
                RejectedItems.Add(item);
            }
        }


    }
}
