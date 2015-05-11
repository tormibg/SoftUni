using System;

class PointCircleAndRectangle
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            double ldCenterX = 1, ldCenterY = 1, ldRadius = 1.5;
            double ldTopRec = 1, ldLeftRec = -1, ldWidth = 6, ldHeightRec = 2;
            double ldPointX, ldPointY;
            Console.Write("Enter Point X cordinate : ");
            ldPointX = double.Parse(Console.ReadLine());
            Console.Write("Enter Point Y cordinate : ");
            ldPointY = double.Parse(Console.ReadLine());
            bool lsInCircle = ((ldPointX - ldCenterX) * (ldPointX - ldCenterX)) + ((ldPointY - ldCenterY) * (ldPointY - ldCenterY)) <= (ldRadius * ldRadius);
           // Console.WriteLine("Is point in a circle : {0}", lsInCircle);
            bool IsInRec = ldPointX > ldLeftRec && ldPointX < ldLeftRec + ldWidth && ldPointY > ldTopRec && ldPointY < ldTopRec + ldHeightRec;
           // Console.WriteLine("Is point in a rec : {0}", IsInRec);
            Console.WriteLine("inside K & outside of R : {0}", lsInCircle && IsInRec?"yes":"no");
        }
    }
}