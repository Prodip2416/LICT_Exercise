using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacchiSerige
{
    class Program
    {
        static void Main(string[] args)
        {
            int a=0, b=1, c=0, i;

            int terms = Convert.ToInt32(Console.ReadLine());
          
            for (i = 1; i <= terms; i++)
            {
                Console.WriteLine(c);

                a = b;     // Copy n-1 to n-2
                b = c;     // Copy current to n-1
                c = a + b; // New term
            }
            Console.ReadKey();
        }
    }
}
