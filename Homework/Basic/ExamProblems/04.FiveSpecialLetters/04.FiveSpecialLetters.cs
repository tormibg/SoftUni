using System;
using System.Diagnostics.PerformanceData;

class FiveSpecialLetters
{
    static void Main()
    {
        int iStart = int.Parse(Console.ReadLine());
        int iEnd = int.Parse(Console.ReadLine());
        int iCount = 0;
        char[] aChars = { 'a', 'b', 'c', 'd', 'e' };
        for (int ch1 = 0; ch1 < 5; ch1++)
        {
            for (int ch2 = 0; ch2 < 5; ch2++)
            {
                for (int ch3 = 0; ch3 < 5; ch3++)
                {
                    for (int ch4 = 0; ch4 < 5; ch4++)
                    {
                        for (int ch5 = 0; ch5 < 5; ch5++)
                        {
                            string strTmp = "" + aChars[ch1] + aChars[ch2] + aChars[ch3] + aChars[ch4] + aChars[ch5];
                            string strNotRep = GetNotRepeating(strTmp);
                            int iSum = GetWeight(strNotRep);
                            if (iSum >= iStart && iSum <= iEnd)
                            {
                                Console.Write("{0} ",strTmp);
                                iCount++;
                            }
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

    private static int GetWeight(string strNotRep)
    {
        int iSum = 0;
        for (int i = 0; i < strNotRep.Length; i++)
        {
            switch (strNotRep[i])
            {
                case 'a':
                {
                    iSum += (i + 1) * 5;
                    break;
                }
                case 'b':
                {
                    iSum += (i + 1) * (-12);
                    break;
                }
                case 'c':
                {
                    iSum += (i + 1) * 47;
                    break;
                }
                case 'd':
                {
                    iSum += (i + 1) * 7;
                    break;
                }
                case 'e':
                {
                    iSum += (i + 1) * (-32);
                    break;
                }
            }
        }
        return iSum;
    }

    private static string GetNotRepeating(string strTmp)
    {
        string strFinal = "";
        for (int i = 0; i < strTmp.Length; i++)
        {
            bool isNotRep = true;
            for (int j = 0; j < strFinal.Length; j++)
            {
                if (strTmp[i] == strFinal[j])
                {
                    isNotRep = false;
                    break;
                }
            }
            if (isNotRep)
            {
                strFinal = strFinal + strTmp[i];
            }
        }
        return strFinal;
    }
}