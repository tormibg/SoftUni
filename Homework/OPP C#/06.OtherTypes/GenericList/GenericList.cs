using System;
using System.Text;
using GenericList;

 [Version(1, 0)]
public class GenericList<T> where T : IComparable<T>
{
    private const byte Capacity = 16;

    private T[] array;
    private int count = 0;

    public GenericList(int capacity = Capacity)
    {
     
        if (capacity == 0)
        {
            throw new ArgumentOutOfRangeException("GenericList can not have a zero capacity!");
        }
        this.array = new T[Capacity];
    }

    public T this[int index]
    {
        get
        {
            this.IsIndexOk(index);
            T value = array[index];
            return value;
        }
    }

    // ADD
    public void Add(T value)
    {
        if (this.count == this.array.Length)
        {
            DoubleArray();
        }

        this.array[this.count] = value;
        this.count++;
    }

    private void DoubleArray()
    {
        T[] newList = new T[this.array.Length * 2];
        for (int i = 0; i < this.count; i++)
        {
            newList[i] = this.array[i];
        }

        this.array = newList;
    }

    public void RemoveAt(int index)
    {
        T[] newList = new T[this.array.Length];
        for (int i = 0, pos = 0; i < this.count; i++, pos++)
        {
            if (i != index)
            {
                newList[pos] = this.array[i];
                continue;
            }

            pos--;
        }

        this.array = newList;
        this.count--;
    }

    public void InsertAt(int index, T value)
    {
        if (this.count == this.array.Length)
        {
            this.DoubleArray();
        }
        else if (index >= this.count)
        {
            this.Add(value);
        }
        else
        {
            for (int i = count; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }

            this.count++;
            this.array[index] = value;
        }
    }

    public void Clear()
    {
        this.array = new T[this.array.Length];
        this.count = 0;
    }

    public T Max()
    {
        var max = this.array[0];

        for (int i = 1; i < this.count; i++)
        {
            if (max.CompareTo(this.array[i]) < 0)
            {
                max = this.array[i];
            }
        }

        return max;
    }

    public T Min()
    {
        var min = this.array[0];

        for (int i = 1; i < this.count; i++)
        {
            if (min.CompareTo(this.array[i]) > 0)
            {
                min = this.array[i];
            }
        }

        return min;
    }

    public int? FindElementIndex(T element)
    {
        for (int i = 0; i < this.count; i++)
        {
            if (this.array[i].Equals(element))
            {
                return i;
            }
        }

        return null;
    }

    public bool Countains(T element)
    {
        for (int i = 0; i < this.count; i++)
        {
            if (this.array[i].Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < this.count; i++)
        {
            result.AppendFormat("{0}: {1}\n", i, this.array[i]);
        }

        return result.ToString();
    }

    private void IsIndexOk(int index)
    {
        if (index < 0 || index >= this.count)
        {
            throw new IndexOutOfRangeException("Index out of range.");
        }
    }
}