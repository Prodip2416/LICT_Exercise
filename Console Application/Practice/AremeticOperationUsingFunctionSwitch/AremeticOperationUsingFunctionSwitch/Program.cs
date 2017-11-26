using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AremeticOperationUsingFunctionSwitch
{
    class Program
    {
       public static void Main(string[] args)
       {
           //6.	Write a C# program to take two inputs from user and 
          //    perform the basic arithmetic operation using functions and switch case.


           myFunction();
           Console.ReadLine();
       }

        public static void myFunction()
        {
            Console.Write("Enter Number1 : ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Number2 : ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please select 1,2,3 or 4 : 1.Addition , 2,Subtraction, 3.Multiplication, 4.Divided");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("{0} + {1} = {2}", num1, num2, num1 + num2);
                    break;
                case "2":
                    Console.WriteLine("{0} - {1} = {2}", num1, num2, num1 - num2);
                    break;
                case "3":
                    Console.WriteLine("{0} * {1} = {2}", num1, num2, num1*num2);
                    break;
                case "4":
                    Console.WriteLine("{0} / {1} = {2}", num1, num2, num1/num2);
                    break;
                default:
                    Console.WriteLine("Invalied Input.");
                    break;
            }
        }
    }
}
