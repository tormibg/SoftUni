using System;

class CheckABitAtGivenPosition
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
            Console.WriteLine("is the {0}-st bit == 1 ? {1}", lsbBit, (luiNumber & luiMask) != 0 ? true : false);
        }
    }
}