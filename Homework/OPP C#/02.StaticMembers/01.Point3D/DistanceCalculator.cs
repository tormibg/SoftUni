using System;
using System.Linq;

namespace _01.Point3D
{
    static class DistanceCalculator
    {
        // proc methods
        public static float CalcDistP(Point3D newPoint3D, Point3D newPoint3D2)
        {
            float divX, divY, divZ;

            divX = newPoint3D.CoordX - newPoint3D2.CoordX;

            divY = newPoint3D.CoordY - newPoint3D2.CoordY;

            divZ = newPoint3D.CoordZ - newPoint3D2.CoordZ;

            float distance = (float) Math.Sqrt(divX*divX + divY*divY + divZ*divZ);

            return distance;
        }
        // linq method
        public static float CalcDistL(Point3D newPoint3D, Point3D newPoint3D2)
        {
            float[] array1 = new float[] {newPoint3D.CoordX, newPoint3D.CoordY, newPoint3D.CoordZ};
            float[] array2 = new float[] {newPoint3D2.CoordX, newPoint3D2.CoordY, newPoint3D2.CoordZ};

            float distance = (float) Math.Sqrt(array1.Zip(array2, (a, b) => (a - b)*(a - b)).Sum());

            return distance;
        }
    }
}
