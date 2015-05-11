using System;
using System.Collections.Generic;

class CrossingSequences
{
    static void Main()
    {
        const int MAX = 1000000;
        int tri1 = int.Parse(Console.ReadLine());
        int tri2 = int.Parse(Console.ReadLine());
        int tri3 = int.Parse(Console.ReadLine());
        
        bool[] aIsTrib = new bool[MAX+1];

        aIsTrib[tri1] = true;
        aIsTrib[tri2] = true;
        aIsTrib[tri3] = true;

        int triNext = 0 ;
        while (true)
        {
            triNext = tri1 + tri2 + tri3;
            if (triNext <= MAX)
            {
                aIsTrib[triNext] = true;   
            }
            else
            {
                break;
            }
            tri1 = tri2;
            tri2 = tri3;
            tri3 = triNext;
        } 

        long iRound = long.Parse(Console.ReadLine());
        long iStep = long.Parse(Console.ReadLine());
        bool[] aIsRounds = new bool[MAX+1];
        long iSide = 0;
        bool isCorner = true;
        while (iRound <= MAX)
        {
            aIsRounds[iRound] = true;
            if (isCorner)
            {
                iSide += 1;
            }
            iRound = iRound + (iSide*iStep);
            isCorner = !isCorner;
        }
        bool isNoNum = true;
        for (int i = 0; i <= MAX; i++)
        {
            if (aIsTrib[i] && aIsRounds[i])
            {
                Console.WriteLine("{0}",i);
                isNoNum = false;
                break;
            }
        }
        if (isNoNum)
        {
            Console.WriteLine("No");
        }
    }
}