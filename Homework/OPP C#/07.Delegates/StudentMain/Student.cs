using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentMain
{
    public class StudentChangedArgs : EventArgs
    {
        public StudentChangedArgs(string type, dynamic oldValue,dynamic newValue)
        {
            this.Type = type;
            this.NewValue = newValue;
            this.OldValue = oldValue;
        }

        public string Type { get; set; }
        public dynamic NewValue { get; set; }
        public dynamic OldValue { get; set; }
    }

    public delegate void OnStudentEventHandler(Student student, StudentChangedArgs args);

    public class Student
    {
        public event OnStudentEventHandler PropertyChanged;

        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new StudentChangedArgs("Name",name, value));
                    }
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (this.age != value)
                {
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new StudentChangedArgs("Age",this.age, value));
                    }
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            string str = String.Format("Name - {0}, Age - {1}", this.Name, this.Age);
            return str;
        }
    }
}
