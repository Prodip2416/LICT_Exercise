using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListAnotherExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers= new List<int>() {1,8,32,0,5,2,6,3,9,7};
            Console.WriteLine("Before sorting.....");
            foreach (int number in numbers)
            {
                Console.Write(number+" ");
            }
            Console.WriteLine();
            numbers.Sort();
            Console.WriteLine("After sorting.....");
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            numbers.Reverse();
            Console.WriteLine("After Reversing .....");
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            List<string> Alphaber = new List<string>() { "A","Z","B","T","C","U" };
            Console.WriteLine("Before sorting.....");
            foreach (string number in Alphaber)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            Alphaber.Sort();
            Console.WriteLine("After sorting.....");
            foreach (string number in Alphaber)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            Alphaber.Reverse();
            Console.WriteLine("After Reversing .....");
            foreach (string number in Alphaber)
            {
                Console.Write(number + " ");
            }
            Console.ReadKey();
        }
    }
}
