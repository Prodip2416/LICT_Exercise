using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumWithFunction
{
    class Program
    {
        public static void Main(string[] args)
        {

            //5.	Write a C# program to takes two number
            //      from user and print the sum of number using function.

            Console.Write("Enter Number1 : ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Number2 : ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int result = Sum(num1, num2);
            Console.WriteLine("Sum is {0}", result);
            Console.ReadKey();

        }

        public static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
