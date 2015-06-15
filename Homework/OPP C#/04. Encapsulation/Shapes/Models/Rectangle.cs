namespace Shapes.Models
{
    public class Rectangle:BasicShape
    {

        public Rectangle(double width, double height) : base(width, height)
        {
            
        }

        public override double CalculateArea()
        {
            double area;
            area = this.Height * this.Width;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perim;
            perim = (this.Height + this.Width)*2;
            return perim;
        }
    }
}