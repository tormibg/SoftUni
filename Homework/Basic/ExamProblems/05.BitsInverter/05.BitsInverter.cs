using System;

class BitsInverter
{
    static void Main()
    {
        int iNum = int.Parse(Console.ReadLine());
        int iStep = int.Parse(Console.ReadLine());
        int[] aInts = new int[iNum];
        int iCount = 1;
        for (int i = 0; i < iNum; i++)
        {
            aInts[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < iNum; i++)
        {
            int tmpNum = aInts[i];
            for (int j = 7; j >= 0; j--) //bit
            {
                if ((iStep == 1) || (iCount % iStep == 1))
                {
                    int mask = 1 << j;
                    tmpNum = tmpNum ^ mask;
                }
                iCount++;
            }
            Console.WriteLine(tmpNum);
        }
    }
}