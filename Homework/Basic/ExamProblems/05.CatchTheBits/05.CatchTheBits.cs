using System;

class CatchTheBits
    {
        static void Main()
        {
            int iNum = int.Parse(Console.ReadLine());
            int iStep = int.Parse(Console.ReadLine());
            int[] aInts = new int[iNum];
            string sCatchBit = "";
            int resultBits = 0;
            int countBits = 0;
            for (int i = 0; i < iNum; i++)
            {
                aInts[i] = int.Parse(Console.ReadLine());
            }
            int iCount = 0;
            for (int i = 0; i < iNum; i++)
            {
                int tmpNum = aInts[i];
                for (int bit = 7; bit >= 0; bit--)
                {
                    if ((iStep == 1 && iCount > 0) || (iCount % iStep == 1))
                    {
                        int newNum = tmpNum >> bit;
                        int iBit = 1 & newNum;
                        resultBits = resultBits << 1;
                        resultBits = resultBits | iBit;
                        countBits++;
                        if (countBits == 8)
                        {
                            Console.WriteLine(resultBits);
                            countBits = 0;
                            resultBits = 0;
                        }
                    }
                    iCount++;
                }
            }
            if (countBits > 0)
            {
                resultBits = resultBits << (8 - countBits);
                Console.WriteLine(resultBits);
            }
        }
    }