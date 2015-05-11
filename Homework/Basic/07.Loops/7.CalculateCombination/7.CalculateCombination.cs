/* n! / (k! * (n-k)!) => (n-0)/1 * (n-1)/2 * (n-2)/3 * ..... * (n-(k-1))/k */

using System;

class CalculateCombination
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            uint iN, iK;
            double dResult = 1;
            Console.Write("Enter first positive integer number : ");
            var sN = Console.ReadLine();
            Console.Write("Enter second positive integer number < first number: ");
            var sK = Console.ReadLine();
            if (uint.TryParse(sN, out iN) && uint.TryParse(sK, out iK) && iN > iK && iN < 100)
            {
                for (int i = 1; i <= iK; i++)
                {
                    double dFactN = (iN - (i-1));
                    dResult = dResult * (dFactN / i);
                }
                Console.WriteLine(@"N! / (K! * (N-K)!) = {0}", dResult.ToString("F0"));
            }
            else
            {
                Console.WriteLine("Onli positive integer numbers and first number > second number and < 100");
            }
        }
    }
}