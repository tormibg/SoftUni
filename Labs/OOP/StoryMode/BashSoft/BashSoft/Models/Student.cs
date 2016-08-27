using System;
using System.Collections.Generic;
using System.Linq;
using BashSoft.Exceptions;
using BashSoft.Static_data;

namespace BashSoft.Models
{
    public class Student
    {
        private string _userName;
        private readonly Dictionary<string, Course> _enrroledCourses;
        private readonly Dictionary<string, double> _marksByCourseName;

        public Student(string userName)
        {
            this.UserName = userName;
            this._enrroledCourses = new Dictionary<string, Course>();
            this._marksByCourseName = new Dictionary<string, double>();
        }

        public string UserName
        {
            get { return this._userName; }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this._userName = value;
            }
        }

        public IReadOnlyDictionary<string, Course> EnrroledCourses
        {
            get { return this._enrroledCourses; }
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get { return this._marksByCourseName; }
        }

        public void EnrollInCourse(Course course)
        {
            if (this._enrroledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.UserName, course.Name);
            }

            this._enrroledCourses.Add(course.Name, course);
        }

        public void SetMarksInCourse(string courseName, params int[] scores)
        {
            if (!this._enrroledCourses.ContainsKey(courseName))
            {
                throw new Exception(ExceptionMessages.NotEnrolledInCourse);
            }

            if (scores.Length > Course.NumberOfTaskOnExam)
            {
                throw new Exception(ExceptionMessages.InvalidNumberOfScores);
            }

            this._marksByCourseName.Add(courseName, Calculate(scores));
        }

        private double Calculate(int[] scores)
        {
            double percentageOfSolvedExam = scores.Sum() / (double)(Course.NumberOfTaskOnExam * Course.MaxScoreOnExamTask);
            double mark = percentageOfSolvedExam * 4 + 2;
            return mark;
        }
    }
}