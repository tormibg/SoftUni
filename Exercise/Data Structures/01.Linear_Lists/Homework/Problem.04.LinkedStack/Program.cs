using System;

public class LinkedStack<T>
{

	private class Node<T>
	{
		public readonly T Value;
		public Node<T> NextNode { get; set; }

		public Node(T value, Node<T> nextNode = null)
		{
			this.Value = value;
			this.NextNode = nextNode;
		}
	}
	private Node<T> firstNode;
	private int Count { get; set; }

	public void Push(T element)
	{
		Node<T> newNode = new Node<T>(element);
		if (this.Count == 0)
		{
			this.firstNode = newNode;
		}
		else
		{
			newNode.NextNode = this.firstNode;
			this.firstNode = newNode;
		}

		this.Count++;
	}

	public T Pop()
	{
		if (this.Count == 0)
		{
			throw new InvalidOperationException();
		}
		Node<T> currentNode = this.firstNode;
		this.firstNode = this.firstNode.NextNode;

		this.Count--;
		return currentNode.Value;
	}

	public T[] ToArray()
	{
		T[] newArr = new T[this.Count];
		Node<T> currentNode = this.firstNode;
		for (int i = 0; i < this.Count; i++)
		{
			newArr[i] = currentNode.Value;
			currentNode = currentNode.NextNode;
		}

		return newArr;
	}

}

internal static class Program
{
	private static void Main(string[] args)
	{
		var test = new LinkedStack<int>();
		test.Push(1);
		test.Push(2);
		test.Push(3);
		test.Push(4);
		Console.WriteLine(string.Join(", ", test.ToArray()));
		Console.WriteLine($"{test.Pop()}");
		Console.WriteLine(string.Join(", ", test.ToArray()));
	}
}

