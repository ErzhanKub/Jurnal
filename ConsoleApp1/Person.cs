using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jurnal
{
    public abstract class Person
    {
        public string Firstname { get; set; }
        public string SecondName { get; set; }
        public string MidleName { get; set; }
        public int Age { get; set; }
    }
}
