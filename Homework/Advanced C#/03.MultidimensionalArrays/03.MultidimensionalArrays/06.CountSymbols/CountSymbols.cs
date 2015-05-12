using System;
using System.Collections.Generic;

class CountSymbols
{
    static void Main()
    {
        string inputText = Console.ReadLine();

        SortedDictionary<char, int> occurrences = new SortedDictionary<char, int>();
        foreach (char symbol in inputText)
        {
            if (occurrences.ContainsKey(symbol))
            {
                occurrences[symbol]++;
            }
            else
            {
                occurrences.Add(symbol, 1);
            }
        }

        foreach (KeyValuePair<char, int> pair in occurrences)
        {
            Console.WriteLine("{0}: {1} time/s", pair.Key, pair.Value);
        }
    }
}