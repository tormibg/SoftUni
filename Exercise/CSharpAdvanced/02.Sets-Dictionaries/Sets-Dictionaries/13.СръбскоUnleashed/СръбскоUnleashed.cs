namespace _13.СръбскоUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class СръбскоUnleashed
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> singerVenueDictionary = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string pattern = @"([a-zA-Z]+\s){1,3}@([a-zA-Z]+\s){1,3}([0-9]+\s)([0-9]+)";

                var matches = Regex.Matches(input, pattern);
                if (matches.Count > 0)
                {
                    string[] inputArgs = matches[0].ToString().Split(new char[] { '@' }).ToArray();
                    string singerName = inputArgs[0].Trim();
                    //Console.WriteLine(singerName);
                    string[] inputArgsTickets = inputArgs[1].Split().ToArray();
                    uint ticketsCount = uint.Parse(inputArgsTickets.Last());
                    uint ticketsPrice = uint.Parse(inputArgsTickets[inputArgsTickets.Length - 2]);
                    //Console.WriteLine($"{ticketsPrice} -> {ticketsCount}");
                    StringBuilder venue = new StringBuilder();
                    venue.Append(inputArgsTickets.First().Trim());
                    for (int i = 1; i < inputArgsTickets.Length - 2; i++)
                    {
                        venue.Append(" " + inputArgsTickets[i].Trim());
                    }
                    string venueStr = venue.ToString();
                    if (!singerVenueDictionary.ContainsKey(venueStr))
                    {
                        singerVenueDictionary.Add(venueStr, new Dictionary<string, long>());
                    }
                    if (!singerVenueDictionary[venueStr].ContainsKey(singerName))
                    {
                        singerVenueDictionary[venueStr].Add(singerName, 0);
                    }
                    singerVenueDictionary[venueStr][singerName] += ticketsCount * ticketsPrice;
                }
                input = Console.ReadLine();
            }
            StringBuilder venueSingerSB = new StringBuilder();
            foreach (var singers in singerVenueDictionary)
            {
                venueSingerSB.Append($"{singers.Key}\n");
                foreach (var singer in singers.Value.OrderByDescending(x => x.Value))
                {
                    venueSingerSB.Append($"#  {singer.Key} -> {singer.Value}\n");
                }
            }
            Console.WriteLine(venueSingerSB);
        }
    }
}
