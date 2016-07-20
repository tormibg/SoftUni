namespace _12.LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LegendaryFarming
    {
        public static void Main()
        {
            string legendaryName = string.Empty;
            Dictionary<string, uint> itemsDictionary = new Dictionary<string, uint>()
            {
                                                                     { "fragments", 0},
                                                                     { "motes", 0},
                                                                     { "shards", 0}
            };
            Dictionary<string, uint> junksDictionary = new Dictionary<string, uint>();
            Dictionary<string, string> legendaryDictionary = new Dictionary<string, string>()
                                                                 {
                                                                     { "shards", "Shadowmourne"},
                                                                     { "fragments", "Valanyr"},
                                                                     { "motes", "Dragonwrath"}
                                                                 };

            string input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                bool isOK = false;
                string[] inputArgs = input.Split().ToArray();
                for (int j = 0; j < inputArgs.Length; j += 2)
                {
                    uint numberOfMaterial = uint.Parse(inputArgs[j]);
                    string nameOfMaterial = inputArgs[j + 1].ToLower();
                    if (legendaryDictionary.ContainsKey(nameOfMaterial))
                    {
                        itemsDictionary[nameOfMaterial] += numberOfMaterial;
                        if (itemsDictionary[nameOfMaterial] >= 250)
                        {
                            isOK = true;
                            legendaryName = legendaryDictionary[nameOfMaterial];
                            itemsDictionary[nameOfMaterial] = itemsDictionary[nameOfMaterial] - 250;
                            break;
                        }
                    }
                    else
                    {
                        if (!junksDictionary.ContainsKey(nameOfMaterial))
                        {
                            junksDictionary.Add(nameOfMaterial, 0);
                        }
                        junksDictionary[nameOfMaterial] += numberOfMaterial;
                    }
                }
                if (isOK)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{legendaryName} obtained!");
            var sortedItemsDictionary = itemsDictionary.OrderByDescending(x => x.Value).ThenBy(y => y.Key);
            foreach (var item in sortedItemsDictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            var sortedJunksDictionary = junksDictionary.OrderBy(x => x.Key);
            foreach (var item in sortedJunksDictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
