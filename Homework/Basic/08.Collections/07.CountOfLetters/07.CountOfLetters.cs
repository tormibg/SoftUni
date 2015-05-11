using System;
using System.Collections.Generic;
using System.Linq;

class CountOfLetters
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            Console.WriteLine("Enter a list of letters separated by space : ");
            List<char> lLetters = (Console.ReadLine().Split(' ')).Select(s => char.Parse(s)).ToList();
            lLetters.Sort();
            char? cTmpCh = null;
            uint uiNum = 0;
            for (int i = 0; i < lLetters.Count; i++)
            {
                if (i == 0)
                {
                    cTmpCh = lLetters[i];
                    uiNum = 1;
                }
                else
                {
                    if (cTmpCh == lLetters[i])
                    {
                        uiNum++;
                    }
                    else
                    {
                        Console.WriteLine("{0} -> {1}",cTmpCh,uiNum);
                        uiNum = 1;
                        cTmpCh = lLetters[i];
                    }
                }
            }
            Console.WriteLine("{0} -> {1}", cTmpCh, uiNum);
        }
    }
}