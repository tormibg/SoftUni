using System;

class OddEvenElements
{
    static void Main()
    {
        string[] sNumbers = Console.ReadLine().Split();
        decimal dSum = 0, dMin = decimal.MaxValue, dMax = decimal.MinValue;
        if (sNumbers.Length == 1 && sNumbers[0] == "")
        {
            Console.Write("OddSum={0}, OddMin={0}, OddMax={0}", "No");    
        }
        else
        {
            for (int i = 0; i < sNumbers.Length; i += 2)
            {
                decimal num = decimal.Parse(sNumbers[i]);
                dSum += num;
                dMin = Math.Min(dMin, num);
                dMax = Math.Max(dMax, num);
            }
            Console.Write("OddSum={0}, OddMin={1}, OddMax={2}", (double)dSum, (double)dMin, (double)dMax);   
        }
        if (sNumbers.Length < 2)
        {
            Console.WriteLine(", EvenSum={0}, EvenMin={0}, EvenMax={0}", "No");    
        }
        else
        {
            dSum = 0;
            dMin = decimal.MaxValue;
            dMax = decimal.MinValue;
            for (int i = 1; i < sNumbers.Length; i += 2)
            {
                decimal num = decimal.Parse(sNumbers[i]);
                dSum += num;
                dMin = Math.Min(dMin, num);
                dMax = Math.Max(dMax, num);
            }
            Console.WriteLine(", EvenSum={0}, EvenMin={1}, EvenMax={2}", (double)dSum, (double)dMin, (double)dMax);   
        }
    }
}