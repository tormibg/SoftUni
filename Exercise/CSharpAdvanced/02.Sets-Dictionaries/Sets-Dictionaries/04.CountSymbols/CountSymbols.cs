namespace _04.CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSymbols
    {
        public static void Main()
        {
            string inputStr = Console.ReadLine();
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            for (int i = 0; i < inputStr.Length; i++)
            {
                char currChar = inputStr[i];
                if (!charCount.ContainsKey(currChar))
                {
                    charCount.Add(currChar, 0);
                }
                charCount[currChar]++;
            }
            foreach (KeyValuePair<char, int> keyValuePair in charCount.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value} time/s");
            }
        }
    }
}
