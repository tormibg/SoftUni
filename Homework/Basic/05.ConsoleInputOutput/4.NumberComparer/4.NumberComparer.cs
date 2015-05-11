using System;

class NumberComparer
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            double dNumber1 = 0, dNumber2 = 0;
            string sNum1, sNum2;
            Console.Write("Enter first number : ");
            sNum1 = Console.ReadLine();
            Console.Write("Enter second number : ");
            sNum2 = Console.ReadLine();
            if (double.TryParse(sNum1, out dNumber1) && double.TryParse(sNum2,out dNumber2))
            {
                Console.WriteLine("1.Max is {0}",Math.Max(dNumber1,dNumber2));
                Console.WriteLine("2.Max is {0}",((dNumber1+dNumber2)+Math.Abs(dNumber1-dNumber2))/2);
            }
            else
            {
                Console.WriteLine("Only numbers !");
            }
        }
    }
}