using System;

public class ArrayStack<T>
{
	private T[] elements;
	public int Count { get; private set; }
	private const int InitialCapacity = 16;

	public ArrayStack(int capacity = InitialCapacity)
	{
		this.elements = new T[capacity];
		this.Count = 0;
	}

	public void Push(T element)
	{
		if (this.Count == this.elements.Length)
		{
			this.Grow();
		}
		this.elements[this.Count] = element;
		this.Count++;
	}

	public T Pop()
	{
		if (this.Count == 0)
		{
			throw new InvalidOperationException();
		}
		T element = this.elements[this.Count - 1];
		this.Count--;
		return element;
	}

	public T[] ToArray()
	{
		T[] newArray = new T[this.Count];
		for (int i = 0; i < this.Count; i++)
		{
			newArray[i] = this.elements[this.Count - i - 1];
		}
		return newArray;
	}

	private void Grow()
	{
		T[] newArray = new T[this.Count * 2];
		Array.Copy(elements, newArray, this.Count);
		this.elements = newArray;
	}
}

public static class Program
{
	static void Main(string[] args)
	{
		ArrayStack<int> arrayInt = new ArrayStack<int>();
		arrayInt.Push(2);
		arrayInt.Push(4);
		arrayInt.Push(5);

		int intt = arrayInt.Pop();
		Console.WriteLine($"{intt}");
		arrayInt.Push(10);
		var arr = arrayInt.ToArray();
		Console.WriteLine(string.Join(", ", arr));
	}
}