using System;

class HalfSum
{
    static void Main()
    {
        int iNum = 0;
        iNum = int.Parse(Console.ReadLine());
        int[] aNumInts = new int[iNum*2];
        int iSum1 = 0, iSum2 = 0;
        for (int i = 0; i < iNum*2; i++)
        {
            aNumInts[i] = int.Parse(Console.ReadLine());
            if (i < iNum)
            {
                iSum1 += aNumInts[i];
            }
            else
            {
                iSum2 += aNumInts[i];
            }
        }
        if (iSum1 == iSum2)
        {
            Console.WriteLine("Yes, sum={0}",iSum1);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(iSum1 - iSum2));
        }
    }
}