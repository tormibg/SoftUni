using System;

class CirclePerimeterAndArea
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            double dRad = 0;
            Console.Write("Enter radius : ");
            if (double.TryParse(Console.ReadLine(), out dRad))
            {
                Console.WriteLine("Perimeter : {0:F2}", 2 * Math.PI * dRad);
                Console.WriteLine("Area : {0:F2}", Math.PI * dRad * dRad);
            }
            else
            {
                Console.WriteLine("Only numbers !");
            }
        }
    }
}