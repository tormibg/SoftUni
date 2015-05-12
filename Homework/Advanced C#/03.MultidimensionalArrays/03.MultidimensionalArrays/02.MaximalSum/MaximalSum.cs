using System;
using System.Linq;

class MaximalSum
{
    static void Main()
    {
        string[] str = Console.ReadLine().Split();
        int iRow = int.Parse(str[0]);
        int iCol = int.Parse(str[1]);

        int newRows = 3;
        int newCols = 3;
        int[,] matrix = new int[iRow + 1, iCol + 1];

        for (int i = 0; i < iRow; i++)
        {
            int[] numbers =
                Console.ReadLine()
                    .Trim()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => int.Parse(s))
                    .ToArray();
            for (int l = 0; l < iCol; l++)
            {
                matrix[i, l] = numbers[l];
            }
        }

        int maxSum = 0;
        int startRow = 0;
        int startCol = 0;
        for (int row = 0; row < matrix.GetLength(0) - (newRows - 1); row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - (newCols - 1); col++)
            {
                int sum = 0;
                for (int tempRow = row; tempRow < row + newRows; tempRow++)
                {
                    for (int tempCol = col; tempCol < col + newCols; tempCol++)
                    {
                        sum += matrix[tempRow, tempCol];
                    }
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                    startRow = row;
                    startCol = col;
                }
            }
        }

        Console.WriteLine("Sum = {0}", maxSum);

        for (int row = startRow; row < startRow + newRows; row++)
        {
            for (int col = startCol; col < startCol + newCols; col++)
            {
                Console.Write("{0,-4}", matrix[row, col]);
            }
            Console.WriteLine();
        }
        
    }
}