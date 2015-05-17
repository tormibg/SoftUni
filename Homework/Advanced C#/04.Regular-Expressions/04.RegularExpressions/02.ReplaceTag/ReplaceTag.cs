using System;
using System.Text.RegularExpressions;

class ReplaceTag
{
    static void Main()
    {
        string pattern = @"<a.*href=((?:.|\n)*?(?=>))>((?:.|\n)*?(?=<))<\/a>";
        string inputStr = Console.ReadLine();
        string replace = @"[URL href=$1]$2[/URL]";
        Console.WriteLine(Regex.Replace(inputStr, pattern, replace));
    }
}