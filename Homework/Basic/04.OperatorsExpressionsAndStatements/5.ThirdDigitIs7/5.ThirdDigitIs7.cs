using System;

class ThirdDigitIs7
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            string lsNumber;
            bool lbIsSeven = false;
            Console.Write("Enter integer number : ");
            lsNumber = Console.ReadLine();
            if (lsNumber.Length >= 3)
            {
                if (lsNumber[lsNumber.Length - 3] == '7')
                {
                    lbIsSeven = true;
                }
            }
            Console.WriteLine("If third digit from right-to-left is 7 -> {0}", lbIsSeven);
        }
    }
}