using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

class QueryMess
{
    static void Main()
    {
        StringBuilder inputLine = new StringBuilder();
        StringBuilder sbTmp = new StringBuilder();
        string inputStr = Console.ReadLine();
        while (inputStr != "END")
        {
            if (inputStr.Contains("http"))
            {
                sbTmp.AppendLine(inputStr.Substring(inputStr.IndexOf("?") + 1));
            }
            else
            {
                sbTmp.AppendLine(inputStr);    
            }
  
            Dictionary<string, List<string>> messD = new Dictionary<string, List<string>>();
            string[] arStr = sbTmp.ToString().Split(new char[] {'&'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (string s in arStr)
            {
                string[] newAr = s.Trim().Split(new char[] {'='}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                int count = 1;
                string key = "";
                foreach (string s1 in newAr)
                {
                    StringBuilder sb = new StringBuilder(s1);
                    //Regex rxRegex = new Regex(@"((%20|\+)+)");
                    //MatchCollection matches = rxRegex.Matches((sb.ToString()));
                    //matches.
                    //foreach (Match match in matches)
                    //{
                    //    sb.Replace(match.Groups[1].Value.ToString(), " ");
                    //}
                    string str = Regex.Replace(sb.ToString(), @"((%20|\+)+)", x => " ").Trim();
                    sb.Clear();
                    sb.Append(str);
                    if (count%2 != 0)
                    {
                        if (!messD.ContainsKey(sb.ToString().Trim()))
                        {
                            messD[sb.ToString().Trim()] = new List<string>();
                        }
                        key = sb.ToString().Trim();
                        count++;
                    }
                    else
                    {
                        messD[key].Add(sb.ToString().Trim());
                        count++;
                    }
                }
            }
            sbTmp.Clear();
            foreach (string pair in messD.Keys)
            {
                sbTmp.Append(String.Format("{0}=", pair));
                List<string> tmp = messD[pair];
                sbTmp.Append(String.Format("[{0}]", string.Join(", ", tmp)));
            }
            Console.WriteLine(sbTmp.ToString());
            inputLine.Clear();
            sbTmp.Clear();
            inputStr = Console.ReadLine();
        }
    }

    //private static void RegString(StringBuilder sbTmp, string p)
    //{
    //    Regex rxRegex = new Regex(p);
    //    MatchCollection matches = rxRegex.Matches((sbTmp.ToString()));
    //    foreach (Match match in matches)
    //    {
    //        sbTmp.Replace(match.Groups[1].Value.ToString(), " ");
    //    }
    //}

}