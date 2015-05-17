using System;

class UnicodeCharacters
{
    static void Main()
    {
        string inputStr = Console.ReadLine();
        foreach (var chr in inputStr)
        {
            Console.Write("\\U{0:x4}", (int)chr);
        }
        Console.WriteLine();
    }
}