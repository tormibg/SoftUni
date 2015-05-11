using System;

internal class FunWithMatrices
{
    private static void Main()
    {
        double[,] aInputsDoubles = new double[4, 4];
        string sCommand = Console.ReadLine();
        int iCount = 0;
        double dFirstInp = 0, dSecInp = 0;
        while (sCommand != "Game Over!")
        {
            iCount++;
            if (!(sCommand.Contains("multiply") || sCommand.Contains("sum") || sCommand.Contains("power")))
            {
                if (iCount == 1)
                {
                    dFirstInp = double.Parse(sCommand);
                }
                else if (iCount == 2)
                {
                    dSecInp = double.Parse(sCommand);
                    decimal iValue = decimal.Parse(sCommand);
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (i == 0 && j == 0)
                            {
                                aInputsDoubles[i, j] = dFirstInp;
                            }
                            else if (j == 0)
                            {
                                aInputsDoubles[i, j] = aInputsDoubles[i - 1, j + 3] + dSecInp;
                            }
                            else
                            {
                                aInputsDoubles[i, j] = aInputsDoubles[i, j - 1] + dSecInp;
                            }
                        }
                    }
                }
            }
            else if (sCommand.Contains("multiply"))
            {
                string[] aValStrings = sCommand.Split();
                int x = int.Parse(aValStrings[0]);
                int y = int.Parse(aValStrings[1]);
                aInputsDoubles[x, y] *= double.Parse(aValStrings[3]);
            }
            else if (sCommand.Contains("sum"))
            {
                string[] aValStrings = sCommand.Split();
                int x = int.Parse(aValStrings[0]);
                int y = int.Parse(aValStrings[1]);
                aInputsDoubles[x, y] += double.Parse(aValStrings[3]);
            }
            else if (sCommand.Contains("power"))
            {
                string[] aValStrings = sCommand.Split();
                int x = int.Parse(aValStrings[0]);
                int y = int.Parse(aValStrings[1]);
                aInputsDoubles[x, y] = Math.Pow(aInputsDoubles[x, y], double.Parse(aValStrings[3]));
            }
            sCommand = Console.ReadLine();
        }
        double dRowSum = double.MinValue, dColSum = double.MinValue;
        int iRow = 0, iCol = 0;
        for (int i = 0; i < 4; i++) //Row
        {
            double dTmpRowSum = 0, dTmpCowSum = 0;
            for (int j = 0; j < 4; j++) //Col
            {
                dTmpRowSum += aInputsDoubles[i, j];

                dTmpCowSum += aInputsDoubles[j, i];

            }
            if (dTmpRowSum > dRowSum)
            {
                dRowSum = dTmpRowSum;
                iRow = i;

            }
            if (dTmpCowSum > dColSum)
            {
                 dColSum = dTmpCowSum;
                 iCol = i;
            }
        }
        double dLedtD = aInputsDoubles[0, 0] + aInputsDoubles[1, 1] + aInputsDoubles[2, 2] + aInputsDoubles[3, 3];
        double dRightD = aInputsDoubles[0, 3] + aInputsDoubles[1, 2] + aInputsDoubles[2, 1] + aInputsDoubles[3, 0];
        double dFinalRes;
        string dFinalStr = "";
        if (dRowSum >= dColSum)
        {
            dFinalRes = dRowSum;
            dFinalStr = "ROW[" + iRow + "] = ";
        }
        else
        {
            dFinalRes = dColSum;
            dFinalStr = "COLUMN[" + iCol + "] = ";
        }
        if (dRightD > dFinalRes)
        {
            dFinalRes = dRightD;
            dFinalStr = "RIGHT-DIAGONAL = ";
        }
        else if (dLedtD > dFinalRes)
        {
            dFinalRes = dLedtD;
            dFinalStr = "LEFT-DIAGONAL = ";
        }
        Console.WriteLine("{0}{1:F}", dFinalStr, dFinalRes);
    }
}