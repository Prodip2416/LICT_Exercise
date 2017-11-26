using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelOrNot
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.	Write a C# program to declare or assign a character in a variable 
            //      and check whether the given character is vowel or not.[Using If Else]

            string userInput = Console.ReadLine();

            if(userInput.ToLower()=="a")
                Console.WriteLine("Vowel");
            else if(userInput.ToLower()=="e")
                Console.WriteLine("Vowel");
            else if (userInput.ToLower() == "i")
                Console.WriteLine("Vowel");
            else if (userInput.ToLower() == "o")
                Console.WriteLine("Vowel");
            else if (userInput.ToLower() == "u")
                Console.WriteLine("Vowel");
            else
                Console.WriteLine("Not Vowel.");


            Console.ReadKey();
        }
    }
}
