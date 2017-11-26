using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutParameterExample
{
    class Program
    {
        static int Test(out int x, int y = 4)
        {
            x = 6;
            return x * y;
        }
        static void Main(string[] args)
        {
            int a;
            int z = Test(out a);
            Console.WriteLine(a + z);
        }
    }
}
