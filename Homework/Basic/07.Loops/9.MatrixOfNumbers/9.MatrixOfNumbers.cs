using System;

class MatrixOfNumbers
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            uint iN;
            Console.Write(@"Enter positive integer number N (1 <= N <= 20). : ");
            if (uint.TryParse(Console.ReadLine(), out iN) && iN <= 20 && iN >= 1)
            {
                for (int i = 1; i <= iN; i++)
                {
                    for (int j = i; j < i+iN; j++)
                    {
                        Console.Write("{0,2} ",j);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Onli positive integer number and 1 <= N <= 20");
            }
        }
    }
}