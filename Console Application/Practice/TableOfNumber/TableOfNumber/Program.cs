using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableOfNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //4. Write a C# program to take an input from the user and print the table of the given input.

            int j, n;
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Table to be calculated :\n\n");

            for (j = 1; j <= 10; j++)
            {
                Console.Write("{0} X {1} = {2} \n", n, j, n * j);
            }
        }
    }
}
