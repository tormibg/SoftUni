using System.Collections.Generic;
using System.Linq;

namespace BashSoft
{
    public static class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string compasion, int studentsToTake)
        {
            compasion = compasion.ToLower();
            switch (compasion)
            {
                case "ascending":
                    PrintStudent(wantedData.OrderBy(x => x.Value.Sum()).Take(studentsToTake).ToDictionary(pair => pair.Key, pair => pair.Value));
                    break;
                case "descending":
                    PrintStudent(wantedData.OrderByDescending(x => x.Value.Sum()).Take(studentsToTake).ToDictionary(pair => pair.Key, pair => pair.Value));
                    break;
                default:
                    OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
                    break;
            }
        }
        public static void PrintStudent(Dictionary<string, List<int>> studentSorted)
        {
            foreach (var studentMarks in studentSorted)
            {
                OutputWriter.PrintStudent(studentMarks);
            }
        }
    }
}