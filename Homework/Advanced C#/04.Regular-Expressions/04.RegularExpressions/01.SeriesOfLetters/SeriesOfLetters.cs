using System;
using System.Text.RegularExpressions;

class SeriesOfLetters
{
    static void Main()
    {
        string inputStr = Console.ReadLine();
        string pattern = @"(\w)\1+";
        Console.WriteLine(Regex.Replace(inputStr, pattern, "$1"));
    }
}