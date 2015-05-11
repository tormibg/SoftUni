using System;

class FibonacciNumbers
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int iNum;
            Console.Write("Whitch Fibonacci numbers do you want : ");
            if (int.TryParse(Console.ReadLine(), out iNum) && iNum >= 0)
            {
                Console.WriteLine("{0} {1}",iNum, fib(iNum));
            }
            else
            {
                Console.WriteLine("Only numbers >= 0");
            }
        }
    }

    static ulong fib(int iNumFib)
    {
        ulong ulOldNum = 0, ulNewNum = 1, ulTmp = 0;
        if (iNumFib == 0)
        {
            ulTmp = 1;
        }
        else
        {
            for (int i = 0; i < iNumFib; i++)

            {
                ulTmp = ulNewNum + ulOldNum;
                ulOldNum = ulNewNum;
                ulNewNum = ulTmp;
            }
        }
        return ulTmp;
    }
}
