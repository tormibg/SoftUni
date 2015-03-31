using System;

class GameOfBits
{
    static void Main()
    {
        uint num = uint.Parse(Console.ReadLine());
        uint newNum = 0;
        uint nextNum = num;
        string bitComm = Console.ReadLine();
        if (bitComm == "Game Over!")
        {
            newNum = num;
        }
        else
        {
            while (bitComm != "Game Over!")
            {
                int resMod = 0;
                if (bitComm == "Odd")
                {
                    resMod = 1;
                }
                newNum = getNewNum(resMod, nextNum);
                nextNum = newNum;
                //      Console.WriteLine("{0}",Convert.ToString(newNum,2));
                bitComm = Console.ReadLine();
            }
        }
        int numBitsOne = 0;
        string NumStr = Convert.ToString(newNum, 2);
        for (int i = 0; i < NumStr.Length; i++)
        {
            if (NumStr[i] == '1')
            {
                numBitsOne++;
            }
        }
        Console.WriteLine("{0} -> {1}",newNum,numBitsOne);
    }

    private static uint getNewNum(int resMod, uint num)
    {
        uint newNum = 0;
        int numBits = 31;
        //Console.WriteLine("{0}", Convert.ToString(num, 2));
        while (numBits >= 0)
        {
            if (((numBits + 1) % 2 == resMod))
            {
                var tmpBit = (num >> numBits) & 1;
                newNum = newNum << 1;
                newNum = newNum | tmpBit;
            }

            //  Console.WriteLine(tmpBit);
            numBits--;
        }
        return newNum;
    }
}
