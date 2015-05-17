using System;
using System.Text.RegularExpressions;

class SentenceExtractor
{
    static void Main()
    {
        string inputWord = Console.ReadLine();
        string inputStr = Console.ReadLine();
        string pattern = string.Format(@"\s*(.*?\b{0}\b.*?[.!?])", inputWord);
        MatchCollection matches = Regex.Matches(inputStr, pattern, RegexOptions.IgnoreCase);
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Groups[0]);
        }
    }
}