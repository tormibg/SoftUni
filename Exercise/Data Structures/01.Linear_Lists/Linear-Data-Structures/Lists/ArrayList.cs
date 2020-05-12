using System;

namespace Lists
{
	public class ArrayList<T>
	{
		private const int InitialCapacity = 2;

		private T[] _items;

		public ArrayList()
		{
			this._items = new T[InitialCapacity];
		}

		public int Count { get; private set; }

		public T this[int index]
		{
			get
			{
				if (index >= this.Count)
				{
					throw new ArgumentOutOfRangeException();
				}

				return this._items[index];
			}

			set
			{
				if (index >= this.Count)
				{
					throw new ArgumentOutOfRangeException();
				}

				this._items[index] = value;
			}
		}

		public void Add(T item)
		{
			if (this.Count == this._items.Length)
			{
				this.Resize();
			}

			this._items[this.Count++] = item;
		}

		private void Resize()
		{
			T[] copy = new T[this._items.Length * 2];
			for (int i = 0; i < this._items.Length; i++)
			{
				copy[i] = this._items[i];
			}

			this._items = copy;
		}

		public T RemoveAt(int index)
		{
			if (index >= this.Count)
			{
				throw new ArgumentOutOfRangeException();
			}

			T element = this._items[index];
			this._items[index] = default(T);
			this.Shift(index);
			this.Count--;

			if (this.Count <= this._items.Length / 4)
			{
				this.Shring();
			}

			return element;
		}

		private void Shring()
		{
			T[] copy = new T[this._items.Length / 2];
			for (int i = 0; i < this.Count; i++)
			{
				copy[i] = this._items[i];
			}

			this._items = copy;
		}

		private void Shift(int index)
		{
			for (int i = index; i < this.Count; i++)
			{
				this._items[i] = this._items[i + 1];
			}
		}
	}
}
