using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            work w= new work();
            Console.WriteLine("Main Thread start");

            ThreadStart s = w.count;
            ThreadStart s1 = w.alphabat;

            Thread t= new Thread(s);
            Thread t1= new Thread(s1);

            t.Start();
            t1.Start();

            Console.WriteLine("main thread end");
            Console.ReadLine();
        }     
    }
    class work
    {
         public void count()
        {
            Console.WriteLine("Thread 1 start.");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Thread 1 end.");
        }
        public void alphabat()
        {
            Console.WriteLine("Thread 2 start");
            for (char c = 'A'; c <= 'Z'; c++)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("Thread 2 End");
        }
    }
}
