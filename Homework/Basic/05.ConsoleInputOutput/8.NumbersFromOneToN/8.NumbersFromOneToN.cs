using System;

class NumbersFromOneToN
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int iNum;
            Console.Write("Enter integer number: ");
            if (int.TryParse(Console.ReadLine(), out iNum))
            {
                for (int i = 0; i < iNum; i++)
                {
                    Console.WriteLine(i+1);
                }
            }
            else
            {
                Console.WriteLine("Only numbers.");
            }
        }
    }
}