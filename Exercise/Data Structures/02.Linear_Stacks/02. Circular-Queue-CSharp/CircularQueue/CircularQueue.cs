﻿using System;

public class CircularQueue<T>
{
	private const int DefaultCapacity = 4;
	private T[] elements;
	private int startIndex = 0;
	private int endindex = 0;
	public int Count { get; private set; }

	public CircularQueue(int capacity = DefaultCapacity)
	{
		this.elements = new T[capacity];
		this.Count = 0;
	}

	public void Enqueue(T element)
	{
		if (this.Count == this.elements.Length)
		{
			this.Grow();
		}

		this.elements[this.endindex] = element;
		this.endindex = (this.endindex + 1) % this.elements.Length;
		this.Count++;
	}

	private void Grow()
	{
		var newElements = new T[this.elements.Length * 2];
		this.CopyAllElements(newElements);
		this.elements = newElements;
		this.startIndex = 0;
		this.endindex = this.Count;
	}

	private void CopyAllElements(T[] newArray)
	{
		int sourceIndex = this.startIndex;
		int destinationIndex = 0;
		for (int i = 0; i < this.Count; i++)
		{
			newArray[destinationIndex] = this.elements[sourceIndex];
			sourceIndex = (sourceIndex + 1) % this.elements.Length;
			destinationIndex++;
		}
	}

	// Should throw InvalidOperationException if the queue is empty
	public T Dequeue()
	{
		if (this.Count == 0)
		{
			throw new InvalidOperationException();
		}

		T result = this.elements[this.startIndex];
		this.startIndex = (this.startIndex + 1) % this.elements.Length;
		this.Count--;
		return result;
	}

	public T[] ToArray()
	{
		T[] newArray = new T[this.Count];
		this.CopyAllElements(newArray);
		return newArray;
	}
}


public class Example
{
	public static void Main()
	{

		CircularQueue<int> queue = new CircularQueue<int>();

		queue.Enqueue(1);
		queue.Enqueue(2);
		queue.Enqueue(3);
		queue.Enqueue(4);
		queue.Enqueue(5);
		queue.Enqueue(6);

		Console.WriteLine("Count = {0}", queue.Count);
		Console.WriteLine(string.Join(", ", queue.ToArray()));
		Console.WriteLine("---------------------------");

		int first = queue.Dequeue();
		Console.WriteLine("First = {0}", first);
		Console.WriteLine("Count = {0}", queue.Count);
		Console.WriteLine(string.Join(", ", queue.ToArray()));
		Console.WriteLine("---------------------------");

		queue.Enqueue(-7);
		queue.Enqueue(-8);
		queue.Enqueue(-9);
		Console.WriteLine("Count = {0}", queue.Count);
		Console.WriteLine(string.Join(", ", queue.ToArray()));
		Console.WriteLine("---------------------------");

		first = queue.Dequeue();
		Console.WriteLine("First = {0}", first);
		Console.WriteLine("Count = {0}", queue.Count);
		Console.WriteLine(string.Join(", ", queue.ToArray()));
		Console.WriteLine("---------------------------");

		queue.Enqueue(-10);
		Console.WriteLine("Count = {0}", queue.Count);
		Console.WriteLine(string.Join(", ", queue.ToArray()));
		Console.WriteLine("---------------------------");

		first = queue.Dequeue();
		Console.WriteLine("First = {0}", first);
		Console.WriteLine("Count = {0}", queue.Count);
		Console.WriteLine(string.Join(", ", queue.ToArray()));
		Console.WriteLine("---------------------------");
	}
}
