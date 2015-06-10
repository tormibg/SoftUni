using System;
using System.Text;
using System.Text.RegularExpressions;

class PhoneNumbers
{
    static void Main()
    {
        string pattern = @"([A-Z][A-Za-z]*)[^a-zA-Z\+]*?(?=\+|[0-9]{2})([0-9\+]{0,1}[0-9][0-9\/(). -]*[0-9])";
        StringBuilder inputTxt = new StringBuilder();
        string input = Console.ReadLine();
        while (input != "END")
        {
            inputTxt.Append(String.Format("{0}",input));
            input = Console.ReadLine();
        }
        Regex sxRegex = new Regex(pattern);
        MatchCollection matches = sxRegex.Matches(inputTxt.ToString());

        if (matches.Count == 0)
        {
            Console.WriteLine("<p>No matches!</p>");
        }
        else
        {
            Console.Write("<ol>");
            foreach (Match match in matches)
            {
                //“(“, “)”, “/”, “.”, “-”, “ “ 
                string name = match.Groups[1].Value;
                string phone = match.Groups[2].Value;
                phone = phone.Replace("(", "");
                phone = phone.Replace(")", "");
                phone = phone.Replace("/", "");
                phone = phone.Replace(".", "");
                phone = phone.Replace("-", "");
                phone = phone.Replace(" ", "");

                Console.Write("<li><b>{0}:</b> {1}</li>",name,phone);
            }
            Console.WriteLine("</ol>");
        }
    }
}