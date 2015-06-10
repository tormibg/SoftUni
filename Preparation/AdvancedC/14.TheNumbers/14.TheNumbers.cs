using System;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;

class TheNumbers
{
    static void Main()
    {
        string pattern = @"\d+";
        string inputStr = Console.ReadLine();
        Regex rxRegex = new Regex(pattern);
        MatchCollection matches = rxRegex.Matches(inputStr);
        if (matches.Count > 0)
        {
            StringBuilder sbFinal = new StringBuilder();
            for (int i = 0; i < matches.Count; i++)
            {
                string hexValue = String.Format("0x{0}", int.Parse(matches[i].ToString()).ToString("X").PadLeft(4, '0'));
                sbFinal.Append(hexValue);
                if (matches.Count > 1 && i < matches.Count-1)
                {
                    sbFinal.Append("-");
                }
            }
            Console.WriteLine(sbFinal.ToString());
            //foreach (Match match in matches)
           // {
                
                
          //  }
        }
    }
}