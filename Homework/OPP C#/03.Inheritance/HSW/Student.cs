using System;

namespace HSW
{
    public class Student : Human, IComparable<Student>
    {
        private string facNum;

        public Student(string firstName, string lastName, string facNum)
            : base(firstName, lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacNum = facNum;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FacNum { get; set; }



        public int CompareTo(Student other)
        {
            return this.FacNum.CompareTo(other.FacNum);
        }
    }
}
