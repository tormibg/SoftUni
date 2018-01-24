using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem01.SumAndAverage
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> input = Console.ReadLine()
				?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
				.ToList();

			int sum = 0;
			double average = 0.00;

			if (input.Count > 0)
			{
				sum = input.Sum();
				average = input.Average();
			}

			Console.WriteLine($"Sum={sum}; Average={average:f2}");

		}
	}
}
