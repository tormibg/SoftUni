using System;
using Shapes.Interface;

namespace Shapes.Models
{
    public class Circle:IShape
    {

        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public double Radius { get; set; }

        public double CalculateArea()
        {
            double area;
            area = Math.PI*this.Radius*this.Radius;
            return area;
        }

        public double CalculatePerimeter()
        {
            double perim;
            perim = Math.PI * 2 * this.Radius;
            return perim;
        }
    }
}