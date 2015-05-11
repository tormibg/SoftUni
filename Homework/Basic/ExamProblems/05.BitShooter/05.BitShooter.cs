using System;

class BitShooter
{
    static void Main()
    {
        const int BITS = 64;
        ulong shootedBits = 0;
        ulong num = ulong.Parse(Console.ReadLine());
        for (int i = 0; i < 3; i++)
        {
            string shot = Console.ReadLine();
            string[] aShootStrings = shot.Split();
            int shootCenter = int.Parse(aShootStrings[0]);
            int shootSize = int.Parse(aShootStrings[1]);
            int startBit = shootCenter - shootSize/2;
            int endBit = shootCenter + shootSize/2;
            
            for (int bit = startBit; bit <= endBit; bit++)
            {
                if (bit >= 0 && bit < BITS)
                {
                    shootedBits = shootedBits | ((ulong)1 << bit);
                }
            }
        }

        ulong aliveBits = num & (~shootedBits);

        ulong rightBits = 0;
        for (int i = 0; i < BITS / 2; i++)
        {
            rightBits += aliveBits & 1;
            aliveBits >>= 1;
        }

        ulong leftBits = 0;
        for (int i = 0; i < BITS / 2; i++)
        {
            leftBits += aliveBits & 1;
            aliveBits >>= 1;
        }

        Console.WriteLine("left: " + leftBits);
        Console.WriteLine("right: " + rightBits);
    }
}