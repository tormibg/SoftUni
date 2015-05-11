using System;

class BitRoller
{
    private const int Size = 19;
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        int iFrBit = int.Parse(Console.ReadLine());
        int iRoll = int.Parse(Console.ReadLine());

        for (int i = 0; i < iRoll; i++)
        {
            num = RollBits(num, iFrBit);
        }
        Console.WriteLine(num);
    }

    private static int RollBits(int num, int iFrBit)
    {
        int result = 0;
        for (int i = 0; i < Size; i++) //position
        {
            int iMask = num >> i;
            int bit = iMask & 1;
            if (i == iFrBit)
            {
                iMask = bit << i;
                result = result | iMask;
            }
            else
            {
                int newPos = CheckPosiotion(i);
                if (newPos == iFrBit)
                {
                    newPos = CheckPosiotion(newPos);
                }
                iMask = bit << newPos;
                result = result | iMask;
            }
        }
        return result;
    }

    private static int CheckPosiotion(int i)
    {
        int newPos = i - 1;
        if (newPos < 0)
        {
            newPos = Size - 1;
        }
        return newPos;
    }
}