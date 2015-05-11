using System;

class DecimalToBinaryNumber
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            long iN;
            Console.Write("Enter a integer number : ");
            iN = long.Parse(Console.ReadLine());
            double dTmpNum = 0;
            string sBinNum = "";
            do
            {
                if (iN % 2 == 0)
                {
                    sBinNum = sBinNum + "0";
                }
                else
                {
                    sBinNum = sBinNum + "1";
                }
                dTmpNum = iN / 2;
                iN = iN / 2;
            } while (dTmpNum >= 1);
            Console.Write("Binary : ");
            for (int i = sBinNum.Length; i > 0; i--)
            {
                Console.Write("{0}", sBinNum[i-1]);   
            }
            Console.WriteLine();
        }
    }
}