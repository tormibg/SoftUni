using System;

internal class TrailingZeroesInN
{
    private static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            uint iNum;
            Console.Write("Enter positive integer number : ");
            if (uint.TryParse(Console.ReadLine(), out iNum) && iNum > 0)
            {
                uint iCount = 0;
                uint iDivider = 5;
                do
                {
                    iCount += (uint)(iNum / iDivider);
                    iDivider *= 5;

                }while (iNum / iDivider >= 1);
                Console.WriteLine("Trailing zeroes of {0}! : {1}",iNum,iCount);
            }
            else
            {
                Console.WriteLine("Only positive integer number.");
            }
        }
    }
}