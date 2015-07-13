using System;

namespace InterestCalc
{
    class InterestCalc
    {
        public const int TimesPerYear = 12;

        public static decimal GetSimpleInterest(decimal sum , decimal interest , int years )
        {
            // A = sum * (1 + interest * years)
            decimal simpleInt = sum*(1 + interest*years);
            return simpleInt;
        }

        public static decimal GetCompoundInterest(decimal sum, decimal interest, int years)
        {
            // A = sum * (1 + interest / n)year * n

            decimal CompInt = sum*(decimal) Math.Pow((double) (1 + interest/TimesPerYear), years*TimesPerYear);
            return CompInt;
        }

        static void Main()
        {
            InterestCalculator intCalc = new InterestCalculator(500m,0.056m,10,GetCompoundInterest);
            Console.WriteLine("{0:F4}",intCalc.TSum);
            InterestCalculator intCalc1 = new InterestCalculator(2500m, 0.072m, 15, GetSimpleInterest);
            Console.WriteLine("{0:F4}", intCalc1.TSum);
        }
    }
}
