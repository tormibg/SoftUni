using System;
using System.Text.RegularExpressions;

class MatchPhoneNumber
{
    static void Main()
    {
        string pattern = @"(\s*|\A)\+\d{3}(?<del> |\-)(?<dig>\d)\k<del>\d{3}\k<del>\d{4}\b";
        Regex regiRegex = new Regex(pattern);
        string inputStr =
            "+359 2 222 2222, +359-2-222-2222, 359-2-222-2222, +359/2/222/2222, +359-2 222 2222,+359 2-222-2222, +359-2-222-222, +359-2-222-22222";
        Match match = regiRegex.Match(inputStr);
        MatchCollection mm = regiRegex.Matches(inputStr);
        foreach (Match mmMatch in mm)
        {
            Console.WriteLine(mmMatch.Groups[0]);
            Console.WriteLine(mmMatch.Groups["del"]);
            Console.WriteLine(mmMatch.Groups["dig"]);
        }
    }
}