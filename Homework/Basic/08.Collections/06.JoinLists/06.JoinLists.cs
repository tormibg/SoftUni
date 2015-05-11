using System;
using System.Collections.Generic;
using System.Linq;

class JoinLists
{
    private static void Main()
    {
        Console.WriteLine("Infinite loop. If you want to stop, pres CTRL+C !!!");
        while (true)
        {
            Console.WriteLine("Enter first list of names separated by space : ");
            List<int> lNumbers = (Console.ReadLine().Split(' ')).Select(s => int.Parse(s)).ToList();
            Console.WriteLine("Enter second list of names separated by space : ");
            lNumbers.AddRange((Console.ReadLine().Split(' ')).Select(s => int.Parse(s)).ToList());
            lNumbers.Sort();
            HashSet<int> hsNoRepNum = new HashSet<int>();
            foreach (int iNum in lNumbers)
            {
                hsNoRepNum.Add(iNum);
            }
            foreach (int iNum in hsNoRepNum)
            {
                Console.Write("{0} ",iNum);
            }
            Console.WriteLine();
        }
    }
}