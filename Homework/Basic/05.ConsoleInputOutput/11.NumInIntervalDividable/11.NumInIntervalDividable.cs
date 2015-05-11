using System;

class NumInIntervalDividable
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            uint uFirstNum = 0, uSecNum = 0;
            string sFirstNum, sSecNum, sNumbers = "";
            int iCount = 0;
            Console.Write("Enter first positive integer number : ");
            sFirstNum = Console.ReadLine();
            Console.Write("Enter second positive integer number : ");
            sSecNum = Console.ReadLine();
            if (uint.TryParse(sFirstNum, out uFirstNum) && uint.TryParse(sSecNum, out uSecNum))
            {
                for (uint i = uFirstNum; i <= uSecNum; i++)
                {
                    if ((i % 5) == 0)
                    {
                        iCount++;
                        sNumbers = sNumbers + i.ToString() + " ";
                    }
                }
            Console.WriteLine("There are {0} and they are {1}",iCount,(iCount==0?"-":sNumbers));
            }
            else
            {
                Console.WriteLine("Only positive integer numbers !");
            }
        }
    }
}