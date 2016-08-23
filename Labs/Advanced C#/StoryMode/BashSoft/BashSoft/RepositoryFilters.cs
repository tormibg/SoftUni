using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft
{
    public static class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int sudentsToTake)
        {
            switch (wantedFilter)
            {
                case "excellent":
                    FilterAndTake(wantedData,ExelentFilter, sudentsToTake);
                    break;
                case "average":
                    FilterAndTake(wantedData, AverageFilter, sudentsToTake);
                    break;
                case "poor":
                    FilterAndTake(wantedData, PoorFilter, sudentsToTake);
                    break;
                default:
                    OutputWriter.DisplayException(ExceptionMessages.InvalidStudentsFilter);
                    break;
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (KeyValuePair<string, List<int>> userName_Points in wantedData)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                double averageMark = Average(userName_Points.Value);
                if (givenFilter(averageMark))
                {
                    OutputWriter.PrintStudent(userName_Points);
                    counterForPrinted++;
                }
            }
        }

        private static bool ExelentFilter(double mark)
        {
            return mark >= 5.00;
        }

        private static bool AverageFilter(double mark)
        {
            return mark < 5.00 && mark >= 3.5;
        }

        private static bool PoorFilter(double mark)
        {
            return mark < 3.5;
        }

        private static double Average(List<int> scoresOnTasks)
        {
            int totalScore = scoresOnTasks.Sum();

            double percentageOfAll = totalScore / scoresOnTasks.Count;

            double mark = percentageOfAll * 4 + 2;

            return mark;
        }
    }
}