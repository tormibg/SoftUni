using System;

internal class BitFlipper
{
    private static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        int endBit = 62;
        while (endBit > 0)
        {
            int mask = Convert.ToInt32("111", 2);
            endBit--;
            ulong last3Bits = (n >> endBit) & (ulong)mask;
            if (last3Bits == 0 || last3Bits == 7)
            {
                n = n ^ ((ulong)mask << endBit);
                endBit = endBit - 2;
            }
        }
        Console.WriteLine(n);
    }
}