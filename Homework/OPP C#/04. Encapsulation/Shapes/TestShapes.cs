using System;
using Shapes.Interface;
using Shapes.Models;

namespace Shapes
{
    class TestShapes
    {
        static void Main()
        {
            IShape[] newFigure = new IShape[]
            {
                new Circle(12),
                new Circle(15),
                new Rectangle(12,13),
                new Rectangle(10,5),
                new Triangle(11,4,6,8),
                new Triangle(12,5,5,13), 
            };
            foreach (IShape shape in newFigure)
            {
                Console.WriteLine("{0} - Area : {1:F2}, Perimeter : {2:F2}",shape.GetType().Name,shape.CalculateArea(), shape.CalculatePerimeter());
            }
        }
    }
}
