using System.Collections;

namespace Algorithm_and_Data_Structures;

public class LinkedStack<T> : IEnumerable<T>
{
    private readonly SinglyLinkedList<T> _list = new();
    public int Count => _list.Count;
    public bool IsEmpty => Count == 0;

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException();
        return _list.Head.Value;
    }

    public void Pop()
    {
        if (IsEmpty) throw new InvalidOperationException();
        _list.RemoveFirst();
    }

    public void Push(T item)
    {
        _list.AddFirst(item);
    }
}