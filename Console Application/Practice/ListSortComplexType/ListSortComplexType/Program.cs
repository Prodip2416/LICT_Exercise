using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListSortComplexType
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1= new Customer()
            {
                Id = 101,
                Name = "Rob",
                Salary = 3000
            };
            Customer c2 = new Customer()
            {
                Id = 102,
                Name = "Piter",
                Salary = 8000
            };
            Customer c3 = new Customer()
            {
                Id = 103,
                Name = "Marry",
                Salary = 7000
            };

            List<Customer>customers= new List<Customer>();
            customers.Add(c1);
            customers.Add(c2);
            customers.Add(c3);


            Console.WriteLine("Before Sorthig.....");

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.Name);
            }
            customers.Sort();

            Console.WriteLine("After Sorthig.....");

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.Name);
            }
        }
    }
    public class Customer:IComparable<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

        public int CompareTo(Customer onther)
        {
           // return this.Salary.CompareTo(onther.Salary);
            return this.Name.CompareTo(onther.Name);
        }

    }
}
