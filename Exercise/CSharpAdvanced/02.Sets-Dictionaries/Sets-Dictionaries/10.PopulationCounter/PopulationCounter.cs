namespace _10.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PopulationCounter
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, uint>> countrysDictionary = new Dictionary<string, Dictionary<string, uint>>();

            while (true)
            {
                string[] inputArgs =
                Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string cityName = inputArgs[0];
                if (cityName == "report")
                {
                    break;
                }
                string countyName = inputArgs[1];
                uint population = uint.Parse(inputArgs[2]);
                if (!countrysDictionary.ContainsKey(countyName))
                {
                    countrysDictionary.Add(countyName, new Dictionary<string, uint>());
                }
                if (!countrysDictionary[countyName].ContainsKey(cityName))
                {
                    countrysDictionary[countyName].Add(cityName, population);
                }
            }
            var sortedCountry = countrysDictionary.OrderByDescending(x => x.Value.Sum(y => y.Value));
            foreach (var countryInfo in sortedCountry)
            {
                long totalCount = countryInfo.Value.Sum(x => x.Value);
                Console.WriteLine($"{countryInfo.Key} (total population: {totalCount})");
                var sortedCitys = countryInfo.Value.OrderByDescending(x => x.Value);
                foreach (var cityInfo in sortedCitys)
                {
                    Console.WriteLine($"=>{cityInfo.Key}: {cityInfo.Value}");
                }
            }
        }
    }
}
