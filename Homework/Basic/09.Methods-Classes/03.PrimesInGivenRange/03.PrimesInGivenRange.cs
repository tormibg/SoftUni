using System;
using System.Collections.Generic;

class PrimesInGivenRange
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int iFirstNum = 0, iSecNum = 0;
            iFirstNum = int.Parse(Console.ReadLine());
            iSecNum = int.Parse(Console.ReadLine());
            List<int> lPrimeNumInts = new List<int>();
            lPrimeNumInts = IsPrimeList(iFirstNum, iSecNum);
            if (lPrimeNumInts.Count > 0)
            {
                for (int i = 0; i < lPrimeNumInts.Count; i++)
                {
                    if (i < lPrimeNumInts.Count - 1)
                    {
                        Console.Write("{0}, ", lPrimeNumInts[i]);
                    }
                    else
                    {
                        Console.Write("{0}", lPrimeNumInts[i]);
                    }
                }   
            }
            else
            {
                Console.Write("(empty list)");
            }
            Console.WriteLine();
        }
    }

    private static List<int> IsPrimeList(int iStartNum, int iEndNum)
    {
        List<int> lTmpInts = new List<int>();
        for (int i = iStartNum; i <= iEndNum; i++)
        {
            if (IsPrime(i))
            {
                lTmpInts.Add(i);
            }
        }
        return lTmpInts;
    }

    static bool IsPrime(int iNum)
    {
        bool bIsPrime = false;
        if (iNum == 0 || iNum == 1)
        {
            return false;
        }
        else if (iNum == 2)
        {
            return true;
        }
        for (int i = 2; i <= Math.Sqrt(iNum); i++)
        {
            if (iNum % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}
