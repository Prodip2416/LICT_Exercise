using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemovingDuplicateKeyinList
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> items=new List<int>();

            string[] tokens = Console.ReadLine().Split(' ');

            for (int i = 0; i < n; i++)
            {
                int newItem = Convert.ToInt32(tokens[i]);
                items.Add(newItem);
            }

            List<int> Unique = items.Distinct().ToList();

            foreach (int i in Unique)
            {
                Console.Write(i+" ");
            }
         
            Console.ReadLine();
        }
    }
}
