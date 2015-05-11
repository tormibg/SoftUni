using System;

class BitExchangeAdvanced
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            uint uiNumber;
            Console.Write("Enter positive integer : ");
            if (!uint.TryParse(Console.ReadLine(), out uiNumber))
            {
                Console.WriteLine("out of range");
            }
            else
            {
                Console.Write("Enter number of position of first bit for change : ");
                int iFistPos = int.Parse(Console.ReadLine());
                Console.Write("Enter number of position of second bit for change : ");
                int iSecPos = int.Parse(Console.ReadLine());
                Console.Write("Enter number bits for change : ");
                int iNumBits = int.Parse(Console.ReadLine());
                if (iFistPos > iSecPos)
                {
                    int iTmpPos = iFistPos;
                    iFistPos = iSecPos;
                    iSecPos = iTmpPos;
                }

                if ((iFistPos + iNumBits > 31) || (iFistPos + iNumBits > 31) || iFistPos < 1 || iSecPos < 1 || iNumBits < 1)
                {
                    Console.WriteLine("out of range");
                }
                else if (iFistPos + iNumBits < iSecPos)
                {
                    Console.WriteLine("In binary  - {0}", Convert.ToString(uiNumber, 2).PadLeft(32, '0'));
                    for (int i = iFistPos, k = iSecPos; i < (iFistPos + iNumBits); i++, k++)
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
                    Console.WriteLine("New integer : {0}", uiNumber);
                }
                else
                {
                    Console.WriteLine("overlapping");
                }
            }
        }
    }
}