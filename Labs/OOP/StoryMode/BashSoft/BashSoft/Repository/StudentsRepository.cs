using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BashSoft.IO;
using BashSoft.Models;
using BashSoft.Static_data;

namespace BashSoft.Repository
{
    public class StudentsRepository
    {
        private bool _isDataInitialized = false;
        private readonly RepositoryFilter _filter;
        private readonly RepositorySorter _sorter;
        private Dictionary<string, Course> courses;
        private Dictionary<string, Student> students;

        public StudentsRepository(RepositorySorter sorter, RepositoryFilter filter)
        {
            this._sorter = sorter;
            this._filter = filter;
        }
        public void LoadData(string fileName)
        {
            if (this._isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataAlreadyInitialisedException);
            }
            OutputWriter.WriteMessageOnNewLine("Reading data...");
            this.students = new Dictionary<string, Student>();
            this.courses = new Dictionary<string, Course>();
            ReadData(fileName);
        }

        public void UnloadData()
        {
            if (!this._isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            this._isDataInitialized = false;
            this.students = null;
            this.courses = null;
        }
        private void ReadData(string fileName)
        {
            //string input = Console.ReadLine();
            string path = Path.Combine(SessionData.currentPath, fileName);
            if (File.Exists(path))
            {
                //string pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";

                string pattern = @"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
                Regex rgx = new Regex(pattern);
                string[] allInputLines = File.ReadAllLines(path);

                foreach (var line in allInputLines)
                {
                    if (!string.IsNullOrEmpty(line) && rgx.IsMatch(line))
                    {
                        Match currentMatch = rgx.Match(line);
                        string courseName = currentMatch.Groups[1].Value;
                        string userName = currentMatch.Groups[2].Value;
                        string scoreStr = currentMatch.Groups[3].Value;

                        try
                        {
                            int[] scores =
                                scoreStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
                            if (scores.Any(x => x > 100 || x < 0))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                                continue;
                            }

                            if (scores.Length > Course.MaxScoreOnExamTask)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                            }

                            if (!this.students.ContainsKey(userName))
                            {
                                this.students.Add(userName, new Student(userName));
                            }

                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new Course(courseName));
                            }

                            Course course = this.courses[courseName];
                            Student student = this.students[userName];

                            student.EnrollInCourse(course);
                            student.SetMarksInCourse(courseName,scores);

                            course.EnrollStudent(student);
                        }
                        catch (Exception ex)
                        {

                            OutputWriter.DisplayException(ex.Message + $"at line : {line}");
                        }
                    }
                }
                _isDataInitialized = true;
                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
            else
            {
                throw new Exception(ExceptionMessages.InvalidPath);
            }
        }

        public bool IsQueryForCoursePossible(string courseName)
        {
            if (_isDataInitialized)
            {
                if (this.courses.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;

        }

        public bool IsQueryForStudentPossiblе(string courseName, string studentUserName)
        {
            if (this.IsQueryForCoursePossible(courseName) && this.courses[courseName].StudentsByName.ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }
            return false;
        }

        public void GetStudentScoresFromCourse(string courseName, string userName)
        {
            if (this.IsQueryForStudentPossiblе(courseName, userName))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, double>(userName, this.courses[courseName].StudentsByName[userName].MarksByCourseName[courseName]));
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");
                foreach (var studentMarkEntry in courses[courseName].StudentsByName)
                {
                    this.GetStudentScoresFromCourse(courseName,studentMarkEntry.Key);
                }
            }
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName.ToDictionary(x => x.Key,
                    x => x.Value.MarksByCourseName[courseName]);

                this._filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }

        public void OrderAndTake(string courseName, string comparsion, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName.ToDictionary(x => x.Key,
                    x => x.Value.MarksByCourseName[courseName]);

                this._sorter.OrderAndTake(marks, comparsion, studentsToTake.Value);
            }
        }
    }
}
