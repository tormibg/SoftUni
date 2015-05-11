using System;

class SumOfFiveNumbers
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            Console.Write("Enters 5 numbers separated by space: ");
            string[] aValues = Console.ReadLine().Split(' ');
            double[] aNumbers = new double[aValues.Length];
            bool bIsNum = true;
            double dSum = 0;
            for (int i = 0; i < aValues.Length; i++)
            {
                if (!double.TryParse(aValues[i], out aNumbers[i]))
                {
                    Console.WriteLine("Only numbers !");
                    bIsNum = false;
                    break;
                }
                else
                {
                    dSum += aNumbers[i];
                }
             }
            if (bIsNum)
            {
                Console.WriteLine("Sum = {0}",dSum);
            }
        }
    }
}