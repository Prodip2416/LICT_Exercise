using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareTwoArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //20. Input1=[1,2,3,4,5];  input2=[3,4,5,6,7]; output {3,4,5}
            //  compare the two input array save the common element in a different array.



            int[] array1 = new[] { 1, 2, 3, 4, 5};
            int[] array2 = new[] { 3, 4, 5, 6, 7};
            int result=0;
            for (int i = 0; i < array1.Length; i++)
            {
                
                for (int j = 0; j < array2.Length; j++)
                {
                    if (array1[i] == array2[j])
                    {
                       result = array1[i];
                    }
                    else
                      continue;

                    Console.Write(result + " ");
                }
            }
            Console.ReadKey();
        }
    }
}
