using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

class VladkoNotebook
{
    static void Main()
    {
        StringBuilder outBuilder = new StringBuilder();
        Dictionary<string,Players> oppDic = new Dictionary<string, Players>();
        string inputLine = Console.ReadLine();
        while (inputLine != "END")
        {
            string[] lineStrings = inputLine.Split('|').ToArray();
            if (!oppDic.ContainsKey(lineStrings[0]))
            {
                oppDic[lineStrings[0]] = new Players();
            }

            if (lineStrings[1] == "age")
            {
                oppDic[lineStrings[0]].Age = int.Parse(lineStrings[2]);
            }

            else if (lineStrings[1] == "win")
            {
                oppDic[lineStrings[0]].WinCount++;
                oppDic[lineStrings[0]].NameList.Add(lineStrings[2]);
            }

            else if (lineStrings[1] == "loss")
            {
                oppDic[lineStrings[0]].LossCount++;
                oppDic[lineStrings[0]].NameList.Add(lineStrings[2]);
            }

            else if (lineStrings[1] == "name")
            {
                oppDic[lineStrings[0]].Name = lineStrings[2];
            }
            inputLine = Console.ReadLine();
        }
        var newDic = oppDic
            .Where(x => x.Value.Name != null && x.Value.Age != 0)
            .ToArray().OrderBy(x => x.Key);

        if (newDic.Count() == 0)
        {
            Console.WriteLine("No data recovered.");
            return;
        }
        foreach (var value in newDic)
        {
            outBuilder.AppendLine(String.Format("Color: {0}", value.Key));
            outBuilder.AppendLine(String.Format("-age: {0}", value.Value.Age));
            outBuilder.AppendLine(String.Format("-name: {0}", value.Value.Name));
            string oppStr = "(empty)";
            if (value.Value.NameList.Count > 0 )
            {
                var sortOp = value.Value.NameList.OrderBy(x => x, StringComparer.Ordinal);
                oppStr = String.Join(", ",sortOp);
            }
            outBuilder.AppendLine(String.Format("-opponents: {0}", oppStr));    
            outBuilder.AppendLine(String.Format("-rank: {0:F}", (value.Value.WinCount + 1) / ((double)value.Value.LossCount + 1)));
        }
        Console.WriteLine(outBuilder.ToString());
    }
}

internal class Players
{
    public Players()
    {
        this.NameList = new List<string>();
    }

    public int Age { get; set; }
    public string Name { get; set; }
    public int LossCount { get; set; }
    public int WinCount { get; set; }
    public List<string> NameList { get; set; }
}