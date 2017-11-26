using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1= new Customer()
            {
                Id = 101,
                Name = "Mark",
                Salary = 2000
            };
            Customer customer2 = new Customer()
            {
                Id = 102,
                Name = "Marry",
                Salary = 2050
            };
            Customer customer3 = new Customer()
            {
                Id = 103,
                Name = "Piter",
                Salary = 6000
            };

            Dictionary<int,Customer> dictionaryCustomers=new Dictionary<int, Customer>();

            dictionaryCustomers.Add(customer1.Id,customer1);
            dictionaryCustomers.Add(customer2.Id, customer2);
            dictionaryCustomers.Add(customer3.Id, customer3);

            //if (!dictionaryCustomers.ContainsKey(customer3.Id))
            //{
            //    dictionaryCustomers.Add(customer3.Id, customer3);
            //}

            //Customer cus = dictionaryCustomers[101];
            //Console.WriteLine("Ïd = {0}, Name = {1}, Salary={2}",cus.Id,cus.Name,cus.Salary);

            //foreach (KeyValuePair<int, Customer> customer in dictionaryCustomers)
            //{
            //    Console.WriteLine(customer.Key);
            //    Customer customers = customer.Value;
            //    Console.WriteLine("Id = {0}, Name = {1}, Salary = {2}",customers.Id,customers.Name,customers.Salary);
            //    Console.WriteLine("----------------------------------");
            //}


            // TryGetVale Function.........Example

            //Customer cus;
            //if (dictionaryCustomers.TryGetValue(101, out cus))
            //{
            //    Console.WriteLine("Id = {0}, Name ={1}, Salary = {2}",cus.Id,cus.Name,cus.Salary);
            //}
            //else
            //{
            //    Console.WriteLine("Can not Find this Key");
            //}


            // Count() Function in Dictionary........

            //Console.WriteLine("Total Number = {0}",dictionaryCustomers.Count);
            //Console.WriteLine("Total Number = {0}", dictionaryCustomers.Count(kvp=>kvp.Value.Salary>4050));


            //dictionaryCustomers.Remove(101);// Remove the item in the dictionary
            //dictionaryCustomers.Clear();// Clear all item in the dictionary



            Console.ReadKey();
        }
    }

    public class Customer
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public int Salary { get; set; } 
    }
}
