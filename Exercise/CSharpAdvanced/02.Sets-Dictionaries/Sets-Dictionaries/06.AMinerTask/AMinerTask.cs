namespace _06.AMinerTask
{
    using System;
    using System.Collections.Generic;

    public class AMinerTask
    {
        public static void Main()
        {
            Dictionary<string, int> reaourceQuantityDictionary = new Dictionary<string, int>();
            while (true)
            {
                string inputResource= Console.ReadLine();
                if (inputResource == "stop")
                {
                    break;
                }
                int inputQuantity = int.Parse(Console.ReadLine());
                AddResourceToDictionary(inputResource, inputQuantity, reaourceQuantityDictionary);
            }
            foreach (KeyValuePair<string, int> keyValuePair in reaourceQuantityDictionary)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
            }
        }

        private static void AddResourceToDictionary(string inputResource, int inputQuantity, Dictionary<string, int> reaourceQuantityDictionary)
        {
            if (!reaourceQuantityDictionary.ContainsKey(inputResource))
            {
                reaourceQuantityDictionary.Add(inputResource,0);
            }
            reaourceQuantityDictionary[inputResource] += inputQuantity;
        }
    }
}
