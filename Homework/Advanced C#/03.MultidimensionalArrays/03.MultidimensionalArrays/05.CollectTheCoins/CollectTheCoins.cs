using System;

class CollectTheCoins
{
    private static void Main()
    {
        string[] board = new string[4];
        for (int i = 0; i < 4; i++)
        {
            board[i] = Console.ReadLine();
        }
        char[] input = Console.ReadLine().ToCharArray();

        int x = 0;
        int y = 0;
        int coins = 0;
        int hits = 0;

        for (int i = 0; i < input.Length; i++)
        {
            switch (input[i])
            {
                case '>':
                    int tmp = y + 1;
                    if (tmp < board[x].Length)
                    {
                        y = tmp;
                        if (board[x][y] == '$')
                        {
                            coins++;
                        }
                    }
                    else
                    {
                        hits++;
                    }
                    break;

                case '<':
                    tmp = y - 1;
                    if (tmp >= 0)
                    {
                        y = tmp;
                        if (board[x][y] == '$')
                        {
                            y = tmp;
                            coins++;
                        }
                    }
                    else
                    {
                        hits++;
                    }
                    break;

                case '^':
                    tmp = x - 1;
                    if (tmp >= 0)
                    {
                        x = tmp;
                        if (board[x][y] == '$')
                        {
                            coins++;
                        }
                    }
                    else
                    {
                        hits++;
                    }
                    break;

                case 'v':
                    tmp = x + 1;
                    if (tmp < 4)
                    {
                        x = tmp;
                        if (board[x][y] == '$')
                        {
                            coins++;
                        }
                    }
                    else
                    {
                        hits++;
                    }
                    break;
            }
        }
        Console.WriteLine("Coins collected: {0}", coins);
        Console.WriteLine("Walls hit: {0}", hits);
    }
}