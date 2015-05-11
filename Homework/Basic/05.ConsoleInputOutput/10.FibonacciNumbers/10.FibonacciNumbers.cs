using System;

class FibonacciNumbers
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int iNum;
            ulong ulOldNum = 0, ulNewNum = 1, ulTmp=0;
            Console.Write("How many Fibonacci numbers do you want : ");
            if (int.TryParse(Console.ReadLine(), out iNum) && iNum > 0)
            {
                if (iNum == 1)
                {
                    Console.Write("{0} ", ulOldNum);
                }
                else
                {
                    Console.Write("{0} {1} ", ulOldNum, ulNewNum);
                    for (int i = 2; i < iNum; i++)
                    {
                        ulTmp = ulNewNum + ulOldNum;
                        Console.Write("{0} ", ulTmp);
                        ulOldNum = ulNewNum;
                        ulNewNum = ulTmp;
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Only numbers > 0");
            }
        }
    }
}