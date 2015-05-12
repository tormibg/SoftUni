using System;

internal class FillTheMatrix
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        MatrixPatternA(size);

        Console.WriteLine();

        MatrixPatternB(size);
    }

    static void MatrixPatternA(int n)
    {
        int counter = 1;
        int[,] matAInts = new int[n, n];
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                matAInts[row, col] = counter;
                counter++;
            }
        }
        PrintMatrix(matAInts);
    }
    static void MatrixPatternB(int n)
    {
        int[,] matBInts = new int[n, n];
        int counter = 1;
        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    matBInts[row, col] = counter;
                    counter++;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    matBInts[row, col] = counter;
                    counter++;
                }
            }
        }
        PrintMatrix(matBInts);
    }
    static void PrintMatrix(int[,] mat)
    {
        for (int i = 0; i < mat.GetLength(0); i++)
        {
            for (int j = 0; j < mat.GetLength(1); j++)
            {
                Console.Write("{0,3}", mat[i, j]);
            }
            Console.WriteLine();
        }
    }
}