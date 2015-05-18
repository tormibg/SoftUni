using System;
using System.Text.RegularExpressions;

class MatchFullName
{
    static void Main()
    {
        string pattern = @"\b([A-Z][a-z]+) ([A-Z][a-z]+)\b";
        string inputStr = Console.ReadLine();
        Regex regex = new Regex(pattern);
        Match mm = regex.Match(inputStr);
        MatchCollection match = regex.Matches(inputStr);
        Console.WriteLine(regex.Replace(inputStr, "Petar Petrov"));
    }
}