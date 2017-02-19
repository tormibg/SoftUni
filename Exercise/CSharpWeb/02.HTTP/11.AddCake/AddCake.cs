using System;
using System.IO;

namespace AddCake
{
    class AddCake
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string htmlContext = File.ReadAllText("../www/AddCake.html");
            Console.WriteLine(htmlContext);

            string cakeContext = Console.ReadLine();
            Console.WriteLine(cakeContext);

            string[] variables = cakeContext.Split('&');
            string cakeName = variables[0].Split('=')[1];
            string cakePrice = variables[1].Split('=')[1];

            File.AppendAllText("database.csv",$"{cakeName}, {cakePrice}"+Environment.NewLine);
        }
    }
}
