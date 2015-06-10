using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Prob03
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        string input = Console.ReadLine().Trim();
        while (input != "burp")
        {
            sb.Append(input);
            input = Console.ReadLine().Trim();
        }
     //   Console.WriteLine(sb.ToString());
        string arr = Regex.Replace(sb.ToString(), @"\s{2,}", " ");
      //  Console.WriteLine(arr);
        sb.Clear();
        string finalWord = "";
        finalWord = " " + GetRegex('$',arr);
        if (sb.Length == 0)
        {
            finalWord = finalWord.TrimStart();
        }
        if (finalWord.Length > 0)
        {
            sb.Append(finalWord);
        }
        finalWord = " " + GetRegex('%', arr);
        if (sb.Length == 0)
        {
            finalWord = finalWord.TrimStart();
        }
        if (finalWord.Length > 0)
        {
            sb.Append(finalWord);
        }
        finalWord = " " + GetRegex('&', arr);
        if (sb.Length == 0)
        {
            finalWord = finalWord.TrimStart();
        }
        if (finalWord.Length > 0)
        {
            sb.Append(finalWord);
        }
        finalWord = " " + GetRegex('\'', arr);
        if (sb.Length == 0)
        {
            finalWord = finalWord.TrimStart();
        }
        if (finalWord.Length > 0)
        {
            sb.Append(finalWord);
        }
        Console.WriteLine(sb.ToString());
    }

    private static string GetRegex(char p, string arr)
    {
        string str = null;
        string pattern = @"((\" + p + "))(.*?)((\\" + p + "))";
     //   Console.WriteLine(pattern);
        Regex rxRegex = new Regex(pattern);
        if (rxRegex.IsMatch(arr))
        {
            str = " " + GetStr(rxRegex, arr, str, p);
            str = str.TrimStart();
        }
        return str;
    }

    private static string GetStr(Regex rxRegex, string arr, string str, char p)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(arr);
        string tmpstr = "";
        string tmpStr;
       
            MatchCollection matches = rxRegex.Matches(sb.ToString());
            for (int i = 0; i < matches.Count; i++)
            {
                str += (matches[i].Groups[3].Value.ToString());
                tmpStr = GetWord(str, p);
            }
        return GetWord(str, p);
    }

    private static string GetWord(string str, char p)
    {
        StringBuilder sb = new StringBuilder();
        int weight = 1;
        switch (p)
        {
            case '$':
            {
                weight = 1;
            }
                break;
            case '%':
                {
                    weight = 2;
                }
                break;
            case '&':
                {
                    weight = 3;
                }
                break;
            case '\'':
                {
                    weight = 4;
                }
                break;

        }
        for (int i = 2; i < str.Length + 2; i++)
        {
            char aa = '\n';
            if (i%2 == 0)
            {
                aa = (char) (int) (str[i-2] + weight);
            }
            else
            {
                aa = (char) (int) (str[i-2] - weight);
            }
            sb.Append(aa.ToString());
        }
        return sb.ToString();
    }

}