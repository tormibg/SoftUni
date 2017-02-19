using System;
using System.IO;

namespace Cake
{
    class Cake
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string htmlContext = File.ReadAllText("../www/cake.html");
            Console.WriteLine(htmlContext);
        }
    }
}
