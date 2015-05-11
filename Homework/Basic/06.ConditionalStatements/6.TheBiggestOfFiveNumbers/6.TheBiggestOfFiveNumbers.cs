using System;

class TheBiggestOfFiveNumbers
{
    static void Main()
    {
        while (true)
        {
            double a = 0, b = 0, c = 0, d = 0, e = 0, ldMaxNumber = 0;
            Console.Write("Enter first real number : ");
            var tmpA = Console.ReadLine();
            Console.Write("Enter second real number : ");
            var tmpB = Console.ReadLine();
            Console.Write("Enter third real number : ");
            var tmpC = Console.ReadLine();
            Console.Write("Enter fourthly real number : ");
            var tmpD = Console.ReadLine();
            Console.Write("Enter fifth real number : ");
            var tmpE = Console.ReadLine();
            if (double.TryParse(tmpA, out a) && double.TryParse(tmpB, out b) && double.TryParse(tmpC, out c) &&
                double.TryParse(tmpD, out d) && double.TryParse(tmpE, out e))
            {
                if (a > b)
                {
                    ldMaxNumber = a;
                }
                else
                {
                    ldMaxNumber = b;
                }
                if (c > ldMaxNumber)
                {
                    ldMaxNumber = c;
                }
                if (d > ldMaxNumber)
                {
                    ldMaxNumber = d;
                }
                if (e > ldMaxNumber)
                {
                    ldMaxNumber = e;
                }
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("The biggest number is : {0}", ldMaxNumber);
                Console.WriteLine(new string('-', 40));
                // Another way
                /*Console.WriteLine("Another way :");
            
                if ((a >= b) && (a >= c) && (a >= d) && (a >= e))
                {
                    ldMaxNumber = a;
                }
                if ((b >= a) && (b >= c) && (b >= d) && (b >= e))
                {
                    ldMaxNumber = b;
                }
                if ((c >= a) && (c >= b) && (c >= d) && (c >= e))
                {
                    ldMaxNumber = c;
                }
                if ((d >= a) && (d >= b) && (d >= c) && (d >= e))
                {
                    ldMaxNumber = d;
                }
                if ((e >= a) && (e >= b) && (e >= c) && (e >= d))
                {
                    ldMaxNumber = e;
                }
                Console.WriteLine("The biggest number is : {0}", ldMaxNumber);
                Console.WriteLine(new string('-', 40)); */
            }
            else
            {
                Console.WriteLine("Only numbers");
            }
        }
    }
}