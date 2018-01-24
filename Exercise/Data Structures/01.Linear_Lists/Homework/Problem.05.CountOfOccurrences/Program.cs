using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem._05.CountOfOccurrences
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> input = Console.ReadLine()
				?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse).ToList();

			Dictionary<int, int> occurrences = new Dictionary<int, int>();

			foreach (var i in input)
			{
				if (!occurrences.ContainsKey(i))
				{
					occurrences[i] = 0;
				}

				occurrences[i]++;
			}

			foreach (var keyValuePair in occurrences.OrderBy(o => o.Key))
			{
				Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value} times");
			}

		}
	}
}
