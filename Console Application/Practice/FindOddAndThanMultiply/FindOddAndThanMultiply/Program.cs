using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FindOddAndThanMultiply
{
    class Program
    {
        static void Main(string[] args)
        {

            // 
            //  7.input:{ 24,45,11,14,23}  ouput: { 20,1,6}: hint: find the odd numbers in the
            //   array{ 45,11,23}: multiply the digits of each number4*5 = 20; 1 * 1 = 1; 2 * 3 = 6



            int[] array = new[] { 24, 45, 11, 14, 23 };
            int result = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                        int reminder = array[i] % 10;
                        int num = array[i] / 10;
                        result = reminder * num;
                    
                }
                else
                    continue;

                Console.Write(result + " ");
            }
            Console.ReadKey();


        }
        
    }
}
