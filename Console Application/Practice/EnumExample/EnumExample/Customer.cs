using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace EnumExample
{
    class Customer
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }

    }
    public enum Gender
    {
        Unknown,
        Male,
        Female
    }

}
