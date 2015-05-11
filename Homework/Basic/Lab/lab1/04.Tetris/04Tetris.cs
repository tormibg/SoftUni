using System;
using System.Collections.Generic;
using System.Linq;

class Tetris
{
    static void Main()
    {
        int iI = 0, iL = 0, iJ = 0, iO = 0, iZ = 0;
        int[] aSizeGame = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
        List<string> lStrinList = new List<string>();
        for (int i = 0; i < aSizeGame[0]; i++)
        {
            lStrinList.Add(Console.ReadLine());
        }
        for (int row = 0; row < aSizeGame[0]; row++)
        {
            for (int col = 0; col < aSizeGame[1]; col++)
            {
                if (lStrinList[row][col] == 'o' && ((row + 3) < aSizeGame[0])) // I
                {
                    if (lStrinList[row + 1][col] == 'o')
                    {
                        if (lStrinList[row + 2][col] == 'o')
                        {
                            if (lStrinList[row + 3][col] == 'o') 
                            {
                                iI++;
                            }

                        }
                    }
                }
                if (lStrinList[row][col] == 'o' && ((row + 2) < aSizeGame[0])) //L, J
                {
                    if (lStrinList[row + 1][col] == 'o')
                    {
                        if (lStrinList[row + 2][col] == 'o')
                        {
                            if ((col + 1 < aSizeGame[1]) && lStrinList[row + 2][col + 1] == 'o') //L
                            {
                                iL++;
                            }
                            if ((col - 1 > 0) && lStrinList[row + 2][col - 1] == 'o') //J
                            {
                                iJ++;
                            }
                        }
                    }
                }
                if (lStrinList[row][col] == 'o' && ((row + 1) < aSizeGame[0])) //O
                {
                    if (lStrinList[row + 1][col] == 'o')
                    {  
                        if ((col + 1 < aSizeGame[1]) && lStrinList[row + 1][col + 1] == 'o') //O
                        {
                            if ( lStrinList[row][col + 1] == 'o')
                            {
                                iO++; // O
                            }
                        }
                        if ((col - 1 > 0) && lStrinList[row][col - 1] == 'o') //Z
                        {
                            if ((col + 1 < aSizeGame[1]) && lStrinList[row + 1][col + 1] == 'o') //Z
                            {
                                iZ++;
                            }
                        }
                        if ((col - 1 > 0) && lStrinList[row+1][col - 1] == 'o') //Z
                        {
                            if ((col + 1 < aSizeGame[1]) && lStrinList[row + 1][col + 1] == 'o') //Z
                            {
                                iZ++;
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(iI);
        Console.WriteLine(iL);
        Console.WriteLine(iJ);
        Console.WriteLine(iO);
        Console.WriteLine(iZ);
    }
}