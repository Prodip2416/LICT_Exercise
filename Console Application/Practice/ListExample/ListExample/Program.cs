using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer()
            {
                Id = 101,
                Name = "Mark",
                Salary = 2000
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
                Name = "Piter",
                Salary = 5500
            };


            List<Customer> customers = new List<Customer>();
            customers.Add(c1);
            customers.Add(c2);
            customers.Add(c3);
            //customers.Insert(1, c3);

            // Convert List to Dictionary

            Dictionary<int, Customer> dictionary = customers.ToDictionary(x => x.Id);

            foreach (KeyValuePair<int, Customer> customer in dictionary)
            {
                Console.WriteLine("Key = {0}",customer.Key);
                Customer c = customer.Value;
                Console.WriteLine("Id = {0}, Name = {1}, Salary = {2}", c.Id, c.Name, c.Salary);
                Console.WriteLine("-----------------------------------");
            }



            //FindAll Function()............
            //FindAll Function() return back a list Object Customer....
            //List<Customer> customersall = customers.FindAll(cust => cust.Salary > 4000);
            // foreach (Customer c in customersall)
            // {
            //     Console.WriteLine("Id = {0}, Name = {1}, Salary = {2}", c.Id, c.Name, c.Salary);

            // }

            //FindLast Function()............
            //FindLast Function() return back a list Object Customer....

            //Customer c = customers.FindLast(cust => cust.Salary > 4000);
            //Console.WriteLine("Id = {0}, Name = {1}, Salary = {2}", c.Id, c.Name, c.Salary);


            //Find Function()............
            //Find Function() return back a list Object Customer....

            //Customer c = customers.Find(cust => cust.Salary > 4000);
            //Console.WriteLine("Id = {0}, Name = {1}, Salary = {2}", c.Id, c.Name, c.Salary);


            //Exist Function.................
            // Exist Function() return Only True Or False Bool....
            //if (customers.Exists(x=>x.Name.StartsWith("Z")))
            //{
            //    Console.WriteLine("Exist");
            //}
            //else
            //{
            //    Console.WriteLine("Does Not Exist.");
            //}



            // Contains Function.......
            // Contains Function() return Only True Or False Bool....
            //if (customers.Contains(c3))
            //{
            //    Console.WriteLine("Exist");
            //}
            //else
            //{
            //    Console.WriteLine("Does Not Exist.");
            //}





            // Console.WriteLine(customers.Count);

            // Console.WriteLine(customers.IndexOf(c3));

            //  Console.WriteLine(customers.IndexOf(c3));

            //foreach (Customer customer in customers)
            //{
            //    Console.WriteLine("Id = {0}",customer.Id);
            //}

            Console.ReadKey();
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

    }
}
