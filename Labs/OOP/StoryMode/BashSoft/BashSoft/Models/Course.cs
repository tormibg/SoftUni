﻿using System.Collections.Generic;
using BashSoft.IO;
using BashSoft.Static_data;

namespace BashSoft.Models
{
    public class Course
    {
        public const int NumberOfTaskOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        public string name;
        public Dictionary<string, Student> studentsByName;
        public Course(string name)
        {
            this.name = name;
            this.studentsByName = new Dictionary<string, Student>();
        }

        public void EnrollStudent(Student student)
        {
            if (this.studentsByName.ContainsKey(student.userName))
            {
                OutputWriter.DisplayException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse, student.userName, this.name));
            }

            this.studentsByName.Add(student.userName, student);
        }
    }
}