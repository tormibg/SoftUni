using System;
using System.IO;

namespace SendEmail
{
    class SendEmail
    {
        private const string userNeed = "suAdmin";
        public const string passNeed = "aDmInPw17";

        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string request = Environment.GetEnvironmentVariable("REQUEST_METHOD").ToLower();
            Console.WriteLine("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <title>SendEmail</title>\r\n</head>\r\n\r\n<body>");

            if (request == "get")
            {
                PritnGetForm();
            }
            else if (request == "post")
            {
                string[] getContent = Console.ReadLine().Split('&');
                string userName = getContent[0].Split('=')[1];
                string userPass = getContent[1].Split('=')[1];
                Console.WriteLine($"{userName} - {userPass}");
                if (userName == userNeed && userPass == passNeed)
                {
                    string htmlContext = File.ReadAllText("../www/SendEmail2.html");
                    Console.WriteLine(htmlContext);
                }
                else
                {
                    PritnGetForm();
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine("</body>\r\n\r\n</html>");
        }

        static void PritnGetForm()
        {
            string htmlContext = File.ReadAllText("../www/SendEmail1.html");
            Console.WriteLine(htmlContext);
        }
    }
}
