using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem._02.SortWords
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> input = Console.ReadLine()?.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x.ToLower()).ToList();

			Console.WriteLine(string.Join(" ",input));
		}
	}
}
