using System;

class CalculateNF
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int iN, iX;
            double dSum = 1, dFact = 1, dXatX= 1;
            string sN, sX;
            Console.Write("Enter first integer number : ");
            sN = Console.ReadLine();
            Console.Write("Enter second integer number : ");
            sX = Console.ReadLine();
            if (int.TryParse(sN, out iN) && int.TryParse(sX, out iX))
            {
                for (int i = 1; i <= iN; i++)
                {
                    dFact = dFact*i;
                    dXatX = dXatX*iX;
                    dSum = dSum + (dFact/dXatX);
                }
                Console.WriteLine("Sum = {0}",dSum.ToString("F5"));
            }
            else
            {
                Console.WriteLine("Onli integer numbers.");
            }
        }
    }
}