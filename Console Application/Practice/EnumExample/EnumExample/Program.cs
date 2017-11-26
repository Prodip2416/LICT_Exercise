using System;
namespace EnumExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer[] customers= new Customer[3];

            customers[0]= new Customer
            {
               Name = "Mark",
               Gender = Gender.Male
            };
            customers[1] = new Customer
            {
                Name = "Marry",
                Gender = Gender.Female
            };
            customers[2] = new Customer
            {
                Name = "Sam",
                Gender = Gender.Unknown
            };

            foreach (Customer customer in customers)
            {
                Console.WriteLine("Name = {0} && Gender = {1}", customer.Name, GetGender(customer.Gender));
            }

            Console.ReadKey();
        }
        public static string GetGender(Gender gender)
        {
            switch (gender)
            {
                case Gender.Unknown:
                    return "Unknown";
                case Gender.Male:
                    return "Male";
                case Gender.Female:
                    return "Female";
                default:
                    return "Invalid";
            }
        }
    }
}
