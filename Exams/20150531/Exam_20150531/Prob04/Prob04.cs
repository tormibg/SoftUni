using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Server;

class Prob04
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        List<string> neList = new List<string>();
        while (inputLine != "report")
        {
            neList.Add(inputLine);
            inputLine = Console.ReadLine();
        }
        StringBuilder sb = new StringBuilder();
        HashSet<KeyValuePair<string,string>> dicS = new HashSet<KeyValuePair<string, string>>();
        foreach (string s in neList)
        {
            string name = null, country = null;
            sb.Append(s.Substring(0, s.IndexOf('|')).Trim());
            name = Regex.Replace(sb.ToString(), @"\s{2,}"," ");
            sb.Clear();
            sb.Append(s.Substring(s.IndexOf('|')+1).Trim());
            country = Regex.Replace(sb.ToString(), @"\s{2,}"," ");
            sb.Clear();
    //       Console.WriteLine(name);
            dicS.Add(new KeyValuePair<string, string>(name,country));
        }
        //var groupByName = dicS.GroupBy(x => x.Value).Select(x => new KeyValuePair<string, string>(x,""));
        //var groupb = dicS.OrderBy(x => x.Value).GroupBy(x => x.Key);
        var order = dicS.OrderBy(x => x.Value).GroupBy(x => x.Value);
        foreach (var pp in order)
        {
            var groupb = dicS.Select(x => x.Value == pp.Key);
            int coun = groupb.Count(x => x == true);
            Console.Write(pp.Key);
            Console.Write(" ");
            Console.Write("({0} participants):",dicS.Count(x => x.Value == pp.Key));
            Console.Write(" ");
            Console.WriteLine("{0} wins",coun);
        }
    }
}