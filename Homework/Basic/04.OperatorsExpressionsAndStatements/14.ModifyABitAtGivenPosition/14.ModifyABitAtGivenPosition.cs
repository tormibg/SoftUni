using System;

class ModifyABitAtGivenPosition
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int liNumber, liMask, liBit, liNewBit;
            Console.Write("Enter positive integer : ");
            liNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter a number of bit : ");
            liBit = int.Parse(Console.ReadLine());
            Console.Write("Enter a new value of a bit : ");
            liNewBit = int.Parse(Console.ReadLine());
            liMask = 1 << liBit; // Move the 1st bit left by p positions
            if (liNewBit == 0)
            {
                liNumber = liNumber & ~liMask;
            }
            else
            {
                liNumber = liNumber | liMask;
            }
            Console.WriteLine("The new number after change {0}-st bit with {1}, is a {2}", liBit, liNewBit, liNumber);
        }
    }
}