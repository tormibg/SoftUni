using System;

class SpiralMatrix
{
    private static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            int iN;
            do
            {
                Console.Write(@"Enter positive integer number N (1 <= N <= 20). : ");
            } while (!int.TryParse(Console.ReadLine(), out iN) && iN <= 20 && iN >= 1);
            int[,] aiNum = new int[iN,iN];
            string sDir = "R";
            int iCol = -1, iMaxNum = iN*iN, iRow = 0, iMoreToLeft = 0;
            for (int i = 1; i <= iMaxNum; i++)
            {
                if (sDir == "R")
                {
                    iCol++;
                    aiNum[iRow, iCol] = i;
                    if (iCol == (iN - 1) - iRow && iRow <= iN / 2)
                    {
                        sDir = "D";
                    }
                }
                else if (sDir == "D")
                {
                    iRow++;
                    aiNum[iRow, iCol] = i;
                    if (iRow == iCol)
                    {
                        sDir = "L";
                    }
                }
                else if (sDir == "L")
                {
                    iCol--;
                    aiNum[iRow, iCol] = i;
                    if (iCol == iMoreToLeft)
                    {
                        sDir = "U";
                        iMoreToLeft++;
                    }
                }
                else if (sDir == "U")
                {
                    iRow--;
                    aiNum[iRow, iCol] = i;
                    if (iCol == iRow - 1)
                    {
                        sDir = "R";
                    }
                }
            }
            for (int i = 0; i < iN; i++)
            {
                for (int j = 0; j < iN; j++)
                {
                    Console.Write("{0,4}",aiNum[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}