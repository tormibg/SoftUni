using System;

class SumOfThreeNumbers
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            double dNumber1 = 0, dNumber2 = 0, dNumber3 = 0;
            string sNumber1, sNumber2, sNumber3;
            Console.Write("Enter the first /real/ number : ");
            sNumber1 = Console.ReadLine();
            Console.Write("Enter the second /real/ number : ");
            sNumber2 = Console.ReadLine();
            Console.Write("Enter the third /real/ number : ");
            sNumber3 = Console.ReadLine();
            if (double.TryParse(sNumber1, out dNumber1) && double.TryParse(sNumber2, out dNumber2) && double.TryParse(sNumber3, out dNumber3))
            {
                Console.WriteLine("{0} + {1} + {2} = {3}", dNumber1, dNumber2, dNumber3, dNumber1 + dNumber2 + dNumber3);
            }
            else
            {
                Console.WriteLine("Only numbers !");
            }
        }
    }
}