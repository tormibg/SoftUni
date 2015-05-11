using System;

class Arrow
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                Console.WriteLine("{0}{1}{0}",new String('.',((n*2)-1-n)/2),new string('#',n));
            }
            else if (i == n-1)
            {
                Console.WriteLine("{0}{1}{0}",new string('#',(((n * 2) - 1 - n) / 2)+1), new string('.',n-2));
            }
            else
            {
                Console.WriteLine("{0}#{1}#{0}", new String('.',((n*2)-1-n)/2),new string('.',n-2));
            }
        }
        int leftSide = 1;
        int rightSide = n*2 - 1 - 1 - 1;

        for (int row = 0; row < n-2; row++)
        {
            for (int col = 0; col < n*2-1; col++)
            {
                if (col == leftSide)
                {
                    Console.Write("#");
                }
                else if (col == rightSide)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            leftSide++;
            rightSide--;
        }
        Console.WriteLine("{0}#{0}",new String('.',(n*2-2)/2));
    }
}