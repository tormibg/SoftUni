using System;
using System.Security.Cryptography;

class BitsUp
{
    private static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int iCount = 0;
        int[] aInts = new int[n];
        for (int i = 0; i < n; i++)
        {
            Convert.ToString(aInts[i], 2);
            aInts[i] = int.Parse(Console.ReadLine());
            for (int j = 7; j >= 0; j--)
            {
                if ((step == 1 && iCount > 0) || (iCount % step == 1))
                {
                    int mask = 1 << j;
                    aInts[i] = aInts[i] | mask;
                }
                iCount++;
            }
        }
        foreach (int num in aInts)
        {
            Console.WriteLine(num);
        }
    }
}