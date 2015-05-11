using System;

class BitwiseExtractBit
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            uint luiNumber, luiMask;
            Console.Write("Enter positive integer : ");
            luiNumber = uint.Parse(Console.ReadLine());
            luiMask = 1 << 3; // Move the 1st bit left by p positions
            Console.WriteLine("Value of the 3 Bit on number {0} -> {1}",luiNumber,(luiNumber & luiMask) != 0 ? 1 : 0);
        }
    }
}