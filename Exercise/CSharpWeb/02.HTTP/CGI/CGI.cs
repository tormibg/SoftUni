using System;
using System.Linq;

namespace CGI
{
    class Cgi
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            //Console.WriteLine("<!<!DOCTYPE>\r\n<html>\r\n\r\n<head>\r\n    <title>Wellcome</title>\r\n\r\n    <body>\r\n    </body>\r\n</head>\r\n\r\n<body>\r\n    <h1>Hello</h1>\r\n    <div>\r\n        <p>Ax sum paragrafs</p>\r\n        <p>2-ri paragraf</p>\r\n    </div>\r\n</body>\r\n\r\n</html>");

            //Console.WriteLine("<!<!DOCTYPE>\r\n<html>\r\n\r\n<head>\r\n    <title></title>\r\n</head>\r\n\r\n<body>\r\n    <form action=\"CGI.exe\" method=\"GET\">\r\n        <input type=\"text\">\r\n        <input type=\"text\">\r\n        <input type=\"sumbit\">\r\n    </form>\r\n</body>\r\n\r\n</html>");

            string[] array = new[] { "Titan", "Titan-2", "Titan-3" };
            Console.WriteLine(
                "<!<!DOCTYPE>\r\n<html>\r\n\r\n<head>\r\n    <title></title>\r\n</head>\r\n\r\n<body>\r\n    <form action=\"CGI.exe\" method=\"GET\">\r\n        <input type=\"text\" name=\"firstName\" value=\"Movie name\">\r\n        <input type=\"submit\" value=\"Submit\">\r\n    </form>\r\n</body>\r\n\r\n</html>");
            string getContent = Environment.GetEnvironmentVariable("QUERY_STRING");
            Console.WriteLine(getContent);
            string valueForContent = getContent.Split('=')[1];
            var fileters = array.Where(s => s.Contains(valueForContent));
            foreach (var fileter in fileters)
            {
                Console.WriteLine($"<p>{fileter}</p>");
            }
        }
    }
}
