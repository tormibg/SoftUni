using System;
using System.Collections.Generic;
using BashSoft.Static_data;

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
                    throw new ArgumentException(nameof(this._name), ExceptionMessages.NullOrEmptyValue);
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
                throw new Exception(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse, student.UserName, this._name));
            }

            this._studentsByName.Add(student.UserName, student);
        }
    }
}