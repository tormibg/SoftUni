using System;
using System.Collections.Generic;
using BashSoft.IO;
using BashSoft.Static_data;

namespace BashSoft.Repository
{
    public class RepositoryFilter
    {
        public void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilter, int sudentsToTake)
        {
            switch (wantedFilter)
            {
                case "excellent":
                    FilterAndTake(studentsWithMarks, x => x >= 5, sudentsToTake);
                    break;
                case "average":
                    FilterAndTake(studentsWithMarks, x => x < 5 && x >= 3.5, sudentsToTake);
                    break;
                case "poor":
                    FilterAndTake(studentsWithMarks, x => x < 3.5, sudentsToTake);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidStudentsFilter);
            }
        }

        private void FilterAndTake(Dictionary<string, double> studentsWithMarks, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (var studentMark in studentsWithMarks)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                if (givenFilter(studentMark.Value))
                {
                    OutputWriter.PrintStudent(studentMark);
                    counterForPrinted++;
                }
            }
        }
    }
}