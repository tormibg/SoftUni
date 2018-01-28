using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem._01.ReverseNumbersWithAStack
{
	class Program
	{
		static void Main(string[] args)
		{
			var inputs = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
				.ToArray();
			Stack<int> intQueue = new Stack<int>(inputs.Length);
			foreach (int i in inputs)
			{
				intQueue.Push(i);
			}

			while (intQueue.Count != 0)
			{
				Console.Write($"{intQueue.Pop()} ");
			}

		}
	}
}
