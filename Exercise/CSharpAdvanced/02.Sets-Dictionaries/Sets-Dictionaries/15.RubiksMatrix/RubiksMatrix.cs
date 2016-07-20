namespace _15.RubiksMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RubiksMatrix
    {
        public static void Main()
        {
            uint[] matrixSides = Console.ReadLine().Split().Select(uint.Parse).ToArray();
            uint rows = matrixSides[0];
            uint cols = matrixSides[1];

            uint[,] matrix = CreateMatrix(rows, cols);
            uint numberOfCmd = uint.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCmd; i++)
            {
                string[] commands = Console.ReadLine().Split();
                switch (commands[1])
                {
                    case "up":
                        MoveRow(matrix, int.Parse(commands[0]), int.Parse(commands[2]), -1);
                        break;
                    case "down":
                        MoveRow(matrix, int.Parse(commands[0]), int.Parse(commands[2]), +1);
                        break;
                    case "left":
                        MoveCol(matrix, int.Parse(commands[0]), int.Parse(commands[2]), -1);
                        break;
                    case "right":
                        MoveCol(matrix, int.Parse(commands[0]), int.Parse(commands[2]), +1);
                        break;
                }
            }
            SwapAction(matrix);
        }

        private static void SwapAction(uint[,] matrix)
        {
            int position = 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == position)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        int[] index = FindIndex(matrix, i, position);
                        if (index != null)
                        {
                            SwapValues(matrix, i, j, index[0], index[1]);
                            //Console.WriteLine();
                        }
                    }

                    position++;
                }
            }
        }

        private static void SwapValues(uint[,] matrix, int i, int j, int i2, int j2)
        {
            Console.WriteLine($"Swap ({i}, {j}) with ({i2}, {j2})");
            uint temp = matrix[i, j];
            matrix[i, j] = matrix[i2, j2];
            matrix[i2,j2] = temp;
        }

        private static int[] FindIndex(uint[,] matrix, int i, int position)
        {
            for (int j = i; j < matrix.GetLength(0); j++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[j, k] == position)
                    {
                        return new int[] { j, k };
                    }
                }
            }
            return null;
        }

        private static void MoveCol(uint[,] matrix, int row, int turns, int operation)
        {
            turns %= matrix.GetLength(1);

            int next;

            if (operation > 0)
            {
                next = turns;
                AscendingColSwap(matrix, row, next);
            }
            else
            {
                next = matrix.GetLength(1) - turns - 1;
                DescendingColSwap(matrix, row, next);
            }
        }

        private static void AscendingColSwap(uint[,] matrix, int row, int next)
        {
            Queue<uint> arangement = new Queue<uint>();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                arangement.Enqueue(matrix[row,i]);
            }

            int count = matrix.GetLength(1);

            while (count > 0)
            {
                if (!IsWithinRange(next, matrix.GetLength(1)))
                {
                    next = 0;
                }

                matrix[row,next] = arangement.Dequeue();
                count--;
                next += 1;
            }
        }

        private static void DescendingColSwap(uint[,] matrix, int row, int next)
        {
            Queue<uint> arangement = new Queue<uint>();
            for (int i = matrix.GetLength(1) - 1; i >= 0; i--)
            {
                arangement.Enqueue(matrix[row,i]);
            }

            int count = matrix.GetLength(1);

            while (count > 0)
            {
                if (!IsWithinRange(next, matrix.GetLength(1)))
                {
                    next = matrix.GetLength(1) - 1;
                }

                matrix[row,next] = arangement.Dequeue();
                count--;
                next -= 1;
            }
        }

        private static void MoveRow(uint[,] matrix, int col, int turns, int operation)
        {
            turns %= matrix.GetLength(0);
            if (turns == 0)
            {
                return;
            }
            int next;
            if (operation > 0)
            {
                next = turns;
                AscendingRowSwap(matrix, col, next);
            }
            else
            {
                next = matrix.GetLength(0) - turns - 1;
                DescendingRowSwap(matrix, col, next);
            }
        }

        private static void DescendingRowSwap(uint[,] matrix, int col, int next)
        {
            Queue<uint> arangement = new Queue<uint>();
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                arangement.Enqueue(matrix[i, col]);
            }

            int count = matrix.GetLength(0);

            while (count > 0)
            {
                if (!IsWithinRange(next, matrix.GetLength(0)))
                {
                    next = matrix.GetLength(0) - 1;
                }

                matrix[next, col] = arangement.Dequeue();
                count--;
                next -= 1;
            }
        }

        private static void AscendingRowSwap(uint[,] matrix, int col, int next)
        {
            Queue<uint> arangement = new Queue<uint>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                arangement.Enqueue(matrix[i, col]);
            }
            int count = matrix.GetLength(0);

            while (count > 0)
            {
                if (!IsWithinRange(next, matrix.GetLength(0)))
                {
                    next = 0;
                }
                matrix[next, col] = arangement.Dequeue();
                count--;
                next += 1;
            }
        }

        private static bool IsWithinRange(int next, int length)
        {
            return 0 <= next && next < length;
        }

        private static uint[,] CreateMatrix(uint rows, uint cols)
        {
            uint[,] matrix = new uint[rows, cols];
            uint tmpNum = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = tmpNum++;
                }
            }
            return matrix;
        }
    }
}
