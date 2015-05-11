using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int liNumber = 0;
            bool lbIsOdd;
            Console.Write("Enter a integet number : ");
            if (int.TryParse(Console.ReadLine(), out liNumber))
            {
                if ((liNumber % 2) != 0)
                {
                    lbIsOdd = true;
                }
                else
                {
                    lbIsOdd = false;
                }
                Console.WriteLine("Is the number {0} odd : {1}", liNumber, lbIsOdd);
            }
            else
            {
                Console.WriteLine("Only a integer number");
            }
        }
    }
}