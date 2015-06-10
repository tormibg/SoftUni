using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal class Program
{
    private static void Main()
    {
        string inputLine = Console.ReadLine();
        List<string> inpList = new List<string>();
        while (inputLine != "END")
        {
            inpList.Add(inputLine);
            inputLine = Console.ReadLine();
        }
        HashSet<KeyValuePair<int, int>> pointHashSet = new HashSet<KeyValuePair<int, int>>();
        char curCh = '\n';
        for (int i = 1; i < inpList.Count - 1; i++)
        {
            for (int j = 1; j < inpList[i].Length - 1; j++)
            {
                curCh = char.ToLower(inpList[i][j]);
                if (j < inpList[i - 1].Count() && curCh.Equals(char.ToLower(inpList[i - 1][j])) &&
                    curCh.Equals(char.ToLower(inpList[i][j - 1])) && curCh.Equals(char.ToLower(inpList[i][j + 1])) &&
                    j < inpList[i + 1].Count() && curCh.Equals(char.ToLower(inpList[i + 1][j])))


                //if ((inpList[i-1] inpList[i][j - 1].ToString().ToLower() == inpList[i][j].ToString().ToLower()) &&
                //    (inpList[i][j].ToString().ToLower() == inpList[i][j + 1].ToString().ToLower()))
                //{
                //    if (inpList[i][j].ToString().ToLower() == inpList[i - 1][j].ToString().ToLower() &&
                //        inpList[i][j].ToString().ToLower() == inpList[i + 1][j].ToString().ToLower())
                {
                    pointHashSet.Add(new KeyValuePair<int, int>(i, j));
                    pointHashSet.Add(new KeyValuePair<int, int>(i - 1, j));
                    pointHashSet.Add(new KeyValuePair<int, int>(i + 1, j));
                    pointHashSet.Add(new KeyValuePair<int, int>(i, j - 1));
                    pointHashSet.Add(new KeyValuePair<int, int>(i, j + 1));
                }
                //}
            }

        }

        //foreach (var keyValuePair in pointHashSet)
        //{
        //    Console.Write(keyValuePair.Key + " " + keyValuePair.Value);
        //    Console.WriteLine();
        //}
        for (int i = 0; i < inpList.Count; i++)
        {
            for (int j = 0; j < inpList[i].Length; j++)
            {
                if (!pointHashSet.Contains(new KeyValuePair<int, int>(i, j)))
                {
                    Console.Write(inpList[i][j]);
                }
            }
            Console.WriteLine();
        }
    }
}