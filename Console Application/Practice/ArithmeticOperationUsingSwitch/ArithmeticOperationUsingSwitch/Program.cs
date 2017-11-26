using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticOperationUsingSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            //3.	Write a C# program to take the two
            //      numbers from user and perform the basic arithmetic operation. [Using Switch Case]

            Console.Write("Enter Number1: ");
            int num1 = Convert.ToInt16(Console.ReadLine());
            Console.Write("Enter Number2: ");
            int num2 = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Enter 1,2,3,4 : 1.Addition , 2.Subtraction, 3.Multiplication, 4.Divsion");
 
            int c = Convert.ToInt16(Console.ReadLine());
            switch (c)
            {
                case 1:
                    Console.WriteLine("Addition Of Two Numbers : " + (num1 + num2));
                    break;
                case 2:
                    Console.WriteLine("Subtraction Of Two Numbers : " + (num1 - num2));
                    break;
                case 3:
                    Console.WriteLine("Multiplicaion Of Two Numbers : " + (num1 * num2));
                    break;
                case 4:
                    Console.WriteLine("Division Of Two Numbers : " + (num1 / num2));
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
            Console.ReadLine();

        }
    }
}
