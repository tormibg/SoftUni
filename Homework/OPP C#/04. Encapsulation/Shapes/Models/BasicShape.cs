using Shapes.Interface;

namespace Shapes.Models
{
    public abstract class BasicShape : IShape
    {

        protected BasicShape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        public double Width { get; set; }
        public double Height { get; set; }

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();
    }
}