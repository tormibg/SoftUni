using System;
using System.Collections.Generic;
using System.Linq;

class XRemoval
{
    static void Main()
    {
        List<string> lineList = new List<string>();
        string inputLine = Console.ReadLine();
        while (inputLine != "END")
        {
            lineList.Add(inputLine);
            inputLine = Console.ReadLine();
        }
        HashSet<KeyValuePair<int,int>> pointSet = new HashSet<KeyValuePair<int, int>>();
        for (int row = 1; row < lineList.Count-1; row++)
        {
            for (int col = 1; col < lineList[row].Length; col++)
            {
                char curCh = char.ToLower(lineList[row][col]);
                if (col < lineList[row-1].Count()-1 && col < lineList[row+1].Count()-1
                    && char.ToLower(lineList[row-1][col-1]) == curCh
                    && char.ToLower(lineList[row-1][col+1]) == curCh
                    && char.ToLower(lineList[row+1][col-1]) == curCh
                    && char.ToLower(lineList[row+1][col+1]) == curCh)
                {
                    pointSet.Add(new KeyValuePair<int, int>(row, col));
                    pointSet.Add(new KeyValuePair<int, int>(row - 1, col - 1));
                    pointSet.Add(new KeyValuePair<int, int>(row - 1, col + 1));
                    pointSet.Add(new KeyValuePair<int, int>(row + 1, col - 1));
                    pointSet.Add(new KeyValuePair<int, int>(row + 1, col + 1));
                }
            }
        }
        //foreach (KeyValuePair<int, int> pair in pointSet)
        //{
        //    //Console.Write(pair.Value.ToString() + " " + pair.Key.ToString());
        //    //Console.WriteLine();
        //}
        for (int row = 0; row < lineList.Count; row++)
        {
            for (int col = 0; col < lineList[row].Count(); col++)
            {
                if (!pointSet.Contains(new KeyValuePair<int, int>(row,col)))
                {
                    Console.Write(lineList[row][col]);
                }
            }
            Console.WriteLine();
        }
    }
}