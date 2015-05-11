using System;

class Point
{
    public int XCor;
    public int YCor;

    public Point(int x,int y)
    {
        this.XCor = x;
        this.YCor = y;
    }

    public void SetCordinates(int p1, int p2)
    {
        this.XCor = p1;
        this.YCor = p2;
    }

    public static double GetLenght(Point p1, Point p2)
    {
        double dLeght = Math.Sqrt(Math.Pow((p1.XCor - p2.XCor), 2) + Math.Pow((p1.YCor - p2.YCor), 2));
        return dLeght;
    }

    public static double GetAreaForm(Point p1, Point p2)
    {
        return (p1.XCor*p2.YCor - p1.YCor*p2.XCor);
    }
}
