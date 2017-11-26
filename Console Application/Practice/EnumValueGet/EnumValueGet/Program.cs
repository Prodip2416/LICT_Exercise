using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EnumValueGet
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] value = (int[])Enum.GetValues(typeof(Gender));
            foreach (int i in value)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            string[] values = Enum.GetNames(typeof(Gender));
            foreach (string i in values)
            {
                Console.WriteLine(i);
            }
        }
        public enum Gender
        {
            Unknown=5,
            Male=56,
            Female=667
        }
    }

}