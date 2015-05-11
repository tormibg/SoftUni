using System;

internal class PointClass
{
    private static void Main()
    {
        Point x = new Point();
        Point y = new Point();
        x.SetCordinates(20,30);
        y.SetCordinates(0,100);
        x.PrintPoint();
        y.PrintPoint();
    }
}