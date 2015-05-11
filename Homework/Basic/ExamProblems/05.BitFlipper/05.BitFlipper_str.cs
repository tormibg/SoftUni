using System;

class BitFlipper1
{
    static void Main1()
    {
        ulong num = ulong.Parse(Console.ReadLine());
        string strNum = Convert.ToString((long)num, 2).PadLeft(64, '0'); 
        string strNew = "";
        for (int i = 0; i < strNum.Length; i++)
        {
            if (i + 2 < strNum.Length)
            {
                if (strNum[i] == strNum[i + 1] && strNum[i] == strNum[i + 2])
                {
                    if (strNum[i] == '0')
                    {
                        strNew += "111";
                    }
                    else
                    {
                        strNew += "000";
                    }
                    i += 2;
                }
                else
                {
                    strNew += strNum[i];
                }
            }
            else
            {
                strNew += strNum[i];
            }
        }
    //    Console.WriteLine(strNum);
    //    Console.WriteLine(strNew);
        long newNum = Convert.ToInt64(strNew, 2);
    //    Console.WriteLine(long.MaxValue);
    //    Console.WriteLine(Math.Abs(newNum));
        ulong newNumm = (ulong) (long.MaxValue + Math.Abs(newNum));
   //     Console.WriteLine("{0}", newNumm);
        ulong uSum = 0;
        for (int i = 63, j=0; i >= 0; i--, j++)
        {
            uSum += (ulong)Math.Pow(2*(double.Parse(strNew[i].ToString())),j);
        }
        if (strNew[63] == '0')
        {
            Console.WriteLine(uSum-1);
        }
        else
        {
            Console.WriteLine(uSum);
        }
        
    }
}