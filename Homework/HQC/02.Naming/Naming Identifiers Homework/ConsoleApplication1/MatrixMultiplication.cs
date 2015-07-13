// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatrixMultiplication.cs" company="forHome">
//   just for home :)
// </copyright>
// <summary>
//   Documentation for constructor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MatrixMultiplication
{
    using System;

    /// <summary>
    /// TODO Documentation for class.
    /// </summary>
    public class MatrixMultiplication
    {
        /// <summary>
        /// TODO Documentation for main class.
        /// </summary>
        public static void Main()
        {
            var firstMatrix = new double[,] { { 1, 3 }, { 5, 7 } };
            var secondMatrix = new double[,] { { 4, 2 }, { 1, 5 } };
            var resultMatrix = MatrixMultiplicationMethod(firstMatrix, secondMatrix);

            for (int row = 0; row < resultMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < resultMatrix.GetLength(1); col++)
                {
                    Console.Write(resultMatrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Return result of two matrix multiplication
        /// </summary>
        /// <param name="firstMatrix">
        /// The first Matrix.
        /// </param>
        /// <param name="secondMatrix">
        /// The second Matrix.
        /// </param>
        /// <returns>
        /// The <see cref="double[,]"/>.
        /// </returns>
        public static double[,] MatrixMultiplicationMethod(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new Exception("Error!");
            }

            var firstMatrixLength = firstMatrix.GetLength(1);

            var resultMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];

            for (int row = 0; row < resultMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < resultMatrix.GetLength(1); col++)
                {
                    for (int i = 0; i < firstMatrixLength; i++)
                    {
                        resultMatrix[row, col] += firstMatrix[row, i] * secondMatrix[i, col];
                    }
                }
            }
            
            return resultMatrix;
        }
    }
}