using System;

class BitKiller
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int iCount = 0;
        int newBitNum = 0, bitCount = 0;
        int[] aNum = new int[n];
        for (int i = 0; i < n; i++)
        {
            aNum[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < n; i++)
        {
            for (int bit = 7; bit >= 0; bit--)
            {
                if (!((step == 1 && iCount > 0) || (iCount%step == 1)))
                {
                    int mask = aNum[i] >> bit;
                    int bitValue = mask & 1;
                    newBitNum = newBitNum << 1;
                    newBitNum = newBitNum | bitValue;
                    bitCount++;
                    if (bitCount == 8)
                    {
                        Console.WriteLine(newBitNum);
                        newBitNum = 0;
                        bitCount = 0;
                    }
                }
                iCount++;
            }
        }

        if (bitCount > 0)
        {
            newBitNum = newBitNum << (8 - bitCount);
            Console.WriteLine(newBitNum);   
        }
    }
}