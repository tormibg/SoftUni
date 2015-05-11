using System;

class BitsExchange
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            uint uiNumber;
            Console.Write("Enter positive integer : ");
            uiNumber = uint.Parse(Console.ReadLine());
            Console.WriteLine("In binary  - {0}", Convert.ToString(uiNumber, 2).PadLeft(32, '0'));
            for (int i = 3, k = 24; i < 6; i++, k++)
            {
                uint uiMask1 = 1u << i; 
                uint uiMask2 = 1u << k;
                uint uiFirstBitValue = uiNumber >> i; 
                uiFirstBitValue = uiFirstBitValue & 1; // get value of the first bit
                uint uiSecBitValue = uiNumber >> k;
                uiSecBitValue = uiSecBitValue & 1; //get value of the second bit 
                if (uiFirstBitValue == 0)
                {
                    uiNumber = uiNumber & ~uiMask2;
                }
                else
                {
                    uiNumber = uiNumber | uiMask2;
                }
                if (uiSecBitValue == 0)
                {
                    uiNumber = uiNumber & ~uiMask1;
                }
                else
                {
                    uiNumber = uiNumber | uiMask1;
                }
            }
            Console.WriteLine("New binary - {0}", Convert.ToString(uiNumber, 2).PadLeft(32, '0'));
            Console.WriteLine("New integer : {0}",uiNumber);
        }
    }
}