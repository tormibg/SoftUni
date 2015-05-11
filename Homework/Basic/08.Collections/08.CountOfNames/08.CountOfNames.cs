using System;
using System.Collections.Generic;
using System.Linq;

class CountOfNames
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            Console.WriteLine("Enter a list of names separated by space : ");
            List<string> sNames = Console.ReadLine().Split(' ').ToList();
            sNames.Sort();
            string sTmpStr = "";
            uint uiNum = 0;
            for (int i = 0; i < sNames.Count; i++)
            {
                if (i == 0)
                {
                    sTmpStr = sNames[i];
                    uiNum = 1;
                }
                else
                {
                    if (sTmpStr == sNames[i])
                    {
                        uiNum++;
                    }
                    else
                    {
                        Console.WriteLine("{0} -> {1}", sTmpStr, uiNum);
                        uiNum = 1;
                        sTmpStr = sNames[i];
                    }
                }
            }
            Console.WriteLine("{0} -> {1}", sTmpStr, uiNum);
        }
    }
}