using System;

class HexadecimalToDecimalNumber
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            string sN;
            Console.Write("Enter a HEX number : ");
            sN = Console.ReadLine();
            long iDecimal = 0L;
            for (int i = sN.Length; i > 0; i--)
            {
                int iTmpNum = 0;
                switch (sN[i-1])
                {
                    case 'A':
                    {
                        iTmpNum = 10;
                        break;   
                    }
                    case 'B':
                    {
                        iTmpNum = 11;
                        break;   
                    }
                    case 'C':
                    {
                        iTmpNum = 12;
                        break;   
                    }
                    case 'D':
                    {
                        iTmpNum = 13;
                        break;   
                    }
                    case 'E':
                    {
                        iTmpNum = 14;
                        break;   
                    }
                    case 'F':
                    {
                        iTmpNum = 15;
                        break;   
                    }
                    default:
                    {
                        iTmpNum = int.Parse(sN[i - 1].ToString());
                        break;   
                    }
                }
                iDecimal = iDecimal + iTmpNum*(long)Math.Pow(16, sN.Length - i);
            }
            Console.WriteLine("Decimal : {0}", iDecimal);
        }
    }
}