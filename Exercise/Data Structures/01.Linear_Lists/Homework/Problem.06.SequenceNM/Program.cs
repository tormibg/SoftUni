using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem._06.SequenceNM
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] inpInts = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int start = inpInts[0];
			int end = inpInts[1];
			if (end < start)
			{
				return;
			}

			Queue<Item> queue = new Queue<Item>();
			queue.Enqueue(new Item(start));
			while (queue.Count > 0)
			{
				Item currentItem = queue.Dequeue();
				if (currentItem.Value == end)
				{
					PrintSequenece(currentItem);
					return;
				}

				if (currentItem.Value > end)
				{
					continue;
				}
				queue.Enqueue(new Item(currentItem.Value + 1, currentItem));
				queue.Enqueue(new Item(currentItem.Value + 2, currentItem));
				queue.Enqueue(new Item(currentItem.Value * 2, currentItem));
			}
		}

		private static void PrintSequenece(Item itemStart)
		{
			LinkedList<int> list = new LinkedList<int>();
			Item currentItem = itemStart;
			while (currentItem != null)
			{
				list.AddFirst(currentItem.Value);
				currentItem = currentItem.Prev;
			}

			Console.WriteLine(String.Join(" -> ", list));
		}

		private class Item
		{
			internal Item Prev { get; set; }
			internal int Value { get; set; }

			internal Item(int value, Item prev = null)
			{
				this.Value = value;
				this.Prev = prev;
			}
		}
	}
}
