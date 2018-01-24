using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem._04.RemoveOddOccurrences
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> input = Console.ReadLine()
				?.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
				.ToList();

			Dictionary<int, int> occurrences = new Dictionary<int, int>();

			foreach (int i in input)
			{
				if (!occurrences.ContainsKey(i))
				{
					occurrences[i] = 0;
				}

				occurrences[i]++;
			}

			foreach (int i in input)
			{
				if (occurrences[i] % 2 == 0)
				{
					Console.Write($"{i} ");
				}
			}
		}
	}
}
