using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;

class PerimeterAndAreaOfPolygon
{
    static void Main()
    {
        
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            Polygon pPol = new Polygon();
            int iNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < iNum; i++)
            {
                List<int> lTmpInts = (Console.ReadLine().Split(' ')).Select(s => int.Parse(s)).ToList(); 
                pPol.LPoints.Add(new Point(lTmpInts[0],lTmpInts[1]));
            }
            Console.WriteLine("perimeter = {0:F}",pPol.GetPerimeter());
            Console.WriteLine("area = {0:F}", pPol.GerArea());
        }
    }
}
