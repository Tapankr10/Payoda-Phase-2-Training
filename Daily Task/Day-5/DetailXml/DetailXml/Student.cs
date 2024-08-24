using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailXml
{
    internal class Student
    {
        public int Sid { get; set; }
        public string Sname { get; set; }
        public string Sdepartment { get; set; }

        public Student(int id, string name, string department)
        {
            Sid = id;
            Sname = name;
            Sdepartment = department;
        }
    }
}
