using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int result=0;
            for (int row = 1; row <= 5;row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write(9);
                }
                Console.Write(" ");
            }
            //Console.WriteLine(result);
        }
    }
    
}
