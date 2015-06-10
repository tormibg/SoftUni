using System;
using System.IO;

namespace _01.Point3D
{
    class InputTest
    {
        private const string PathToFile = @"../../test.txt";
        private static void Main()
        {
            // first point
            Point3D newPoint3D = new Point3D(2, 3, 4);
            Console.WriteLine(newPoint3D);
            // second point
            Point3D newPoint3D2 = new Point3D(5, 6, 7);
            Console.WriteLine(newPoint3D2);

            // print ZeroPoint
            Console.WriteLine(Point3D.GetZeroPoint());

            //Distance #1
            float distance = DistanceCalculator.CalcDistP(newPoint3D, newPoint3D2);
            Console.WriteLine("Distance proc method: {0}", distance);

            //Distance #2
            distance = DistanceCalculator.CalcDistL(newPoint3D, newPoint3D2);
            Console.WriteLine("Distance linq method: {0}", distance);

            // Path3D
            Path3D pathh = new Path3D();
            pathh.AddPoin(new Point3D(2, 3, 4));
            pathh.AddPoin(new Point3D(5, 6, 7));
            Console.WriteLine();
           // path.PointList.Add(new Point3D(2, 3, 4));
           // Console.WriteLine(path.PointList[2]);

            //Path load from file
            pathh = Storage.LoadFromFile(PathToFile);

            int countPoint = pathh.GetCount(pathh);
            Console.WriteLine(countPoint);

            //Path save to file
            pathh.AddPoin(new Point3D(9, 9, 9));

            countPoint = pathh.GetCount(pathh);
            Console.WriteLine(countPoint);

            string[] pointStrings = new string[countPoint];

            for (int i = 0; i < countPoint; i++)
            {
                pointStrings[i] = pathh.GetPoint(pathh, i);
            }

            Storage.WriteToFile(pointStrings, PathToFile);
        }
    }
}
