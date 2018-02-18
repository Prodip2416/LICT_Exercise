using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Like";
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            Console.WriteLine(charArray);
            Console.ReadLine();
        }
    }
}
