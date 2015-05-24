using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class WordCount
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\words.txt");
        string[] words = GetFilters(reader);

        var wordsMatches = new Dictionary<string,int>();
 
        reader = new StreamReader(@"..\..\text.txt");
        using (reader)
        {
            string textFull = reader.ReadToEnd().ToLower();
            for (int i = 0; i < words.Length; i++)
            {
                string regExt = @"\b"+words[i]+@"\b";
                MatchCollection matches = Regex.Matches(textFull, regExt);
                wordsMatches.Add(words[i],matches.Count);
            }
        }
        StreamWriter writer = new StreamWriter(@"..\..\result.txt");
        using (writer)
        {
            foreach (var match in wordsMatches.OrderByDescending(p => p.Value))
            {
                writer.WriteLine("{0} - {1}", match.Key, match.Value);
            }
        }
    }

    private static string[] GetFilters(StreamReader reader)
    {
        using (reader)
        {
            string[] words =
                reader.ReadToEnd()
                    .ToLower()
                    .Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            return words;
        }
    }
}