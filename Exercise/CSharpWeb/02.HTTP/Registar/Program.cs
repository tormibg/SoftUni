using System;

namespace Registar
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            Console.WriteLine("<!<!DOCTYPE>\r\n<html>\r\n\r\n<head>\r\n    <title></title>\r\n</head>\r\n\r\n<body>\r\n    <form action=\"CGI.exe\" method=\"GET\">\r\n        <input type=\"text\" name=\"firstName\" value=\"Movie name\">\r\n        <input type=\"password\" name=\"password\" value=\"password\">\r\n        <input type=\"submit\" value=\"Submit\">\r\n    </form>\r\n</body>\r\n\r\n</html>");
            string postContext = Console.ReadLine();
            Console.WriteLine(postContext);
        }
    }
}
