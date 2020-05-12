using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{

	private Node root;

	private class Node
	{
		internal Node(T value)
		{
			this.Value = value;
			this.Left = null;
			this.Right = null;
		}

		public T Value { get; set; }
		public Node Left { get; set; }
		public Node Right { get; set; }
	}

	public BinarySearchTree()
	{
		this.root = null;
	}

	private BinarySearchTree(Node current)
	{
		this.Copy(current);
	}

	private void Copy(Node current)
	{
		if (current == null)
		{
			return;
		}

		this.Insert(current.Value);
		this.Copy(current.Left);
		this.Copy(current.Right);
	}


	public void Insert(T value)
	{

		this.root = this.Insert(root, value);

	}

	private Node Insert(Node node, T value)
	{
		if (node == null)
		{
			return new Node(value);
		}

		int compare = node.Value.CompareTo(value);

		if (compare > 0)
		{
			node.Left = this.Insert(node.Left, value);
		}
		else if (compare < 0)
		{
			node.Right = this.Insert(node.Right, value);
		}


		return node;
	}

	public bool Contains(T value)
	{
		Node current = this.root;
		while (current != null)
		{
			int compare = current.Value.CompareTo(value);
			if (compare > 0)
			{
				current = current.Left;
			}
			else if (compare < 0)
			{
				current = current.Right;
			}
			else
			{
				return true;
			}
		}

		return false;
	}

	public void DeleteMin()
	{
		if (this.root == null)
		{
			return;
		}

		Node parent = null;
		Node current = this.root;
		while (current.Left != null)
		{
			parent = current;
			current = current.Left;
		}

		if (parent == null)
		{
			this.root = null;
		}
		else
		{
			parent.Left = current.Right;
		}
	}

	public BinarySearchTree<T> Search(T item)
	{
		Node current = this.root;
		while (current != null)
		{
			int compare = current.Value.CompareTo(item);
			if (compare > 0)
			{
				current = current.Left;
			}
			else if (compare < 0)
			{
				current = current.Right;
			}
			else
			{
				return new BinarySearchTree<T>(current);
			}
		}

		return null;
	}

	public IEnumerable<T> Range(T startRange, T endRange)
	{
		Queue<T> queue = new Queue<T>();
		this.Range(this.root, queue, startRange, endRange);
		return queue;
	}

	private void Range(Node node, Queue<T> queue, T startRange, T endRange)
	{
		if (node == null)
		{
			return;
		}

		int nodeInLowerRange = node.Value.CompareTo(startRange);
		int nodeInHigherRange = node.Value.CompareTo(endRange);

		if (nodeInLowerRange > 0)
		{
			this.Range(node.Left, queue, startRange, endRange);
		}
		if (nodeInLowerRange >= 0 && nodeInHigherRange <= 0)
		{
			queue.Enqueue(node.Value);
		}

		if (nodeInHigherRange < 0)
		{
			this.Range(node.Right, queue, startRange, endRange);
		}

	}

	public void EachInOrder(Action<T> action)
	{
		this.EachInOrder(this.root, action);
	}

	private void EachInOrder(Node node, Action<T> action)
	{
		if (node == null)
		{
			return;
		}
		this.EachInOrder(node.Left, action);
		action(node.Value);
		this.EachInOrder(node.Right, action);
	}
}

public class Launcher
{
	public static void Main(string[] args)
	{
		BinarySearchTree<int> bst = new BinarySearchTree<int>();

		bst.Insert(2);
		bst.Insert(10);
		bst.Insert(5);
		bst.Insert(6);
	}
}
