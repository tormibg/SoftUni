using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomLINQ
{
    public class Student
    {
        public Student(string name, int num)
        {
            this.Name = name;
            this.Grade = num;
        }

        public string Name { get; set; }
        public int Grade { get; set; }

        public override string ToString()
        {
            string str = String.Format("Name - {0}, Grade - {1}",this.Name, this.Grade);
            return str;
        }
    }
}
