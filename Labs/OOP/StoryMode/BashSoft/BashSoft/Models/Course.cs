using System.Collections.Generic;
using BashSoft.Exceptions;

namespace BashSoft.Models
{
    public class Course
    {
        public const int NumberOfTaskOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string _name;
        private Dictionary<string, Student> _studentsByName;
        public Course(string name)
        {
            this.Name = name;
            this._studentsByName = new Dictionary<string, Student>();
        }
        public string Name
        {
            get { return this._name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this._name = value;
            }
        }

        public IReadOnlyDictionary<string, Student> StudentsByName
        {
            get { return this._studentsByName; }
        }

        public void EnrollStudent(Student student)
        {
            if (this._studentsByName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, this.Name);
            }

            this._studentsByName.Add(student.UserName, student);
        }
    }
}