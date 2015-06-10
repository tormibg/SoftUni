using System;
using System.Collections.Generic;

namespace _01.Point3D
{
    public class Path3D
    {
        private List<Point3D> pointList = new List<Point3D>();

        private List<Point3D> PointList
        {
            get { return this.pointList; }
        }

        public void AddPoin(Point3D point)
        {
            this.PointList.Add(point);
        }


        internal int GetCount(Path3D pathh)
        {
            int count;
            count = pathh.PointList.Count;
            return count;
        }

        internal string GetPoint(Path3D pathh, int i)
        {
            string returnStr = string.Format("{0} {1} {2}", pathh.PointList[i].CoordX, pathh.PointList[i].CoordY,
                pathh.PointList[i].CoordZ);
            return returnStr;
        }
    }
}