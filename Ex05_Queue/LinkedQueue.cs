using System.Collections;

namespace Algorithm_and_Data_Structures;

public class LinkedQueue<T> : IEnumerable<T>
{
    private readonly SinglyLinkedList<T> _list = new();
    public int Capacity;
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

    public void Enqueu(T item)
    {
        _list.AddLast(item);
    }

    public void Decque()
    {
        _list.RemoveFirst();
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException();
        return _list.Head.Value;
    }
}