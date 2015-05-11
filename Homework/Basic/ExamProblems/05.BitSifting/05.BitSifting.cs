using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<ulong> lInts = new List<ulong>();
        string newStr = "";
        string tmpStr = Console.ReadLine();
        int sieves = int.Parse(Console.ReadLine());
        ulong[] aSieves = new ulong[sieves];
        for (int i = 0; i < sieves; i++)
        {
            aSieves[i] = ulong.Parse(Console.ReadLine());
        }
        int oldBit, newBit;
        for (int bit = 63; bit >= 0; bit--)
        {
            oldBit = GetBit(ulong.Parse(tmpStr), bit);
            if (oldBit == 0)
            {
                newStr +="0";
            }
            else
            {
                bool isChOld = false;
                for (int newS = 0; newS < aSieves.Length; newS++)
                {
                    newBit = GetBit(aSieves[newS], bit);
                    if (newBit == 1)
                    {
                        oldBit = 0;
                        newStr += "0";
                        isChOld = true;
                        break;
                    }
                }
                if (!isChOld)
                {
                    newStr += "1";
                }
            }
        }
        int finalResult = 0;
        for (int i = 0; i < newStr.Length; i++)
        {
            if (newStr[i] == '1')
            {
                finalResult++;
            }
        }
        Console.WriteLine(finalResult);
    }

    private static int GetBit(ulong num, int bit)
    {
        int newNum = (int) (num >> bit);
        int newBit = newNum & 1;
        return newBit;
    }
}