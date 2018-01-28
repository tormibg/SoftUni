using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
	public class Node
	{
		public Node(T value)
		{
			this.Value = value;
		}

		public T Value { get; set; }
		public Node Next { get; set; }
	}
	public int Count { get; private set; }
	public Node Head { get; private set; }
	public Node Tail { get; private set; }

	public void AddFirst(T item)
	{
		Node old = this.Head;
		this.Head = new Node(item);
		this.Head.Next = old;
		if (this.IsEmpty())
		{
			this.Tail= this.Head;
		}
		this.Count++;
	}

	private bool IsEmpty()
	{
		if (this.Count != 0)
		{
			return false;
		}

		return true;
	}

	public void AddLast(T item)
	{
		Node old = this.Tail;
		this.Tail = new Node(item);
		if (this.IsEmpty())
		{
			this.Head = this.Tail;
		}
		else
		{
			old.Next = this.Tail;
		}

		this.Count++;
	}

	public T RemoveFirst()
	{
		if (this.IsEmpty())
		{
			throw new InvalidOperationException();
		}

		T element = this.Head.Value;
		this.Head = this.Head.Next;
		this.Count--;
		if (this.IsEmpty())
		{
			this.Tail = null;
		}

		return element;
	}

	public T RemoveLast()
	{
		if (this.IsEmpty())
		{
			throw new InvalidOperationException();
		}

		T element = this.Tail.Value;
		if (this.Count == 1)
		{
			this.Head = this.Tail = null;
		}
		else
		{
			Node newTail = this.GetSecondLast();
			newTail.Next = null;
			this.Tail = newTail;
		}

		this.Count--;
		return element;
	}

	private Node GetSecondLast()
	{
		Node current = this.Head;
		while (true)
		{
			if (current.Next == this.Tail)
			{
				return current;
			}

			current = current.Next;
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		Node current = this.Head;
		while (current != null)
		{
			yield return current.Value;
			current = current.Next;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}
}
