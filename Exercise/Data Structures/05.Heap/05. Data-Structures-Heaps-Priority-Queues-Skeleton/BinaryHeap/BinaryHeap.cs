using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
	private List<T> heap;

	public BinaryHeap()
	{
		this.heap = new List<T>();
	}

	public int Count => this.heap.Count;

	public void Insert(T item)
	{
		this.heap.Add(item);
		this.HeapifyUp(this.heap.Count - 1);
	}

	private void HeapifyUp(int index)
	{
		if (index > 0 && IsLess(Parent(index), index))
		{
			this.Swap(index, Parent(index));
			this.HeapifyUp(Parent(index));
		}
	}

	private void Swap(int index, int parent)
	{
		T temp = this.heap[parent];
		this.heap[parent] = this.heap[index];
		this.heap[index] = temp;
	}

	private bool IsLess(int parent, int index)
	{
		bool result = false;
		int compare = this.heap[parent].CompareTo(this.heap[index]);
		if (compare <= 0)
		{
			result = true;
		}

		return result;
	}

	private int Parent(int index)
	{
		return (index - 1) / 2;
	}

	public T Peek()
	{
		if (this.heap.Count <= 0)
		{
			throw new InvalidOperationException();
		}

		return this.heap[0];
	}

	public T Pull()
	{
		if (this.heap.Count <= 0)
		{
			throw new InvalidOperationException();
		}

		T element = this.heap[0];
		this.Swap(0,this.Count-1);
		this.heap.RemoveAt(this.Count-1);
		this.HeapifyDown(0);

		return element;
	}

	private void HeapifyDown(int index)
	{
		if (HasChild)
		{
			
		}
	}
}
