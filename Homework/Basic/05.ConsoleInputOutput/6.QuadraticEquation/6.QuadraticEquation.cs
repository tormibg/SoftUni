using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            double dCoeffA = 0, dCoeffB = 0, dCoeffC;
            Console.Write("Enter coefficient a : ");
            dCoeffA = double.Parse(Console.ReadLine());
            Console.Write("Enter coefficient b : ");
            dCoeffB = double.Parse(Console.ReadLine());
            Console.Write("Enter coefficient c : ");
            dCoeffC = double.Parse(Console.ReadLine());
            double dSqr = dCoeffB * dCoeffB - 4 * dCoeffA * dCoeffC;
            if (dSqr > 0)
            {
                Console.WriteLine("X1 = {0}; X2 = {1}", (-dCoeffB - Math.Sqrt(dSqr)) / (2 * dCoeffA), (-dCoeffB + Math.Sqrt(dSqr)) / (2 * dCoeffA));
            }
            else if (dSqr < 0)
            {
                Console.WriteLine("no real roots");
            }
            else
            {
                Console.WriteLine("X1 = X2 = {0}", (-dCoeffB / (2 * dCoeffA)));
            }
        }
    }
}