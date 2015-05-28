using System;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

class UppercaseWords
{
    static void Main()
    {
        StringBuilder finalSB = new StringBuilder();
        string pattern = @"(?<![a-zA-Z])[A-Z]+(?![a-zA-Z])";
        string inputLine = Console.ReadLine();
        while (inputLine != "END")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(inputLine);
            Regex rxRegex = new Regex(pattern);
            MatchCollection matchesCollection = rxRegex.Matches(sb.ToString());
            int offset = 0;
            foreach (Match match in matchesCollection)
            {
                StringBuilder revString = new StringBuilder();
                revString.Append(ReverseMatch(match.ToString()));
                if (revString.ToString() == match.ToString())
                {
                    revString = DoubleMatch(revString);
                }
                sb.Remove(match.Index+offset, match.Length);
                sb.Insert(match.Index+offset, revString);
                offset = offset + (revString.ToString().Length - match.Value.Length);
            }
            Console.WriteLine("{0}",SecurityElement.Escape(sb.ToString()));
            finalSB.Append(sb);
            inputLine = Console.ReadLine();
        }
 //       Console.WriteLine(finalSB.ToString());
    }

    private static StringBuilder DoubleMatch(StringBuilder revString)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var ch in revString.ToString())
        {
            sb.Append(ch.ToString());
            sb.Append(ch).ToString();
        }
        return sb;
    }


    private static string ReverseMatch(string p)
    {
        StringBuilder revStr = new StringBuilder();
        for (int i = p.Length-1; i >= 0; i--)
        {
            revStr.Append(p[i].ToString());
        }
        return revStr.ToString();
    }
}