using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();

            ht.Add("001", "Zara Ali");
            ht.Add("002", "Abida Rehman");
            ht.Add("003", "Joe Holzner");
            ht.Add("004", "Mausam Benazir Nur");
            ht.Add("005", "M. Amlan");
            ht.Add("006", "M. Arif");
            ht.Add("007", "Ritesh Saikia");

            if (ht.ContainsValue("Nuha Ali"))
            {
                Console.WriteLine("This student name is already in the list");
            }
            else
            {
                ht.Add("008", "Nuha Ali");
            }

            // Get a collection of the keys.
            ICollection key = ht.Keys;

            foreach (string k in key)
            {
                Console.WriteLine(k + ": " + ht[k]);
            }


            // Add four elements to Hashtable.
            //Hashtable hashtable = new Hashtable();
            //hashtable.Add(1, "Sandy");
            //hashtable.Add(2, "Bruce");
            //hashtable.Add(3, "Fourth");
            //hashtable.Add(10, "July");
            //hashtable.Add("p",34.564);

            //// Get Count of Hashtable.
            //int count = hashtable.Count;
            //Console.WriteLine(count);

            //// Clear the Hashtable.
            //hashtable.Clear();

            //// Get Count of Hashtable again.
            //Console.WriteLine(hashtable.Count);


            //Hashtable hashtable = new Hashtable();
            //hashtable[1] = "One";
            //hashtable[2] = "Two";
            //hashtable[13] = "Thirteen";
            //hashtable["p"] = 12;
            //hashtable.Add( "hg",67);

            //foreach (DictionaryEntry entry in hashtable)
            //{
            //    Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            //}


            Console.ReadKey();

        }
    }
}
