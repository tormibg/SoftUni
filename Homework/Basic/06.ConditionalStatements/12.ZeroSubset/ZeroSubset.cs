using System;
using System.Collections.Generic;

class ZeroSubset
{
    static void Main()
    {
        while (true)
        {
            const byte lcbNumLen = 5;
            int liSumZero = 0;
            byte lbZSubset = 0;
            int[] laNumArr = new int[lcbNumLen];
            for (int i = 0; i < lcbNumLen; i++)
            {
                Console.Write("Enter {0}-st int number : ", i + 1);
                laNumArr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(new string('-', 40));
            if (laNumArr[0] == 0 && laNumArr[1] == 0 && laNumArr[2] == 0 && laNumArr[3] == 0 && laNumArr[4] == 0)
            {
                Console.WriteLine("0 + 0 + 0 + 0 + 0 = 0");
                lbZSubset = 1;
            }
            else
            {
                int lvMaxNum = (int) Math.Pow(2, lcbNumLen);
                for (int j = 1; j < lvMaxNum; j++)
                {
                    List<int> lNumList = new List<int>();
                    string lsBinStr = Convert.ToString(j, 2).PadLeft(lcbNumLen, '0');
                    liSumZero = 0;
                    for (int i = 0; i < lcbNumLen; i++)
                    {
                        if (lsBinStr[i] == '1')
                        {
                            liSumZero += laNumArr[i];
                            lNumList.Add(laNumArr[i]);
                        }
                    }
                    if (liSumZero == 0)
                    {
                        if (lNumList.Count > 0)
                        {
                            lbZSubset++;
                            for (int i = 0; i < lNumList.Count - 1; i++)
                            {
                                Console.Write("{0} + ", lNumList[i]);
                            }
                            Console.WriteLine("{0} = 0", lNumList[lNumList.Count - 1]);
                        }
                        else
                        {
                            Console.WriteLine("{0} = 0", lNumList[0]);
                        }
                    }
                }
            }
            if (lbZSubset == 0)
            {
                Console.WriteLine("no zero subset");
            }
        }
    }
}
