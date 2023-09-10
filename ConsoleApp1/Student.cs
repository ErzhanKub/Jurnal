using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jurnal
{
    public class Student : Person
    {

        public Group Group { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Student(string firstname, string secondName, string midleName, int age, string email, string phone, Group group)
        {
            Firstname = firstname;
            SecondName = secondName;
            MidleName = midleName;
            Age = age;
            Email = email;
            Phone = phone;
            Group = group;
        }
    }
}
