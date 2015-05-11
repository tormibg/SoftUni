/* (2 * n)! / ((n + 1)! * n!) */

using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            uint iN;
            Console.Write(@"Enter positive integer number N (0 <= N < 100). : ");
            if (uint.TryParse(Console.ReadLine(), out iN) && iN < 100)
            {
                BigInteger iNum = 1, iNumP1 = 1, iNumF = 1;
                for (int i = 1; i <= iN*2; i++)
                {
                    iNum = iNum * i;
                    if (i <= iN)
                    {
                        iNumP1 = iNumP1 * (i + 1);
                        iNumF = iNumF * i;
                    }
                }
                Console.WriteLine(@"(2*n)!/((n+1)!*n!) = {0}", (iNum / (iNumP1 * iNumF)).ToString("F0"));
            }
            else
            {
                Console.WriteLine("Onli positive integer number and 1 < n < 100");
            }
        }
    }
}