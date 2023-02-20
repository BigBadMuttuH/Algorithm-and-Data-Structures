using System.Collections;

namespace Algorithm_and_Data_Structures;

public class ArrayStack<T> : IEnumerable<T>
{
    private T[] _items;

    public ArrayStack()
    {
        const int defaultCapacity = 4;
        _items = new T[defaultCapacity];
    }

    public ArrayStack(int capacity)
    {
        _items = new T[capacity];
    }

    public bool IsEmpty => Count == 0;

    public int Count { get; private set; }

    public IEnumerator<T> GetEnumerator()
    {
        for (var i = Count - 1; i >= 0; i--) yield return _items[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException();
        return _items[Count - 1];
    }

    public void Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException();

        _items[--Count] = default;
    }

    public void Push(T item)
    {
        if (_items.Length == Count)
        {
            var largerArray = new T[Count * 2];
            Array.Copy(_items, largerArray, Count);

            _items = largerArray;
        }

        _items[Count++] = item;
    }
}