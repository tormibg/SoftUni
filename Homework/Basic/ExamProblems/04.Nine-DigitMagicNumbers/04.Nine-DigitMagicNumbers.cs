using System;

class NineDigitMagicNumbers
{
    static void Main()
    {
        int iSum = 0, iDiff = 0, iCount = 0;
        iSum = int.Parse(Console.ReadLine());
        iDiff = int.Parse(Console.ReadLine());
        int iGHI = 111;
        for (int i1 = 1; i1 < 8; i1++)
        {
            for (int j1 = 1; j1 < 8; j1++)
            {
                for (int k1 = 1; k1 < 8; k1++)
                {
                    iGHI = int.Parse(Convert.ToString(i1) + Convert.ToString(j1) + Convert.ToString(k1));
                    int iRetNum = CheckNum(i1, j1, k1, iDiff);
                    if (iRetNum != 0)
                    {
                        string sTmpStr = Convert.ToString(iRetNum);
                        int iTmpSum = 0;
                        for (int i = 0; i < sTmpStr.Length; i++)
                        {
                            iTmpSum += int.Parse(Convert.ToString(sTmpStr[i]));
                        }
                        iTmpSum = iTmpSum + i1 + j1 + k1;
                        if (iTmpSum == iSum)
                        {
                            Console.WriteLine("{0}{1}", iRetNum, iGHI);
                            iCount++;
                        }
                    }
                }
            }
        }
        if (iCount == 0)
        {
            Console.WriteLine("No");
        }
    }

    private static int CheckNum(int i1, int j1, int k1, int diff)
    {
        int iNumForReturn = 0;
        for (int i2 = 1; i2 <= i1; i2++)
        {
            for (int j2 = 1; j2 <= 7; j2++)
            {
                for (int k2 = 1; k2 <= 7; k2++)
                {
                    int tmpNum1 = int.Parse(Convert.ToString(i1) + Convert.ToString(j1) + Convert.ToString(k1));
                    int tmpNum2 = int.Parse(Convert.ToString(i2) + Convert.ToString(j2) + Convert.ToString(k2));
                    if (tmpNum1 > tmpNum2)
                    {
                        if (tmpNum1 - tmpNum2 == diff )
                        {
                            int iRetNum = CheckNumOne(i2, j2, k2, diff);
                            if (iRetNum != 0)
                            {
                                iNumForReturn = int.Parse(Convert.ToString(iRetNum) + Convert.ToString(tmpNum2));
                                break;
                            }
                        }
                    }
                }
            }
        }
        return iNumForReturn;
    }

    private static int CheckNumOne(int i2, int j2, int k2, int diff)
    {
        int iNumForReturn = 0;
        for (int i3 = 1; i3 <= i2; i3++)
        {
            for (int j3 = 1; j3 <= 7 ; j3++)
            {
                for (int k3 = 1; k3 <= 7; k3++)
                {
                    int tmpNum1 = int.Parse(Convert.ToString(i2) + Convert.ToString(j2) + Convert.ToString(k2));
                    int tmpNum2 = int.Parse(Convert.ToString(i3) + Convert.ToString(j3) + Convert.ToString(k3));
                    if (tmpNum1 > tmpNum2)
                    {
                        if (tmpNum1 - tmpNum2 == diff)
                        {
                            iNumForReturn = tmpNum2;
                            break;
                        }
                    }
                }
            }
        }
        return iNumForReturn;
    }
}