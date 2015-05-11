using System;

class FourDigitNumber
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            string lsNumber, lsTmpNum;
            int liSumNum = 0;
            Console.Write("Enter a four-digit number : ");
            lsNumber = Console.ReadLine();
            for (int i = 0; i < lsNumber.Length; i++)
            {
                liSumNum += int.Parse(lsNumber.Substring(i, 1));
            }
            Console.WriteLine("Sum of digits : {0}", liSumNum);
            lsTmpNum = lsNumber;
            lsNumber = "";
            if (lsTmpNum[3] != '0')
            {
                for (int i = lsTmpNum.Length - 1; i > -1; i--)
                {
                    lsNumber += lsTmpNum[i];
                }
                Console.WriteLine("Reversed : {0}", lsNumber);
                lsNumber = lsTmpNum[3].ToString() + lsTmpNum[0].ToString() + lsTmpNum[1].ToString() + lsTmpNum[2].ToString();
                Console.WriteLine("Last digit in front : {0}", lsNumber);
            }
            else
            {
                Console.WriteLine("Last digit == 0 and dont move it to front ");
            }
            lsNumber = lsTmpNum[0].ToString() + lsTmpNum[2].ToString() + lsTmpNum[1].ToString() + lsTmpNum[3].ToString();
            Console.WriteLine("Second and third digits exchanged : {0}", lsNumber);
        }
    }
}