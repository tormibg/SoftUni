using System;

class IsoscelesTriangle
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        char lcFirstVar = '\u00A9';
        Console.WriteLine("   {0}   ",lcFirstVar);
        Console.WriteLine("  {0} {1}  ",lcFirstVar,lcFirstVar);
        Console.WriteLine(" {0}   {1} ",lcFirstVar,lcFirstVar);
        Console.WriteLine("{0} {1} {2} {3}",lcFirstVar,lcFirstVar,lcFirstVar,lcFirstVar);

        Console.WriteLine(new string('-', 15));

        int liLines = 4;

        string lsFirstLine = new string(' ', liLines - 1) + lcFirstVar;

        Console.WriteLine(lsFirstLine);
        for (int i = 2, left = liLines - 2, right = 1; i < liLines * 2; i++)
        {
            if (i < liLines)
            {
                Console.WriteLine(new string(' ', left) + lcFirstVar + new string(' ', right) + lcFirstVar);
                right += 2;
                left--;
            }
            else
            {
                Console.Write(lcFirstVar + " ");
            }
        }
        Console.WriteLine();
    }
}
