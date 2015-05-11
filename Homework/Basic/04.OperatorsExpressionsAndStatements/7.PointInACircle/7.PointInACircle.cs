using System;

class PointInACircle
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            double liCenterX = 0, liCenterY = 0, liRadius = 2;
            double liPointX, liPointY;
            Console.Write("Enter Point X cordinate : ");
            liPointX = double.Parse(Console.ReadLine());
            Console.Write("Enter Point Y cordinate : ");
            liPointY = double.Parse(Console.ReadLine());
            bool lsInCircle = ((liPointX - liCenterX) * (liPointX - liCenterX)) + ((liPointY - liCenterY) * (liPointY - liCenterY)) <= (liRadius * liRadius);
            Console.WriteLine("Is point in a circle  : {0}",lsInCircle);
        }
    }
}