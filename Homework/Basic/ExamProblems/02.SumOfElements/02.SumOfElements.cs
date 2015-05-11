using System;
using System.Collections.Generic;
using System.Linq;

internal class SumOfElements
{
    private static void Main()
    {
        string tmpStr = Console.ReadLine();
        int[] aInts = tmpStr.Split().Select(s => int.Parse(s)).ToArray();
        List<int> lDiffs = new List<int>();
        bool isSum = false;
        for (int i = 0; i < aInts.Length && !isSum; i++)
        {
            int sum = 0;
            for (int j = 0; j < aInts.Length; j++)
            {
                if (j != i)
                {
                    sum += aInts[j];   
                }
                if (j == aInts.Length - 1)
                {
                    if (sum == aInts[i])
                    {
                        Console.WriteLine("Yes, sum={0}", sum);
                        isSum = true;
                    }
                    else if (j == (aInts.Length - 1))
                    {
                        lDiffs.Add(Math.Abs(aInts[i] - sum));
                    }
                }
            }
        }
        if (!isSum)
        {
            int minDiff = int.MaxValue;
            for (int i = 0; i < lDiffs.Count; i++)
            {
                if (lDiffs[i] < minDiff)
                {
                    minDiff = lDiffs[i];
                }
            }
            Console.WriteLine("No, diff={0}", minDiff);
        }
    }
}