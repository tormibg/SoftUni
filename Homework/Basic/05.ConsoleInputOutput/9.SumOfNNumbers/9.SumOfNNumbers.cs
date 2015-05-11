using System;

class SumOfNNumbers
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int iNum;
            double dSum = 0;
            bool bIsSum = true;
            Console.Write("How many numbers do you want to input: ");
            if (int.TryParse(Console.ReadLine(), out iNum))
            {
                for (int i = 0; i < iNum; i++)
                {
                    Console.Write("Enter {0}-st number :", i + 1);
                    double dNum;
                    if (double.TryParse(Console.ReadLine(), out dNum))
                    {
                        dSum += dNum;
                    }
                    else
                    {
                        Console.WriteLine("Only numbers.");
                        bIsSum = false;
                        break;
                    }
                }
                if (bIsSum)
                {
                    Console.WriteLine(dSum);
                }
            }
            else
            {
                Console.WriteLine("Only numbers.");
            }
        }
    }
}