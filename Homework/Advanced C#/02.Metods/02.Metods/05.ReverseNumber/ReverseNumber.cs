using System;
using System.Linq;

class ReverseNumber
{
    private static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            double input = Double.Parse(Console.ReadLine());

            Console.WriteLine(RevNum(input));
        }
    }

    static double RevNum(double number)
        {
            bool isNegative = number < 0;
            char[] chArr = Math.Abs(number).ToString().ToCharArray();
            Array.Reverse(chArr);
            double numResult = Convert.ToDouble(new string(chArr));
            return isNegative ? -numResult : numResult;
        }
}