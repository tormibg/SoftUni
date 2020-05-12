using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem._02.CalculateSequenceWithAQueue
{
	class Program
	{
		static void Main(string[] args)
		{
			int input = int.Parse(Console.ReadLine());
			Queue<int> intQueue = new Queue<int>(50);
			intQueue.Enqueue(input);
			int numS = 0;
			int skipNum = 0;

			for (int i = 0; i < 49; i++)
			{
				switch (i % 3)
				{
					case 0:
						{
							numS = intQueue.ToArray().Skip(skipNum).Take(1).ToArray()[0];
							intQueue.Enqueue(numS + 1);
							skipNum++;
							break;
						}
					case 1:
						{
							intQueue.Enqueue(2 * numS + 1);
							break;
						}
					case 2:
						{
							intQueue.Enqueue(numS + 2);
							break;
						}
				}
			}

			Console.WriteLine(string.Join(", ", intQueue));
		}
	}
}
