using System;

class PrimeNumberCheck
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int liNumber, liCounter;
            bool lbIsPrime = false;
            Console.Write("Enter integer number between 1 and 100 : ");
            liNumber = int.Parse(Console.ReadLine());
            if (liNumber > 1)
            {
                liCounter = (int)Math.Sqrt(liNumber);
                lbIsPrime = true;
                for (int i = 2; i <= liCounter; i++)
                {
                    if ((liNumber % i) == 0)
                    {
                        lbIsPrime = false;
                        break;
                    }
                }
            }

            Console.WriteLine("is a number a prime : {0}", lbIsPrime);
        }
    }
}