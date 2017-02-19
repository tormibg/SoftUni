using System;
using System.IO;
using System.Net;

namespace Login
{
    class LogIn
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string htmlContext = File.ReadAllText("../www/login.html");
            Console.WriteLine(htmlContext);

            string[] getContent = Console.ReadLine().Split('&');
            Console.WriteLine($"Hi root, your password is {WebUtility.UrlDecode(getContent[1].Split('=')[1])}");
        }
    }
}
