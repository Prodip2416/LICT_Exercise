using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BJ_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.Id = 1;
            s.Name = "Joy";

            Student s1 = s;
            s1.Id = 2;
            s1.Name = "Akash";


            Console.WriteLine("Id = {0}, Name= {1}", s.Id, s.Name);
            Console.WriteLine("Id = {0}, Name= {1}", s1.Id, s1.Name);

            Student s3 = new Student();
            Console.WriteLine("Id = {0}, Name= {1}", s3.Id, s3.Name);
            Console.ReadKey();
        }
    }



    class Student
    {
        //public Student()
        //{
        //    Id = 1;
        //    Name = "Tuhin";
        //    Console.WriteLine("First Constractor call");
        //}

        //public Student(int id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //    Console.WriteLine("Second Constractor call");
        //}
        //public int Id;
        //public string Name;
        //private string Dept;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }

    }

}
