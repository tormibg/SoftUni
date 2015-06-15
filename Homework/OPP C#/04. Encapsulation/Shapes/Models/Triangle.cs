namespace Shapes.Models
{
    public class Triangle : BasicShape
    {
        public Triangle(double width, double height, double secSide, double thirdSide)
            : base(width, height)
        {
            this.SecSide = secSide;
            this.ThirdSide = thirdSide;
        }

        public double ThirdSide { get; set; }
        public double SecSide { get; set; }

        public override double CalculateArea()
        {
            double area;
            area = (this.Height*this.Width)/2D;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perim;
            perim = this.ThirdSide + this.SecSide + this.Width;
            return perim;
        }
    }
}