using System;

class ExchangeIfGreater
{
    static void Main()
    {
        while (true)
        {
            int a, b, tmpVar;
            Console.Write("Enter first number : ");
            var firstNumber = Console.ReadLine();
            Console.Write("Enter second number : ");
            var secNumber = Console.ReadLine();
            if (int.TryParse(firstNumber, out a) && int.TryParse(secNumber, out b))
            {
                if (a > b)
                {
                    tmpVar = a;
                    a = b;
                    b = tmpVar;
                }
                Console.WriteLine(a + " " + b);
            }
            else
            {
                double firstDouble = 0, secDouble = 0, tmpDouble;
                if (double.TryParse(firstNumber, out firstDouble) && double.TryParse(secNumber, out secDouble))
                {
                    if (firstDouble > secDouble)
                    {
                        tmpDouble = firstDouble;
                        firstDouble = secDouble;
                        secDouble = tmpDouble;
                    }
                }
                Console.WriteLine(firstDouble + " " + secDouble);
            }
        }
    }

}