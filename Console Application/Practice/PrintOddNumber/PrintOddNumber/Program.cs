using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintOddNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // 7.Write a C# program to take 5 input numbers from user and print all odd number

            int i = 0;
            int[] arr = new int[5];

            for (i = 0; i < arr.Length; i++)
            {
                Console.Write("Number[" + (i + 1) + "]: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("List of Odd Number Is:\n");
            for (i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                    Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
