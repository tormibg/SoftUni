using System;

class Sort3NumbersWithNestedIfs
{
    static void Main()
    {
        while (true)
        {
            double a = 0, b = 0, c = 0;
            Console.Write("Enter first real number : ");
            var tmpA = Console.ReadLine();
            Console.Write("Enter second real number : ");
            var tmpB = Console.ReadLine();
            Console.Write("Enter third real number : ");
            var tmpC = Console.ReadLine();
            if (double.TryParse(tmpA, out a) && double.TryParse(tmpB, out b) && double.TryParse(tmpC, out c))
            {
                if (a >= b && a >= c)
                {
                    if (b >= c)
                    {
                        Console.WriteLine("{0} {1} {2}", a, b, c);
                    }
                    else
                    {
                        Console.WriteLine("{0} {1} {2}", a, c, b);
                    }
                }
                else if (b >= a && b >= c)
                {
                    if (a >= c)
                    {
                        Console.WriteLine("{0} {1} {2}", b, a, c);
                    }
                    else
                    {
                        Console.WriteLine("{0} {1} {2}", b, c, a);
                    }
                }
                else if (a >= b)
                {
                    Console.WriteLine("{0} {1} {2}", c, a, b);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", c, b, a);
                }
            }
            else
            {
                Console.WriteLine("Only numbers");
            }
        }
    }
}