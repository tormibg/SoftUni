namespace Lib
{
    public struct Point3D
    {
        // 1.Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
        //Implement the ToString() to enable printing a 3D point.

        public int x;
        public int y;
        public int z;

        // Constructor
        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            string result;

            result = "X = " + this.x + "\nY = " + this.y + "\nZ = " + this.z;
            // Yes, it is better to use StringBuilder if it was something longer.
            return result;
        }
        // 2. Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. 
        // Add a static property to return the point O.

        private static readonly int startX = 0;
        private static readonly int startY = 0;
        private static readonly int startZ = 0;

        public static Point3D StartPointO()
        {
            return new Point3D(startX, startY, startZ);
        }

    }
}