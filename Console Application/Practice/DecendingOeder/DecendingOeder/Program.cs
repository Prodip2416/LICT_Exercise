using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecendingOeder
{
    class Program
    {
        static void Main(string[] args)
        {
            //3. descending order{1,2,3,4,5}
           // output should be{ 5,4,3,2,1}




            //    int[] array = new[] {1, 4, 5, 3, 2};

            //    Array.Sort(array);

            //    foreach (int  i in array)
            //    {
            //        Console.Write(i+" ");
            //    }


            int[] array = new int[] { 1, 2, 3, 4, 5 };
            Array.Sort<int>(array,
                            new Comparison<int>(
                                    (i1, i2) => i2.CompareTo(i1)
                            ));

            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.ReadLine();
        }
    }
}
