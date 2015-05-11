using System;

class BinaryToDecimalNumber
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            string sN;
            Console.Write("Enter a binary number : ");
            sN = Console.ReadLine();
            int iDecimal = 0;
            for (int i = sN.Length; i > 0; i--)
            {
                if (sN[i - 1] == '1')
                {
                    iDecimal = iDecimal + (int)Math.Pow(2, sN.Length - i);   
                }
            }
            Console.WriteLine("Decimal : {0}",iDecimal);
        }
    }
}