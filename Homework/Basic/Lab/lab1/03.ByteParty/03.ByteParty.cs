using System;
using System.Collections.Generic;

class ByteParty
{
    private static void Main()
    {
        int iCount = 0;
        int iHowManyNum = 0;
        List<int> lIntNum = new List<int>();
        string sCommand = Console.ReadLine();
        while (sCommand != "party over")
        {
            if (iCount == 0)
            {
                iHowManyNum = int.Parse(sCommand);
                iCount++;
            }
            else
            {
                if (iHowManyNum > 0)
                {
                    string[] sTmpInpStr = sCommand.Split();
                    if (sTmpInpStr.Length == 1)
                    {
                        lIntNum.Add(int.Parse(sTmpInpStr[0]));
                    }
                    else
                    {
                        if (sTmpInpStr[0] == "-1")
                        {
                            for (int i = 0; i < lIntNum.Count; i++)
                            {
                                int iMask = 1 << int.Parse(sTmpInpStr[1]);
                                int iBit = (lIntNum[i] & iMask) != 0 ? 1 : 0;

                                if (iBit == 0)
                                {
                                    lIntNum[i] = lIntNum[i] | iMask;
                                }
                                else
                                {
                                    iMask = ~(1 << int.Parse(sTmpInpStr[1]));
                                    lIntNum[i] = lIntNum[i] & iMask;
                                }
                            }
                        }
                        else if (sTmpInpStr[0] == "0")
                        {
                            for (int i = 0; i < lIntNum.Count; i++)
                            {
                                int iMask = 1 << int.Parse(sTmpInpStr[1]);
                                int iBit = (lIntNum[i] & iMask) != 0 ? 1 : 0;
                                iMask = ~(1 << int.Parse(sTmpInpStr[1]));
                                lIntNum[i] = lIntNum[i] & iMask;
                            }

                        }
                        else if (sTmpInpStr[0] == "1")
                        {
                            for (int i = 0; i < lIntNum.Count; i++)
                            {
                                int iMask = 1 << int.Parse(sTmpInpStr[1]);
                                int iBit = (lIntNum[i] & iMask) != 0 ? 1 : 0;
                                lIntNum[i] = lIntNum[i] | iMask;
                            }
                        }
                    }
                    
                }
            }
             sCommand = Console.ReadLine();
        }
        foreach (int iNum in lIntNum)
        {
            Console.WriteLine(iNum);
        }
    }
}