using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_ueueExample
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


            Queue<Customer> queueLiCustomers= new Queue<Customer>();
            queueLiCustomers.Enqueue(c1);
            queueLiCustomers.Enqueue(c2);
            queueLiCustomers.Enqueue(c3);
            queueLiCustomers.Enqueue(c4);
            queueLiCustomers.Enqueue(c5);

            //Peek Example
            Customer c = queueLiCustomers.Dequeue();

            Console.WriteLine(c.Id + " - " + c.Name);
            Console.WriteLine(queueLiCustomers.Count);



            //Dequeue Example..........

            //Customer c = queueLiCustomers.Dequeue();

            //Console.WriteLine(c.Id+" - "+c.Name);
            //Console.WriteLine(queueLiCustomers.Count);
            //Console.WriteLine();
            //Customer cc = queueLiCustomers.Dequeue();

            //Console.WriteLine(cc.Id + " - " + cc.Name);
            //Console.WriteLine(queueLiCustomers.Count);
            //Console.WriteLine();
            //Customer ccc = queueLiCustomers.Dequeue();

            //Console.WriteLine(ccc.Id + " - " + ccc.Name);
            //Console.WriteLine(queueLiCustomers.Count);
            //Console.WriteLine();
            //Customer cccc = queueLiCustomers.Dequeue();

            //Console.WriteLine(cccc.Id + " - " + cccc.Name);
            //Console.WriteLine(queueLiCustomers.Count);
            //Console.WriteLine();
            //Customer ccccc = queueLiCustomers.Dequeue();

            //Console.WriteLine(cccc.Id + " - " + cccc.Name);
            //Console.WriteLine(queueLiCustomers.Count);



            //foreach (Customer customer in queueLiCustomers)
            //{
            //    Console.WriteLine(customer.Id+" - "+customer.Name);
            //    Console.WriteLine(queueLiCustomers.Count);
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
