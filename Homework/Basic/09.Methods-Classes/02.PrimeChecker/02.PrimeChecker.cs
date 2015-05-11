using System;

class PrimeChecker
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            long iNum = 0;
            Console.Write("Enter a number : ");
            if (long.TryParse(Console.ReadLine(), out iNum) && iNum >= 0)
            {
                Console.WriteLine("{0} {1}", iNum, IsPrime(iNum));
            }
            else
            {
                Console.WriteLine("Only numbers >= 0");
            }
        }
    }

    static bool IsPrime(long iNum)
    {
        bool bIsPrime = false;
        if (iNum == 0 || iNum == 1)
        {
            return false;
        }
        else if (iNum == 2)
        {
            return true;
        }
        for (int i = 2; i <= Math.Sqrt(iNum); i++)
        {
            if (iNum % i == 0)
            {
                return false;
            }   
        }
        return true;
    }
}
