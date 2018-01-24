using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{

	private class ListNode<T>
	{
		internal T Value { get; private set; }
		public ListNode<T> NexNode { get; set; }
		public ListNode<T> PrevNode { get; set; }

		public ListNode(T value)
		{
			this.Value = value;
		}

	}

	private ListNode<T> head;

	private ListNode<T> tail;

	public int Count { get; private set; }

	public void AddFirst(T element)
	{
		if (this.Count == 0)
		{
			this.head = this.tail = new ListNode<T>(element);
		}
		else
		{
			var newHead = new ListNode<T>(element);
			newHead.NexNode = this.head;
			this.head.PrevNode = newHead;
			this.head = newHead;
		}

		this.Count++;
	}

	public void AddLast(T element)
	{
		if (this.Count == 0)
		{
			this.head = this.tail = new ListNode<T>(element);
		}
		else
		{
			var newTail = new ListNode<T>(element);
			newTail.PrevNode = this.tail;
			this.tail.NexNode = newTail;
			this.tail = newTail;
		}

		this.Count++;
	}

	public T RemoveFirst()
	{
		if (this.Count == 0)
		{
			throw new InvalidOperationException("Empty list");
		}

		var firstElemnt = this.head.Value;
		this.head = this.head.NexNode;
		if (this.head != null)
		{
			this.head.PrevNode = null;
		}
		else
		{
			this.tail = null;
		}

		this.Count--;
		return firstElemnt;
	}

	public T RemoveLast()
	{
		if (this.Count == 0)
		{
			throw new InvalidOperationException();
		}

		var lastNode = this.tail.Value;
		this.tail = this.tail.PrevNode;
		if (this.tail != null)
		{
			this.tail.NexNode = null;
		}
		else
		{
			this.head = null;
		}

		this.Count--;
		return lastNode;
	}

	public void ForEach(Action<T> action)
	{
		var currentNode = this.head;
		while (currentNode != null)
		{
			action(currentNode.Value);
			currentNode = currentNode.NexNode;
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		var currentNode = this.head;
		while (currentNode != null)
		{
			yield return currentNode.Value;
			currentNode = currentNode.NexNode;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	public T[] ToArray()
	{
		T[] arr = new T[this.Count];
		var index = 0;
		var currentNode = this.head;
		while (currentNode != null)
		{
			arr[index] = currentNode.Value;
			currentNode = currentNode.NexNode;
			index++;
		}

		return arr;
	}

}


class Example
{
	static void Main()
	{
		var list = new DoublyLinkedList<int>();

		list.ForEach(Console.WriteLine);
		Console.WriteLine("--------------------");

		list.AddLast(5);
		list.AddFirst(3);
		list.AddFirst(2);
		list.AddLast(10);
		Console.WriteLine("Count = {0}", list.Count);

		list.ForEach(Console.WriteLine);
		Console.WriteLine("--------------------");

		list.RemoveFirst();
		list.RemoveLast();
		list.RemoveFirst();

		list.ForEach(Console.WriteLine);
		Console.WriteLine("--------------------");

		list.RemoveLast();

		list.ForEach(Console.WriteLine);
		Console.WriteLine("--------------------");
	}
}
