using System;
using System.Collections.Generic;

class RemoveNames
{
    static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            Console.WriteLine("Enter first list of names separated by space : ");
            string[] aTmpStrings = Console.ReadLine().Split(' ');
            List<string> lFirstList = new List<string>();
            foreach (string sTmpStr in aTmpStrings)
            {
                lFirstList.Add(sTmpStr);
            }
            Console.WriteLine("Enter first second of names separated by space : ");
            aTmpStrings = Console.ReadLine().Split(' ');
            for (int i = 0; i < aTmpStrings.Length; i++)
            {
                lFirstList.RemoveAll(s => s == aTmpStrings[i]);
            }
            foreach (string sTmpStr in lFirstList)
            {
                Console.Write("{0} ",sTmpStr);
            }
            Console.WriteLine();
        }
    }
}