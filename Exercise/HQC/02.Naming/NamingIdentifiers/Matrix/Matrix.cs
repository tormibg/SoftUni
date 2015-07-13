using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

internal class Matrix
{
    internal static void Main()
    {
        string inputLline = Console.ReadLine();
        int[] matD =
            inputLline.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s))
                .ToArray();
        string word = Console.ReadLine().Trim();
        inputLline = Console.ReadLine();
        int[] cord = inputLline.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
        string[,] matrix = new string[matD[0], matD[1]];
        int index = 0;
        for (int row = matrix.GetLength(0) - 1, x = 1; row >= 0; row--, x++)
        {
            if (x % 2 == 1)
            {
                for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                {
                    matrix[row, col] = word[index].ToString();
                    if (index != word.Length - 1)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
            }
            else
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = word[index].ToString();
                    if (index != word.Length - 1)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
            }
        }

        ShotMatrix(matrix, cord);
    }

    private static void ShotMatrix(string[,] matrix, int[] cord)
    {
        if (cord[0] < matrix.GetLength(0) && cord[1] < matrix.GetLength(1))
        {
            HashSet<KeyValuePair<int, int>> pointSet = new HashSet<KeyValuePair<int, int>>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (CheckPoint(cord[0], cord[1], cord[2], row, col))
                    {
                        pointSet.Add(new KeyValuePair<int, int>(row, col));
                    }
                }
            }

            string[,] matShot = new string[matrix.GetLength(0), matrix.GetLength(1)];
            for (int row = 0; row < matShot.GetLength(0); row++)
            {
                for (int col = 0; col < matShot.GetLength(1); col++)
                {
                    if (!pointSet.Contains(new KeyValuePair<int, int>(row, col)))
                    {
                        matShot[row, col] = matrix[row, col];
                    }
                    else
                    {
                        matShot[row, col] = " ";
                    }
                }
            }

            // PrintMatrix(matShot);
            for (int col = 0; col < matShot.GetLength(1); col++)
            {
                MatrixGravity(matShot, col);
            }

            PrintMatrix(matShot);

            // Console.WriteLine();
            // PrintMatrix(matShot);
        }
    }

    private static void MatrixGravity(string[,] matShot, int col)
    {
        while (true)
        {
            bool isGrav = false;
            for (int row = 1; row < matShot.GetLength(0); row++)
            {
                if (matShot[row, col] == " " && matShot[row - 1, col] != " ")
                {
                    matShot[row, col] = matShot[row - 1, col];
                    matShot[row - 1, col] = " ";
                    isGrav = true;
                }
            }

            if (!isGrav)
            {
                return;
            }
        }
    }

    private static bool CheckPoint(int centerX, int centerY, int radious, int coordinateX, int coordinateY)
    {
        radious = radious * radious;

        float pointsCoordinates =
            (float)(((coordinateX - centerX) * (coordinateX - centerX)) + ((coordinateY - centerY) * (coordinateY - centerY)));

        bool inCircle = radious - pointsCoordinates >= 0;

        if (inCircle)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static void PrintMatrix(string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j]);
            }

            Console.WriteLine();
        }
    }
}