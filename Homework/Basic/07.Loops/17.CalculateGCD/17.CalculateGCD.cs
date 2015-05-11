using System;

class CalculateGCD
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int iA, iB;
            string sA, sB;
            Console.Write("Enter first integer number a : ");
            sA = Console.ReadLine();
            Console.Write("Enter second integer number b : ");
            sB = Console.ReadLine();
            if (int.TryParse(sA, out iA) && int.TryParse(sB, out iB))
            {
                if (iA < iB)
                {
                    int iTmpNum = iA;
                    iA = iB;
                    iB = iTmpNum;
                }
                int iDivNum = (iA % iB);
                while (iDivNum != 0)
                {
                    iA = iB;
                    iB = iDivNum;
                    iDivNum = (iA % iB);
                }
                Console.WriteLine(@"GCD(a, b) = {0}",iB);
            }
            else
            {
                Console.WriteLine("Onli integer numbers.");
            }
        }
    }
}