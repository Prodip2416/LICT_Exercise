using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer()
            {
                Id = 101,
                Name = "Mark",
                Salary = 4000
            };
            Customer c2 = new Customer()
            {
                Id = 102,
                Name = "Marry",
                Salary = 5000
            };
            Customer c3 = new Customer()
            {
                Id = 103,
                Name = "Dom",
                Salary = 6000
            };
            Customer c4 = new Customer()
            {
                Id = 104,
                Name = "Piter",
                Salary = 7000
            };
            Customer c5 = new Customer()
            {
                Id = 105,
                Name = "John",
                Salary = 8000
            };

            Stack<Customer> stackList=new Stack<Customer>();
            stackList.Push(c1);
            stackList.Push(c2);
            stackList.Push(c3);
            stackList.Push(c4);
            stackList.Push(c5);

            Customer cc1 = stackList.Peek();
            Console.WriteLine(cc1.Id + " - " + cc1.Name);
            Console.WriteLine(stackList.Count);

            //Customer cc1 = stackList.Pop();
            //Console.WriteLine(cc1.Id+" - "+cc1.Name);
            //Console.WriteLine(stackList.Count);

            //Customer cc2 = stackList.Pop();
            //Console.WriteLine(cc2.Id + " - " + cc2.Name);
            //Console.WriteLine(stackList.Count);

            //Customer cc3 = stackList.Pop();
            //Console.WriteLine(cc3.Id + " - " + cc3.Name);
            //Console.WriteLine(stackList.Count);

            //Customer cc4 = stackList.Pop();
            //Console.WriteLine(cc4.Id + " - " + cc4.Name);
            //Console.WriteLine(stackList.Count);

            //Customer cc5 = stackList.Pop();
            //Console.WriteLine(cc5.Id + " - " + cc5.Name);
            //Console.WriteLine(stackList.Count);


            //foreach (Customer customer in stackList)
            //{
            //    Console.WriteLine(customer.Id+" - "+customer.Name);
            //    Console.WriteLine(stackList.Count);
            //}
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

    }
}
