using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Calculator
{
    class Calculator
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string htmlContex = File.ReadAllText("../www/calculator.html");
            Console.WriteLine(htmlContex);

            string[] getContent = Console.ReadLine().Split('&');
            //string[] getContent = new string[] {"1","3", "4"};
            //getContent[1] = WebUtility.UrlEncode("+");
            Console.WriteLine(WebUtility.UrlDecode(getContent[1].Split('=')[1]));
            string result = String.Empty;
            float firstNum = float.Parse(getContent[0].Split('=')[1]);
            float secondNum = float.Parse(getContent[2].Split('=')[1]);
            switch (WebUtility.UrlDecode(getContent[1].Split('=')[1]))
            {
                case "+":
                    {
                        result = "Result: "+ (firstNum + secondNum).ToString(CultureInfo.InvariantCulture);
                        break;
                    }
                case "-":
                    {
                        result = "Result: " + (firstNum - secondNum).ToString(CultureInfo.InvariantCulture);
                        break;
                    }
                case "*":
                    {
                        result = "Result: " + (firstNum * secondNum).ToString(CultureInfo.InvariantCulture);
                        break;
                    }
                case "/":
                    {
                        result = "Result: " + (firstNum / secondNum).ToString(CultureInfo.InvariantCulture);
                        break;
                    }
                default:
                    result = "Invalid Sign.";
                    break;
            }
            Console.WriteLine($"<p>{result}</p>");
        }
    }
}
