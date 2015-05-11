using System;

class FormattingNumbers
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int iNumber1 = 0;
            double dNumber2 = 0, dNumber3 = 0;
            string sNum2, sNum3;
            Console.Write(@"Enter integer number (0 - 500) : ");
            while (!int.TryParse(Console.ReadLine(), out iNumber1) || iNumber1 < 0 || iNumber1 > 500)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid Input, please input an integer from 0 - 500");
                Console.Write("Please enter new number : ");
            }
            Console.Write("Enter real first number : ");
            sNum2 = Console.ReadLine();
            Console.Write("Enter real second number : ");
            sNum3 = Console.ReadLine();
            if (double.TryParse(sNum2, out dNumber2) && double.TryParse(sNum3,out dNumber3))
            {
                Console.Write("|{0,-10:X}|{1,10}", iNumber1,Convert.ToString(iNumber1,2).PadLeft(10,'0'));
                Console.WriteLine("|{0,10:F2}|{1,-10:F3}|", dNumber2,dNumber3);
            }
            else
            {
                Console.WriteLine("Enter numbers.");
            }
        }
    }
}