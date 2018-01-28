using System;

public class LinkedQueue<T>
{
	public int Count { get; set; }
	private QueueNode<T> Head { get; set; }
	private QueueNode<T> Tail { get; set; }

	private class QueueNode<T>
	{
		internal T Value { get; set; }
		internal QueueNode<T> NextNode { get; set; }
		internal QueueNode<T> PrevNode { get; set; }

		internal QueueNode(T value, QueueNode<T> nextNode = null, QueueNode<T> prevNode = null)
		{
			this.Value = value;
			this.NextNode = nextNode;
			this.PrevNode = prevNode;
		}
	}


	public void Enqueue(T element)
	{
		QueueNode<T> currentNode = new QueueNode<T>(element);
		if (this.Count == 0)
		{
			this.Head = this.Tail = currentNode;
		}
		else
		{
			this.Tail.NextNode = currentNode;
			currentNode.PrevNode = this.Tail;
			this.Tail = currentNode;
		}

		this.Count++;
	}

	public T Dequeue()
	{
		if (this.Count == 0)
		{
			throw new InvalidOperationException();
		}

		QueueNode<T> currentNode = this.Head;
		this.Head = this.Head.NextNode;
		this.Head.PrevNode = null;
		this.Count--;
		return currentNode.Value;
	}

	public T[] ToArray()
	{
		T[] newArr = new T[this.Count];
		QueueNode<T> currentNode = this.Head;
		int index = 0;
		while (currentNode != null)
		{
			newArr[index] = currentNode.Value;
			currentNode = currentNode.NextNode;
			index++;
		}

		return newArr;
	}
}


internal static class Program
{
	private static void Main(string[] args)
	{
		LinkedQueue<int> test = new LinkedQueue<int>();
		test.Enqueue(1);
		test.Enqueue(2);
		test.Enqueue(3);
		test.Enqueue(4);
		Console.WriteLine(string.Join(", ", test.ToArray()));
		Console.WriteLine(test.Dequeue());
		Console.WriteLine(string.Join(", ", test.ToArray()));
		Console.WriteLine(test.Dequeue());
		test.Enqueue(1);
		Console.WriteLine(string.Join(", ", test.ToArray()));
	}
}