using System;
using System.Collections.Generic;
using System.Linq;

class Pyramid
{
    static void Main()
    {
        int lineNumber = int.Parse(Console.ReadLine().Trim());
        int prevNum = int.Parse(Console.ReadLine().Trim());
        List<int> pyrNimList = new List<int>();
        pyrNimList.Add(prevNum);
        for (int i = 0; i < lineNumber-1; i++)
        {
            int[] numInts =
                Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

            Array.Sort(numInts);
            bool isGreat = false;
            for (int j = 0; j < numInts.Length; j++)
            {
                if (numInts[j] > prevNum)
                {
                    prevNum = numInts[j];
                    pyrNimList.Add(numInts[j]);
                    isGreat = true;
                    break;
                }
            }
            if (!isGreat)
            {
                prevNum++;
            }
        }
        Console.WriteLine(string.Join(", ",pyrNimList));
    }
}