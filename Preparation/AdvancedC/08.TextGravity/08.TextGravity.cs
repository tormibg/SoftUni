using System;
using System.Security;

class TextGravity
{
    static void Main()
    {
        int cols = int.Parse(Console.ReadLine());
        string strForMat = Console.ReadLine();
        int rows = strForMat.Length/cols;
        if (strForMat.Length % cols != 0)
        {
            rows++;
        }
        int strCount = 0;    
        string[,] matrixStrings = new string[rows,cols];
        for (int i = 0; i < matrixStrings.GetLength(0); i++)
        {
            for (int j = 0; j < matrixStrings.GetLength(1); j++)
            {
                if (strCount != strForMat.Length)
                {
                    //Console.Write(strForMat[strCount]);
                    matrixStrings[i, j] = strForMat[strCount].ToString();
                    strCount++;
                }
                else
                {
                    matrixStrings[i, j] = " ";
                }
            }
        }
        //for (int i = 0; i < matrixStrings.GetLength(0); i++)
        //{
        //    for (int j = 0; j < matrixStrings.GetLength(1); j++)
        //    {

        //        Console.Write(matrixStrings[i, j]);

        //    }
        //    Console.WriteLine();
        //}
        for (int i = 0; i < matrixStrings.GetLength(1); i++)
        {
            MatrixGravity(matrixStrings, i);
        }
        Console.Write("<table>");
        for (int i = 0; i < matrixStrings.GetLength(0); i++)
        {
            Console.Write("<tr>");
            for (int j = 0; j < matrixStrings.GetLength(1); j++)
            {
                
                    Console.Write("<td>{0}</td>",SecurityElement.Escape(matrixStrings[i,j]));
               
            }
            Console.Write("</tr>");
        }
        Console.Write("</table>");
    }

    private static void MatrixGravity(string[,] matrixStrings, int col)
    {
        while (true)
        {
            bool isGrav = false;
            for (int row = 1; row < matrixStrings.GetLength(0); row++)
            {
                if (matrixStrings[row, col] == " " && matrixStrings[row-1, col] != " ")
                {
                    matrixStrings[row, col] = matrixStrings[row - 1, col];
                    matrixStrings[row - 1, col] = " ";
                    isGrav = true;
                }
            }
            if (!isGrav)
            {
                return;
            }
        }
    }
}