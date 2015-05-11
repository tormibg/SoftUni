using System;

class MultiplicationSign
{
    static void Main()
    {
        while (true)
        {
            double a = 0, b = 0, c = 0;
            char? lcResult = null;
            Console.Write("Enter first real number : ");
            var tmpA = Console.ReadLine();
            Console.Write("Enter second real number : ");
            var tmpB = Console.ReadLine();
            Console.Write("Enter third real number : ");
            var tmpC = Console.ReadLine();
            if (double.TryParse(tmpA, out a) && double.TryParse(tmpB, out b) && double.TryParse(tmpC, out c))
            {
                if (a == 0 || b == 0 || c == 0)
                {
                    lcResult = '0';
                }
                else if ((a < 0 ^ b < 0) ^ (c < 0))
                {
                    lcResult = '-';
                }
                else
                {
                    lcResult = '+';
                }
                Console.WriteLine("The sign is a : {0}", lcResult);
            }
            else
            {
                Console.WriteLine("Only numbers");
            }
        }
    }
}