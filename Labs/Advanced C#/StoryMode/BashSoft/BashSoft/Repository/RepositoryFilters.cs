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
                    FilterAndTake(wantedData, x => x >= 5, sudentsToTake);
                    break;
                case "average":
                    FilterAndTake(wantedData, x => x < 5 && x >= 3.5, sudentsToTake);
                    break;
                case "poor":
                    FilterAndTake(wantedData, x => x < 3.5, sudentsToTake);
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

                double averageScore = userName_Points.Value.Average();
                double percentAgeOfFullfilmet = averageScore / 100;
                double mark = percentAgeOfFullfilmet * 4 + 2;

                if (givenFilter(mark))
                {
                    OutputWriter.PrintStudent(userName_Points);
                    counterForPrinted++;
                }
            }
        }
    }
}