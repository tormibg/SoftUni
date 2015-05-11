using System;

class PrimeNumberCheck
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            double liUpSide, liDownSide, liHeight;
            Console.Write("Enter trapezoid up side : ");
            liUpSide = double.Parse(Console.ReadLine());
            Console.Write("Enter trapezoid down side : ");
            liDownSide = double.Parse(Console.ReadLine());
            Console.Write("Enter trapezoid height : ");
            liHeight = double.Parse(Console.ReadLine());
            Console.WriteLine("\nTrapezoid area is: {0} \n", (liUpSide + liDownSide) / 2 * liHeight);
        }
    }
}