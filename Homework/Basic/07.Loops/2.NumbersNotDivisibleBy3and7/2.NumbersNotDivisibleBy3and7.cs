using System;

class NumbersNotDivisibleBy3and7
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            uint iNum;
            Console.Write("Enter positive integer number :");
            if (uint.TryParse(Console.ReadLine(), out iNum))
            {
                for (int i = 1; i <= iNum; i++)
                {
                    if (i % 3 != 0 && i % 7 != 0)
                    {
                        Console.Write("{0} ", i);
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Only positive integer number.");
            }
        }
    }
}