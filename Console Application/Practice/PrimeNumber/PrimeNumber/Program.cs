using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPrime = true;
            Console.WriteLine("Prime Numbers : ");
            int userChoice = Convert.ToInt32(Console.ReadLine());
            for (int i = 2; i <= userChoice; i++)
            {
                for (int j = 2; j <= userChoice; j++)
                {

                    if (i != j && i%j == 0)
                    {
                        isPrime = false;
                        break;
                    }

                }
                if (isPrime)
                {
                    Console.Write(" " + i);
                }
                isPrime = true;
            }
        }
    }
}
