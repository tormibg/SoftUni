using System;

class Dumbbell
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int leftSide = 0;
        Console.WriteLine("{0}{1}{2}{1}{0}",new string('.',n/2), new string('&',n/2+1), new string('.', n));
        for (int i = 1; i < n/2; i++)
        {
            Console.WriteLine("{0}&{1}&{2}&{1}&{0}", new string('.', n / 2-leftSide-1), new string('*', n / 2+leftSide), new string('.', n));
            leftSide++;
        }
        leftSide--;
        Console.WriteLine("&{0}&{1}&{0}&", new string('*', n - 2), new string('=', n));
        for (int i = n/2-1; i > 0; i--)
        {
            Console.WriteLine("{0}&{1}&{2}&{1}&{0}", new string('.', n / 2 - leftSide - 1), new string('*', n / 2 + leftSide), new string('.', n));
            leftSide--;
        }
        Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', n / 2), new string('&', n / 2 + 1), new string('.', n));
    }
}
