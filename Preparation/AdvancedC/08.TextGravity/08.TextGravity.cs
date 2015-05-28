using System;

class TextGravity
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        string strForMat = Console.ReadLine();
        int cols = strForMat.Length/rows;
        if (strForMat.Length % rows == 1)
        {
            cols++;
        }
    }
}