using System;
using System.Collections.Generic;
class NightLife
{
    static void Main()
    {
        Dictionary<string, SortedDictionary<string, SortedSet<string>>> nightLifeDictionary = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

        string[] inputStr;
        string city = String.Empty;
        string venue = String.Empty;
        string performer = String.Empty;
        string tmpInputStr = Console.ReadLine();

        while (tmpInputStr != "END")
        {
            inputStr = tmpInputStr.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            city = inputStr[0];
            venue = inputStr[1];
            performer = inputStr[2];

            if (!nightLifeDictionary.ContainsKey(city))
            {
                nightLifeDictionary[city] = new SortedDictionary<string, SortedSet<string>>();
            }
            if (!nightLifeDictionary[city].ContainsKey(venue))
            {
                nightLifeDictionary[city][venue] = new SortedSet<string>();
            }
            nightLifeDictionary[city][venue].Add(performer);

            tmpInputStr = Console.ReadLine();
        }

        Console.WriteLine();

        foreach (var cityPair in nightLifeDictionary)
        {
            Console.WriteLine(cityPair.Key);
            foreach (var venuePair in cityPair.Value)
            {
                Console.WriteLine("->{0}: {1}", venuePair.Key, String.Join(", ", venuePair.Value));
            }
        }
    }
}