using System;
using System.IO;

namespace Greetings1
{
    class Greetings1
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string request = Environment.GetEnvironmentVariable("REQUEST_METHOD").ToLower();
            string htmlContext = File.ReadAllText("../www/greeting1.html");
            Console.WriteLine(htmlContext);
            int state = 0;
            if (request == "get")
            {
                
               PritnGetForm("greeting1.2.html");
                 
            }
            else
            {
                string[] getContext = Console.ReadLine().Split('=');
                if (getContext[0] == "firstName")
                {
                    File.WriteAllText("Names.csv",getContext[1]);
                    PritnGetForm("greeting1.3.html");
                    state = 1;
                } else if (getContext[0] == "lastName")
                {
                    File.AppendAllText("Names.csv", $",{getContext[1]}");
                    PritnGetForm("greeting1.4.html");
                    state = 2;
                }
                else if (getContext[0] == "Age")
                {
                    string[] names = File.ReadAllText("Names.csv").Split(',');
                    Console.WriteLine($"Hello {names[0]} {names[1]} as {getContext[1]}");
                    state = 3;
                }
                else
                {
                    switch (state)
                    {
                        case 0:
                            PritnGetForm("greeting1.2.html");
                            break;
                        case 1:
                            PritnGetForm("greeting1.3.html");
                            break;
                        case 2:
                            PritnGetForm("greeting1.4.html");
                            break;
                    }
                    Console.WriteLine(getContext[0]);
                    Console.WriteLine("Invalid input !!!");
                }
            }
            PritnGetForm("greeting1.5.html");
        }

        static void PritnGetForm(string htmlContex)
        {
            string htmlContext = File.ReadAllText($"../www/{htmlContex}");
            Console.WriteLine(htmlContext);
        }
    }
}
