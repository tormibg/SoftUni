using System;

class DivideBySevenAndFive
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int liNumber;
            bool lbDivided;
            Console.Write("Enter a integer number : ");
            if (int.TryParse(Console.ReadLine(), out liNumber))
            {
                if ((liNumber % 7 == 0) && (liNumber % 5 == 0) && (liNumber != 0))
                {
                    lbDivided = true;
                }
                else
                {
                    lbDivided = false;
                }
                Console.WriteLine("is the number {0} divided by 7 and 5? {1}", liNumber, lbDivided);
            }
            else
            {
                Console.WriteLine("Only a integer number");
            }
        }
    }
}