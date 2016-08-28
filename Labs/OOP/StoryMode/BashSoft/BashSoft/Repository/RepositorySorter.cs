using System;
using System.Collections.Generic;
using System.Linq;
using BashSoft.IO;
using BashSoft.Static_data;

namespace BashSoft.Repository
{
    public class RepositorySorter
    {
        public void OrderAndTake(Dictionary<string, double> studentsMarks, string compasion, int studentsToTake)
        {
            compasion = compasion.ToLower();
            switch (compasion)
            {
                case "ascending":
                    PrintStudent(studentsMarks.OrderBy(x => x.Value).Take(studentsToTake).ToDictionary(pair => pair.Key, pair => pair.Value));
                    break;
                case "descending":
                    PrintStudent(studentsMarks.OrderByDescending(x => x.Value).Take(studentsToTake).ToDictionary(pair => pair.Key, pair => pair.Value));
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComparisonQuery);
            }
        }
        public void PrintStudent(Dictionary<string, double> studentSorted)
        {
            foreach (var studentMarks in studentSorted)
            {
                OutputWriter.PrintStudent(studentMarks);
            }
        }
    }
}