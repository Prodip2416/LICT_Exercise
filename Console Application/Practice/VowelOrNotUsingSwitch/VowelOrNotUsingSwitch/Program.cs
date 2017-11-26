using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelOrNotUsingSwitch
{
    class Program
    {
        static void Main(string[] args)
        {

            //2.	Write a C# program to declare or assign a character in a variable and 
            //      check whether the given character is vowel or not.[Using Switch Case]


            string userInput = Console.ReadLine();

            switch (userInput.ToLower())
            {
                case "a":
                    Console.WriteLine("Vowel");
                    break;
                case "e":
                    Console.WriteLine("Vowel");
                    break;
                case "i":
                    Console.WriteLine("Vowel");
                    break;
                case "o":
                    Console.WriteLine("Vowel");
                    break;
                case "u":
                    Console.WriteLine("Vowel");
                    break;
                default:
                    Console.WriteLine("Not Vowel");
                    break;
            }
        }
    }
}
