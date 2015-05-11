using System;

class Triangle
{
    static void Main()
    {
        int aX = int.Parse(Console.ReadLine());
        int aY = int.Parse(Console.ReadLine());
        int bX = int.Parse(Console.ReadLine());
        int bY = int.Parse(Console.ReadLine());
        int cX = int.Parse(Console.ReadLine());
        int cY = int.Parse(Console.ReadLine());
        double iAB = GetDistance(aX, aY, bX, bY);
        double iBC = GetDistance(bX, bY, cX, cY);
        double iCA = GetDistance(cX, cY, aX, aY);
        if (iAB + iBC > iCA &&
            iBC + iCA > iAB &&
            iCA + iAB > iBC)
        {
            Console.WriteLine("Yes");
            double p = (iAB + iBC + iCA)/2;
            double area = Math.Sqrt(p*(p - iAB)*(p - iBC)*(p - iCA));
            Console.WriteLine("{0:f}",area);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("{0:f}",iAB);
        }

    }

    private static double GetDistance(int aX, int aY, int bX, int bY)
    {
        double dDist = Math.Sqrt(Math.Pow(bX - aX, 2) + Math.Pow(bY - aY, 2));
        return dDist;
    }
}