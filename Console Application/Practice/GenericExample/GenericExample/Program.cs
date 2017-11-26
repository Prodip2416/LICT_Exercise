using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericExample
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Equal = Calculator.GetEqual<int>(2,3);
            if (Equal)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("Not Equal");
            }
            Console.ReadKey();
        }
    }
    // generic are use Class or Method any fields
    class Calculator
    {
       public static bool GetEqual<P>(P a, P b)
       {
           return a.Equals(b);
       }
    }
}
