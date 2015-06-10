using System;

namespace _01.Point3D
{
    public class Point3D
    {
        private float coordX;
        private float coordY;
        private float coordZ;

        private static readonly Point3D ZeroPoint = new Point3D(0,0,0);

        public Point3D(float coordX, float coordY, float coordZ)
        {
            this.CoordX = coordX;
            this.CoordY = coordY;
            this.CoordZ = coordZ;
        }

        public float CoordX { get; set; }
        public float CoordY { get; set; }
        public float CoordZ { get; set; }

        public static Point3D GetZeroPoint()
        {
            return ZeroPoint;
        }

        public override string ToString()
        {
            string returnStr = String.Format("coordinate - X : {0}\ncoordinate - Y : {1}\ncoordinate - Z : {2}\n", this.CoordX, this.CoordY, this.CoordZ);
            return returnStr;
        }
    }
}
