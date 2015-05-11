using System;

class RandomizeTheNumbers1N
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int iN;
            Console.Write("Enter n /integer/ : ");
            if (int.TryParse(Console.ReadLine(), out iN))
            {
                bool[] bIsPrint = new bool[iN+1];
                for (int i = 0; i < iN; i++)
                {
                    Random rnd = new Random();
                    int iRndNum;
                    do
                    {
                        iRndNum = rnd.Next(1, iN + 1);
                    } while (bIsPrint[iRndNum]);
                    Console.Write("{0} ", iRndNum);
                    bIsPrint[iRndNum] = true;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Onli integer number.");
            }
        }
    }
}