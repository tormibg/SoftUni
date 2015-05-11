using System;
using System.Collections.Generic;
using System.Linq;

class BiggestTriple
{
    static void Main()
    {
        string strNum = Console.ReadLine();
        List<string> lNum = new List<string>();
        int iSum = 0, iMaxSum = int.MinValue, index = 0, curIndex = -1;
        int[] aNum = strNum.Split().Select(s => int.Parse(s)).ToArray();
        for (int i = 0; i < aNum.Length; i++)
        {
            if (i + 2 < aNum.Length)
            {
                iSum = aNum[i] + aNum[i + 1] + aNum[i + 2];
                string tmpStr = aNum[i].ToString() + " "+ aNum[i + 1].ToString() + " " +aNum[i + 2].ToString();
                lNum.Add(tmpStr);
                curIndex++;
                if (iSum > iMaxSum)
                {
                    iMaxSum = iSum;
                    index = curIndex;
                }
                i = i + 2;
            }
            else if (i + 1 < aNum.Length)
            {
                iSum = aNum[i] + aNum[i + 1];
                string tmpStr = aNum[i].ToString() + " " + aNum[i + 1].ToString();
                lNum.Add(tmpStr);
                curIndex++;
                if (iSum > iMaxSum)
                {
                    iMaxSum = iSum;
                    index = curIndex;
                }
                i = i + 1;
            }
            else
            {
                iSum = aNum[i];
                string tmpStr = aNum[i].ToString();
                lNum.Add(tmpStr);
                curIndex++;
                if (iSum > iMaxSum)
                {
                    iMaxSum = iSum;
                    index = curIndex;
                }
            }
        }
        Console.WriteLine(lNum[index]);
    }
}