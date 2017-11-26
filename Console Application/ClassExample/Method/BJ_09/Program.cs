using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BJ_09
{
    class Program
    {
        static void Main(string[] args)
        {
       // This is named parameter...............
          //int result = Fun(e:2,d:4);
          //Console.WriteLine(result);


            // Reference type................

            //int a = 45;
            //Console.WriteLine(a);
            //Console.WriteLine(Add(ref a));
           // Console.WriteLine(a);


            int n = 200000;

            int primeCount = 0;
            int k = 1;

            while (primeCount < n)
            {
                if (IsPrime(k))
                {
                    primeCount++;
                    Console.WriteLine(primeCount.ToString()+" : "+k.ToString());
                }
                k++;
            }
          Console.ReadLine();
        }

        // Simple Function/Method.......

        //static int Fun(int a,int b)
        //{
        //    return a+b;
        //}
        //static int Fun(int a, int b,int c)
        //{
        //    return a + b+c;
        //}
        //static int Fun(int a, int b, int c,int d)
        //{
        //    return a + b + c+d;
        //}
        //static string Fun(string a, string b)
        //{
        //    return a + b;
        //}


        // Best for option parameter

        //static int Fun(int a=0, int b=0, int c=0,int d=0,int e=0)
        //{
        //    return a + b + c+d+e;
        //}

        // Reference type............

        //static int Add( ref int a)
        //{
        //    a += 20;
        //    return a;
        //}


        // Is Prime Function Time checking..............

        static bool IsPrime(int a)
        {
            int count = 0;
            double g = Math.Sqrt(a);
            for (int i = 2; i <= g; i++)
            {
                if (g%i == 0)
                {
                    count++;
                    break;
                }
            }

            if (count == 0)
                return true;
            return false;
        }

    }
}
