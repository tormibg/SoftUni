using System;

class MatrixShuffling
{
    static void Main()
    {
        int iRow = int.Parse(Console.ReadLine());
        int iCol = int.Parse(Console.ReadLine());
        string[,] matrix = new string[iRow, iCol];

        for (int i = 0; i < iRow; i++)
        {
            for (int j = 0; j < iCol; j++)
            {
                matrix[i, j] = Console.ReadLine();
            }
        }

        string input = Console.ReadLine();
        while (input != "END")
        {
            string[] commands = input.Split();
            if (commands.Length == 5 || commands[0] == "swap")
            {
                int x1 = int.Parse(input.Split()[1]);
                int y1 = int.Parse(input.Split()[2]);
                int x2 = int.Parse(input.Split()[3]);
                int y2 = int.Parse(input.Split()[4]);

                if (IfCordOK(x1, x2, iRow, y1, y2, iCol))
                {
                    string str = matrix[x1, y1];
                    matrix[x1, y1] = matrix[x2, y2];
                    matrix[x2, y2] = str;

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.Write("{0} ", matrix[i, j]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine();
            }

            input = Console.ReadLine();
        }

    }

    private static bool IfCordOK(int x1, int x2, int iRow, int y1, int y2, int iCol)
    {
        bool ifX1 = x1 >= 0 && x1 < iRow;
        bool ifX2 = x2 >= 0 && x2 < iRow;
        bool ifY1 = y1 >= 0 && y1 < iCol;
        bool ifY2 = y2 >= 0 && y1 < iCol;

        return ifX1 && ifX2 && ifY1 && ifY2;
    }

}