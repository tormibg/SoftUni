using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class SemanticHTML
{
    static void Main()
    {
        string patternOpen = @"<div.*?\b((id|class)\s*=\s*""(.*?)"").*?>";
        string patternClose = @"<\/div.*?--\s*(\w+)\s*-->";

        string[] tags = new string[]{"main", "header", "nav", "article", "section", "aside", "footer"};

        StringBuilder sbFinal = new StringBuilder();
        Regex rxOpen = new Regex(patternOpen);
        Regex rxClose = new Regex(patternClose);
        string inputLine = Console.ReadLine();
        while (inputLine != "END")
        {
            MatchCollection matches = rxOpen.Matches(inputLine);

            foreach (Match match in matches)
            {
                //Console.WriteLine(match.Value);
                //Console.WriteLine(match.Groups[1].Value);
                //Console.WriteLine(match.Groups[2].Value);
                //Console.WriteLine(match.Groups[3].Value);

                string tagName = match.Groups[1].Value;
                string tagValue = match.Groups[3].Value;
                if (tags.Contains(tagValue))
                {
                    string tagForRepalce = Regex.Replace(match.ToString(), "div", x => tagValue);
                    //Console.WriteLine(tagForRepalce);
                    tagForRepalce = Regex.Replace(tagForRepalce, tagName, "");
                    tagForRepalce = Regex.Replace(tagForRepalce, @"\s*>", ">");
                    tagForRepalce = Regex.Replace(tagForRepalce, @"\s{2,}", " ");
                    inputLine = Regex.Replace(inputLine, match.ToString(), tagForRepalce);
                }
            }
            matches = rxClose.Matches(inputLine);

            foreach (Match match in matches)
            {
                //Console.WriteLine(match.Value);
                //Console.WriteLine(match.Groups[1]);
                string tagValue = match.Groups[1].Value;
                inputLine = Regex.Replace(inputLine, match.ToString(), String.Format("</{0}>", tagValue));
            }
            sbFinal.AppendLine(inputLine);
            inputLine = Console.ReadLine();
        }
        Console.WriteLine(sbFinal.ToString());
    }
}