using System;

class DecimalToHexadecimalNumber
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
                switch (iN % 16)
                {
                    case 10:
                    {
                        sBinNum += "A";
                        break;
                    }
                    case 11:
                    {
                        sBinNum += "B";
                        break;
                    }
                    case 12:
                    {
                        sBinNum += "C";
                        break;
                    }
                    case 13:
                    {
                        sBinNum += "D";
                        break;
                    }
                    case 14:
                    {
                        sBinNum += "E";
                        break;
                    }
                    case 15:
                    {
                        sBinNum += "F";
                        break;
                    }
                    default:
                    {
                        sBinNum += (iN % 16).ToString();
                        break;
                    }
                }
                dTmpNum = iN / 16;
                iN = iN / 16;
            } while (dTmpNum >= 1);
            Console.Write("Binary : ");
            for (int i = sBinNum.Length; i > 0; i--)
            {
                Console.Write("{0}", sBinNum[i - 1]);
            }
            Console.WriteLine();
        }
    }
}