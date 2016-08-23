using System;
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
                    OrderAndTake(wantedData, studentsToTake, CompareInOrder);
                    break;
                case "descending":
                    OrderAndTake(wantedData, studentsToTake, CompareDescendingOrder);
                    break;
                default:
                    OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
                    break;
            }
        }

        private static void OrderAndTake(Dictionary<string, List<int>> wantedData, int studentsToTake,
            Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparsionFunc)
        {
            Dictionary<string, List<int>> sortedStudent = GetSortedStudents(wantedData, studentsToTake, comparsionFunc);

            int index = 0;

            foreach (var studentWithMarks in sortedStudent)
            {
                if (index >= studentsToTake)
                {
                    break;
                }
                else
                {
                    OutputWriter.WriteMessageOnNewLine($"{studentWithMarks.Key} - {String.Join(", ", studentWithMarks.Value)}");
                    index++;
                }
            }
        }

        private static int CompareInOrder(KeyValuePair<string, List<int>> firstValue,
            KeyValuePair<string, List<int>> secondValue)
        {
            int totalOfFirstMarks = firstValue.Value.Sum();

            int totalOfSecondMarks = secondValue.Value.Sum();

            return totalOfSecondMarks.CompareTo(totalOfFirstMarks);
        }

        private static int CompareDescendingOrder(KeyValuePair<string, List<int>> firstValue,
            KeyValuePair<string, List<int>> secondValue)
        {
            int totalOfFirstMarks = firstValue.Value.Sum();

            int totalOfSecondMarks = secondValue.Value.Sum();

            return totalOfFirstMarks.CompareTo(totalOfSecondMarks);
        }

        private static Dictionary<string, List<int>> GetSortedStudents(Dictionary<string, List<int>> studentWanted, int takeCount, Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparsion)
        {
            int valuesTaken = 0;
            Dictionary<string, List<int>> studentSorted = new Dictionary<string, List<int>>();
            KeyValuePair<string, List<int>> nextInOrder = new KeyValuePair<string, List<int>>();
            bool isSorted = false;

            while (true)
            {
                isSorted = true;
                foreach (var studentWithScore in studentWanted)
                {
                    if (!String.IsNullOrEmpty(nextInOrder.Key))
                    {
                        int comarsionResult = comparsion(studentWithScore, nextInOrder);
                        if (comarsionResult >= 0 && !studentSorted.ContainsKey(studentWithScore.Key))
                        {
                            nextInOrder = studentWithScore;
                            isSorted = false;
                        }
                    }
                    else
                    {
                        if (!studentSorted.ContainsKey(studentWithScore.Key))
                        {
                            nextInOrder = studentWithScore;
                            isSorted = true;
                        }
                    }
                }

                if (!isSorted)
                {
                    studentSorted.Add(nextInOrder.Key, nextInOrder.Value);
                    valuesTaken++;
                    nextInOrder = new KeyValuePair<string, List<int>>();
                }
                else
                {
                    if (studentWanted.Count == studentSorted.Count)
                    {
                        break;
                    }
                    
                }
            }

            return studentSorted;
        }
    }
}