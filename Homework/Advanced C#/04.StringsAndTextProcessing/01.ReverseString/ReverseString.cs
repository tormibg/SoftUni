using System;

class ReverseString
{
    static void Main()
    {
        string inputStr = Console.ReadLine();
        for (int i = inputStr.Length-1; i >= 0; i--)
        {
            Console.Write(inputStr[i]);
        }
        Console.WriteLine();
    }
}