using System;

class House
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int center = (n + 1)/2;
        int leftRoof = center - 2;
        int rightRoof = center;
        for (int row = 0; row < center-1; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (row == 0 && col == center-1)
                {
                    Console.Write("*");
                }
                else if (row > 0 && col == leftRoof)
                {
                    Console.Write("*");
                }
                else if (row > 0 && col == rightRoof)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            if (row > 0)
            {
                leftRoof--;
                rightRoof++;
            }
            Console.WriteLine();
        }
        Console.WriteLine("{0}",new String('*',n));
        int wall = n/4;
        for (int i = 0; i < center-2; i++)
        {
            Console.WriteLine("{0}*{1}*{0}",new string('.',wall),new string('.',n-2-wall-wall));
        }
        Console.WriteLine("{0}{1}{0}", new string('.', wall), new string('*', n - wall - wall));
    }
}