using System;

class CountingAWordInAText
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            Console.WriteLine("Enter word : ");
            string sWord = Console.ReadLine();
            Console.WriteLine("Enter a text :");
            string[] aStrings = Console.ReadLine().Split(new char[] {' ', '.', ',', '"', '@', '!', '?', '/', '\\', ':', ';', '(', ')'});

            int iCount = 0;

            for (int i = 0; i < aStrings.Length; i++)
            {
                if (string.Equals(aStrings[i], sWord, StringComparison.OrdinalIgnoreCase))
                {
                    iCount++;
                }
            }
            Console.WriteLine(iCount);
        }
    }
}