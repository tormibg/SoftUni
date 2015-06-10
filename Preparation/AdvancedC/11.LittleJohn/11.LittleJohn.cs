using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class LittleJohn
{
    static void Main()
    {
        //string patternSmall = @"(?<!>)(>)----->(?!>)";
        //string patternMed = @"(?<!>)(>>)----->(?!>)";
        //string patternLarg = @"(?<!>)(>>>)----->>(?!>)";
        StringBuilder inputTxt = new StringBuilder();
        string pattern = @"(>>>----->>)|(>>----->)|(>----->)";
        int smallNum = 0, mediumNum = 0, largeNum = 0;
        for (int i = 1; i <= 4; i++)
        {
            inputTxt.Append(String.Format(" {0}",Console.ReadLine()));
        }
        Regex rxRegex = new Regex(pattern);
        MatchCollection matches = rxRegex.Matches(inputTxt.ToString());
        foreach (Match match in matches)
        {
            if (!string.IsNullOrEmpty(match.Groups[1].Value))
            {
                largeNum++;
            }
            else if (!string.IsNullOrEmpty(match.Groups[2].Value))
            {
                mediumNum++;
            }
            else
            {
                smallNum++;
            }
        }
        int num = int.Parse(smallNum.ToString() + mediumNum.ToString() + largeNum.ToString());
        string binary = Convert.ToString(num, 2);
        string reversed = Reverse(binary);
        string lastBinStr = binary + reversed;
        decimal finalNum = Convert.ToInt32(lastBinStr, 2);
        Console.WriteLine(finalNum);
    }
    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}