using System;
using System.IO;
using System.Linq;

namespace BrowseCakes
{
    class BrowseCakes
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string htmlContext = File.ReadAllText("../www/BrowseCakes.html");
            Console.WriteLine(htmlContext);

            string getContent = Environment.GetEnvironmentVariable("QUERY_STRING");
            string cakeName = getContent.Split('=')[1];
            string[] databaseContent = File.ReadAllLines("database.csv");
            var result = databaseContent.Where(s => s.Contains(cakeName));
            foreach (var res in result)
            {
                Console.WriteLine(res);
            }
        }
    }
}
