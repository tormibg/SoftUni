using System;
using System.Collections.Generic;

internal class PrimeFactorization
{
    private static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int numberCons = number;
        List<int> lPrimeDev = new List<int>();
        int divNum = 2;
        while (number != 1)
        {
            if ((number % divNum) == 0)
            {
                number = number / divNum;
                lPrimeDev.Add(divNum);
            }
            else
            {
                divNum++;
              //  divNum = getNewPrime(divNum, number);
            }
        }
        Console.Write("{0} =", numberCons);
        for (int i = 0; i < lPrimeDev.Count; i++)
        {
            if (i == lPrimeDev.Count - 1)
            {
                Console.Write(" {0}", lPrimeDev[i]);
            }
            else
            {
                Console.Write(" {0} *", lPrimeDev[i]);
            }
        }
        Console.WriteLine();
    }

    private static int getNewPrime(int divNum, int number)
    {
        for (int i = divNum; i <= number; i++)
        {
            if (IsPrime(i))
            {
                return i;
            }
        }
        return number;
    }

    private static bool IsPrime(int iNum)
    {
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