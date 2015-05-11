using System;

class MagicCarNumbers
{
    static void Main()
    {
        int numMagic = int.Parse(Console.ReadLine());
        int iCount = 0;
        char[] aChr = {'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X'};
        for (int d1 = 0; d1 <= 9; d1++)
        {
            for (int d2 = 0; d2 <= 9; d2++)
            {
                for (int d3 = 0; d3 <= 9; d3++)
                {
                    for (int d4 = 0; d4 <= 9; d4++)
                    {
                        if (CheckMagic(d1, d2, d3, d4))
                        {
                            for (int x = 0; x <= 9; x++)
                            {
                                for (int y = 0; y <= 9; y++)
                                {
                                    int magicWeight = GetMagicWeight(d1, d2, d3, d4, aChr[x], aChr[y]);
                                    if (magicWeight == numMagic)
                                    {
                                        iCount++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(iCount);
    }

    private static int GetMagicWeight(int d1, int d2, int d3, int d4, char p1, char p2)
    {
        int iSum = 0;
        int x = 0, y = 0;
        x = GetChar(p1);
        y = GetChar(p2);
        iSum = 10 + 30 + d1 + d2 + d3 + d4 + x + y;
        return iSum;
    }

    private static int GetChar(char p1)
    {
        int x = int.MinValue;
        switch (p1)
        {
            case 'A':
            {
                x = 10;
                break;
            }
            case 'B':
            {
                x = 20;
                break;
            }
            case 'C':
            {
                x = 30;
                break;
            }
            case 'E':
            {
                x = 50;
                break;
            }
            case 'H':
            {
                x = 80;
                break;
            }
            case 'K':
            {
                x = 110;
                break;
            }
            case 'M':
            {
                x = 130;
                break;
            }
            case 'P':
            {
                x = 160;
                break;
            }
            case 'T':
            {
                x = 200;
                break;
            }
            case 'X':
            {
                x = 240;
                break;
            }
        }
        return x;
    }

    private static bool CheckMagic(int d1, int d2, int d3, int d4)
    {
        bool result = false;
        if (d1 == d2 && d1 == d3 && d1 == d4) //CAaaaaXY"
        {
            result = true; 
        }
        else if (d2 == d3 && d2 == d4) //CAabbbXY
        {
            result = true;
        }
        else if (d1 == d2 && d1 == d3) //CAaaabXY
        {
            result = true;
        }
        else if (d1 == d2 && d3 == d4) //CAaabbXY
        {
            result = true;
        }
        else if (d1 == d3 && d2 == d4) //CAababXY
        {
            result = true;
        }
        else if (d1 == d4 && d2 == d3) //CAabbaXY
        {
            result = true;
        }
        return result;
    }
}