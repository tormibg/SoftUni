using System;
using System.Linq;

class Pairs
{
    static void Main()
    {
        string sNum = Console.ReadLine();
        int[] iNums = sNum.Split().Select(s => int.Parse(s)).ToArray();
        int firstElement = iNums[0];
        int secondElement = iNums[1];
        int sum1 = iNums[0] + iNums[1];
        int iDiff = 0;
        for (int i = 2; i < iNums.Length-1; i+=2)
        {
            firstElement = iNums[i];
            secondElement = iNums[i + 1];
            int sum2 = firstElement + secondElement;
            int tmpDiff = Math.Abs(sum1 - sum2);
            iDiff = Math.Max(iDiff, tmpDiff);
            sum1 = sum2;
        }
        if (iDiff == 0)
        {
            Console.WriteLine("Yes, value={0}",sum1);
        }
        else
        {
            Console.WriteLine("No, maxdiff={0}", iDiff);
        }
        
    }
}