using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;

internal class SumOfAllValues
{
    private static void Main()
    {
        string patternKey = @"^([a-zA-Z_]+)\d+(?:.*\d)*([a-zA-Z_]+)$";
        string patternTxt = @"(?<=startKEY)([^\s*][0-9]*\.?[0-9]*?)(?=endKEY)";
        string inputKey = Console.ReadLine();
        Regex rxRegex = new Regex(patternKey);
        MatchCollection matches = rxRegex.Matches(inputKey);
        if (rxRegex.IsMatch(inputKey))
        {
            string startKey = matches[0].Groups[1].Value;
            string endKey = matches[0].Groups[2].Value;

            patternTxt = @"(?<=(" + startKey + "))([^\\s*][0-9]*\\.?[0-9]*?)(?=(" + endKey + "))";
            rxRegex = new Regex(patternTxt);
            string inputTXT = Console.ReadLine();
            if (rxRegex.IsMatch(inputTXT))
            {
                //MatchCollection numMatch = rxRegex.Matches(inputTXT);
                double sum = 0;
                //foreach (Match match in numMatch)
                //{
                //    sum += double.Parse(match.Groups[1].Value);
                //}

                sum = SumSum(rxRegex, inputTXT, sum);
                Console.WriteLine("<p>The total value is: <em>{0}</em></p>", sum);
            }
            else
            {
                Console.WriteLine("<p>The total value is: <em>nothing</em></p>");
            }

        }
        else
        {
            Console.WriteLine("<p>A key is missing</p>");
        }
    }

    private static double SumSum(Regex rxRegex, string inputTXT, double sum)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(inputTXT);
        string tmpStr;
        while (true)
        {
            MatchCollection matches = rxRegex.Matches(sb.ToString());
            if (matches.Count > 0)
            {
                sum += double.Parse(matches[0].Groups[2].Value.ToString());
                sb.Remove(matches[0].Groups[1].Index, matches[0].Groups[1].ToString().Count());
                sb.Remove(matches[0].Groups[3].Index - matches[0].Groups[1].ToString().Count(),
                    matches[0].Groups[3].ToString().Count());
            }
            else
            {
                break;
            }
        }
        return sum;
    }
}