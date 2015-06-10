using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class PhoneNumbers
{
    static void Main()
    {
        StringBuilder textInput = new StringBuilder();

        while (true)
        {
            string lineInput = Console.ReadLine();
            if (lineInput == "END")
            {
                break;
            }
            else
            {
                textInput.Append(lineInput);
            }
        }
        string text = textInput.ToString();
        string pattern = @"([A-Z][a-zA-Z]*)[^a-zA-Z\+]*?(?=\+|[0-9]{2})([0-9\+]{0,1}[0-9][0-9\/(). -]*[0-9])";
        MatchCollection matches = Regex.Matches(text, pattern);

        if (matches.Count == 0)
        {
            Console.WriteLine("<p>No matches!</p>");
        }
        else
        {

            Console.Write("<ol>");
            for (int i = 0; i < matches.Count; i++)
            {
                string name = matches[i].Groups[1].ToString();
                string phoneNumber = matches[i].Groups[2].ToString();
                phoneNumber = phoneNumber.Replace("(", "");                 // “(“, “)”, “/”, “.”, “-”, “ “
                phoneNumber = phoneNumber.Replace(")", "");
                phoneNumber = phoneNumber.Replace("/", "");
                phoneNumber = phoneNumber.Replace(".", "");
                phoneNumber = phoneNumber.Replace("-", "");
                phoneNumber = phoneNumber.Replace(" ", "");

                string result = "<li><b>" + name + ":</b> " + phoneNumber + "</li>";
                Console.Write(result);
            }
            Console.WriteLine("</ol>");
        }
    }
}