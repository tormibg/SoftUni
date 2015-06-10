using System;
using System.IO;
using System.Linq;

namespace _01.Point3D
{
    public static class Storage
    {
        public static Path3D LoadFromFile(string pathToFile)
        {
            Path3D pathh = new Path3D();
            StreamReader sr = new StreamReader(pathToFile);
            string[] readStrings;
            using (sr)
            {
                readStrings = sr.ReadToEnd().Split(new[] {' ', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            for (int i = 0; i < readStrings.Length; i+=3)
            {
                pathh.AddPoin(new Point3D(float.Parse(readStrings[i]), float.Parse(readStrings[i + 1]),
                    float.Parse(readStrings[i + 2])));
            }
            return pathh;
        }

        public static void WriteToFile(string[] pathh, string fileToWrite)
        {
            StreamWriter sw = new StreamWriter(fileToWrite);
            using (sw)
            {
                for (int i = 0; i < pathh.Length; i++)
                {

                    sw.WriteLine(pathh[i]);
                }
            }
        }
    }
}