using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

internal class ClearingCommands
{
    private static void Main()
    {
        List<StringBuilder> matrix = new List<StringBuilder>();
        string inputLine = Console.ReadLine();
        while (inputLine != "END")
        {
            matrix.Add(new StringBuilder(inputLine));
            inputLine = Console.ReadLine();
        }
        for (int row = 0; row < matrix.Count(); row++)
        {
            for (int col = 0; col < matrix[row].ToString().Count(); col++)
            {
                if (matrix[row][col] == '<')
                {
                    ToLeft(matrix, row, col);
                }
                else if (matrix[row][col] == '>')
                {
                    ToRight(matrix, row, col);
                }
                else if (matrix[row][col] == 'v')
                {
                    ToDown(matrix, row, col);
                }
                else if (matrix[row][col] == '^')
                {
                    ToUp(matrix, row, col);
                }
            }
        }
        for (int row = 0; row < matrix.Count(); row++)
        {
            Console.Write("<p>");
            for (int col = 0; col < matrix[row].ToString().Count(); col++)
            {
                Console.Write(SecurityElement.Escape(matrix[row][col].ToString()));
            }
            Console.Write("</p>");
            Console.WriteLine();
        }
    }

    private static void ToUp(List<StringBuilder> matrix, int row, int col)
    {
        for (int rowa = row - 1; rowa >= 0; rowa--)
        {
            if (matrix[rowa][col] != '<' && matrix[rowa][col] != '>' && matrix[rowa][col] != 'v' &&
                matrix[rowa][col] != '^')
            {
                matrix[rowa].Remove(col, 1);
                matrix[rowa].Insert(col, " ");
            }
            else
            {
                return;
            }
        }
    }

    private static void ToDown(List<StringBuilder> matrix, int row, int col)
    {
        for (int rowa = row + 1; rowa < matrix.Count(); rowa++)
        {
            if (matrix[rowa][col] != '<' && matrix[rowa][col] != '>' && matrix[rowa][col] != 'v' &&
                matrix[rowa][col] != '^')
            {
                matrix[rowa].Remove(col, 1);
                matrix[rowa].Insert(col, " ");
            }
            else
            {
                return;
            }
        }
    }

    private static void ToRight(List<StringBuilder> matrix, int row, int col)
    {
        for (int cola = col + 1; cola < matrix[row].ToString().Count(); cola++)
        {
            if (matrix[row][cola] != '<' && matrix[row][cola] != '>' && matrix[row][cola] != 'v' &&
                matrix[row][cola] != '^')
            {
                matrix[row].Remove(cola, 1);
                matrix[row].Insert(cola, " ");
            }
            else
            {
                return;
            }
        }
    }

    private static void ToLeft(List<StringBuilder> matrix, int row, int col)
    {
        for (int cola = col-1; cola >= 0; cola--)
        {
            if (matrix[row][cola] != '<' && matrix[row][cola] != '>' && matrix[row][cola] != 'v' &&
                matrix[row][cola] != '^')
            {
                matrix[row].Remove(cola, 1);
                matrix[row].Insert(cola, " ");
            }
            else
            {
                return;
            }
        }
    }
}