using System;

class LongestWordInAText
{
    private static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            Console.WriteLine("Enter a text :");
            string[] sTxtStrings = Console.ReadLine().Split(new char[] {' ','.',',',';'});
            uint uiCount = 0;
            string sMaxWord = "";
            for (int i = 0; i < sTxtStrings.Length; i++)
            {
                if (sTxtStrings[i].Length > uiCount)
                {
                    uiCount = (uint)sTxtStrings[i].Length;
                    sMaxWord = sTxtStrings[i];
                }
            }
            Console.WriteLine(sMaxWord);
        }
    }
}