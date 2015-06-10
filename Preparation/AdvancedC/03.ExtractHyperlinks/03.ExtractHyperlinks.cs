using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractHyperlinks
{
    static void Main()
    {
        //             string pattern = "href\\s*=\\s*'?\"?(\\/[a-zA-Z]*|http:\\/\\/.*?(?=\\s+)|#[a-zA-Z]*|javas.*?\\))";
          string pattern = "<a.*?(?<!\">)href\\s*?=\\s*?([\"'])?(?<forPrint>\\S.*?)(?:>|class|\\1)";
        //(?:<a)(?:[\s\n_0-9a-zA-Z=""()]*?.*?)(?:href([\s\n]*)?=(?:['""\s\n]*)?)([a-zA-Z:#\/._\-0-9!?=^+]*(\([""'a-zA-Z\s.()0-9]*\))?)(?:[\s\na-zA-Z=""()0-9]*.*?)?(?:\>)";
        //Console.WriteLine(pattern);

        //http:\\/\\/.*?(?=\")|
 
        StringBuilder sb = new StringBuilder();
        string inputLine = Console.ReadLine();
        while (inputLine != "END")
        {
            sb.Append(inputLine);
            inputLine = Console.ReadLine();
        }
        Regex rxRegex = new Regex(pattern);
        MatchCollection matches = rxRegex.Matches(sb.ToString());
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Groups["forPrint"].Value);
        }
    }
}