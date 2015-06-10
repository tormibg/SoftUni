using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

class StringMatrixRotation
{
    static void Main()
    {
        List<string> inputList = new List<string>();
        string pattern = @"(?<=\()\d+(?=\))";
        Regex rxRegex = new Regex(pattern);
        int degrees = (int.Parse(rxRegex.Match(Console.ReadLine()).Value));
        string inputStr = Console.ReadLine();
        while (inputStr != "END")
        {
            inputList.Add(inputStr);
            inputStr = Console.ReadLine();
        }
        int maxL = int.MinValue;
        for (int i = 0; i < inputList.Count; i++)
        {
            int tmpVal = inputList[i].Length;
            if (tmpVal > maxL)
            {
                maxL = tmpVal;
            }
        }

        string[,] matrix = new string[inputList.Count, maxL];
        for (int row = 0; row < inputList.Count; row++)
        {
            for (int col = 0; col < maxL; col++)
            {
                if (inputList[row].Length > col)
                {
                    matrix[row, col] = inputList[row][col].ToString();
                }
                else
                {
                    matrix[row, col] = " ";
                }
            }
        }

        degrees = degrees % 360;

        if (degrees == 90)
        {
            matrix = Rotate90(matrix);
        }
        else if (degrees == 180)
        {
            matrix = Rotate180(matrix);
        }
        else if (degrees == 270)
        {
            matrix = Rotate270(matrix);
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }

    }

    private static string[,] Rotate270(string[,] matrix)
    {
        string[,] newMat = new string[matrix.GetLength(1), matrix.GetLength(0)];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                newMat[newMat.GetLength(0) - 1 - col, row] = matrix[row, col];
            }
        }
        return newMat;
    }

    private static string[,] Rotate180(string[,] matrix)
    {
        string[,] newMat = new string[matrix.GetLength(0), matrix.GetLength(1)];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                newMat[newMat.GetLength(0) - 1 - row, newMat.GetLength(1) - 1 - col] = matrix[row, col];
            }
        }
        return newMat;
    }

    private static string[,] Rotate90(string[,] matrix)
    {
        string[,] newMat = new string[matrix.GetLength(1), matrix.GetLength(0)];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                newMat[col, newMat.GetLength(1) - 1 - row] = matrix[row, col];
            }
        }
        return newMat;
    }
}