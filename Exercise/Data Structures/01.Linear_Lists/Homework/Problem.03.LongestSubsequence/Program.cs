using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem._03.LongestSubsequence
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> inputInts = Console.ReadLine()
				?.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse).ToList();

			List<int> newInts = new List<int>();
			newInts.Add(inputInts[0]);
			int number = newInts[0];
			List<int> maxSeq = new List<int>();
			List<int> curSeq = new List<int>();
			int curMaxNumber = number;
			int curIntSeq = 1;
			int maxIntSeq = 1;

			for (int i = 1; i < inputInts.Count; i++)
			{
				if (inputInts[i] == number)
				{
					curIntSeq++;
					if (curIntSeq > maxIntSeq)
					{
						maxIntSeq = curIntSeq;
						curMaxNumber = number;
					}
				}
				else
				{
					number = inputInts[i];
					curIntSeq = 1;
				}
			}

			for (int i = 0; i < maxIntSeq; i++)
			{
				Console.Write($"{curMaxNumber} ");
			}
		}
	}
}
