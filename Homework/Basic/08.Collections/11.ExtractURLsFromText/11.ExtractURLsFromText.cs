using System;

class ExtractURLsFromText
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            Console.WriteLine("Enter a text :");
            string[] sTxtStrings = Console.ReadLine().Split(new char[] {' ', ',', ';'});
            for (int i = 0; i < sTxtStrings.Length; i++)
            {
                if (sTxtStrings[i].Length > 6)
                {
                    if (sTxtStrings[i].Substring(0, 4) == "www." || sTxtStrings[i].Substring(0, 7) == "http://")
                    {
                        Console.WriteLine(sTxtStrings[i]);
                    }   
                }
            }
        }
    }
}