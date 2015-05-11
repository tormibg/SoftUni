using System;

class CalculateNfKf
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            uint iN, iK;
            double dFactN = 1, dFactK = 1;
            string sN, sK;
            Console.Write("Enter first positive integer number : ");
            sN = Console.ReadLine();
            Console.Write("Enter second positive integer number < first number: ");
            sK = Console.ReadLine();
            if (uint.TryParse(sN, out iN) && uint.TryParse(sK, out iK) && iN > iK && iN < 100)
            {
                for (int i = 1; i <= iN; i++)
                {
                    dFactN = dFactN * i;
                    if (i <= iK)
                    {
                        dFactK = dFactK * i;
                    }
                }
                Console.WriteLine(@"N!/K! = {0}", (dFactN / dFactK).ToString("F0"));
            }
            else
            {
                Console.WriteLine("Onli positive integer numbers and first number > second number and < 100");
            }
        }
    }
}
