using System;

class ExtractBitFromInteger
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            uint luiNumber;
            int luiMask, lsbBit;
            Console.Write("Enter positive integer : ");
            luiNumber = uint.Parse(Console.ReadLine());
            Console.Write("Enter a number of bit : ");
            lsbBit = int.Parse(Console.ReadLine());
            luiMask = 1 << lsbBit; // Move the 1st bit left by p positions
            Console.WriteLine("Value of the {0} Bit on number {1} -> {2}", lsbBit, luiNumber, (luiNumber & luiMask) != 0 ? 1 : 0);
        }
    }
}