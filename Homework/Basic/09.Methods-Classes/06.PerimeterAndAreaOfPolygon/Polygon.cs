using System;
using System.Collections.Generic;

class Polygon
{
    public List<Point> LPoints { get; set; }

    public Polygon()
    {
        this.LPoints = new List<Point>();
    }

    public double GetPerimeter()
    {
        double dTmpPerimeter = 0;

        for (int i = 1; i < this.LPoints.Count; i++)
        {
            dTmpPerimeter += Point.GetLenght(this.LPoints[i - 1] , this.LPoints[i]);
        }
        dTmpPerimeter += Point.GetLenght(this.LPoints[0], this.LPoints[this.LPoints.Count - 1]);
        return dTmpPerimeter;
    }

    public double GerArea()
    {
        double dTmpArea = 0;
        for (int i = 1; i < this.LPoints.Count; i++)
        {
            dTmpArea += Point.GetAreaForm(this.LPoints[i - 1], this.LPoints[i]);
        }
        dTmpArea += Point.GetAreaForm(this.LPoints[0], this.LPoints[this.LPoints.Count - 1]);
        dTmpArea = Math.Abs(dTmpArea/2);
        return dTmpArea;
    }
}
