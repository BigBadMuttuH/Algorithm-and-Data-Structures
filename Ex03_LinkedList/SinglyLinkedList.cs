using System.Collections;

namespace Algorithm_and_Data_Structures;

public class SinglyLinkedList<T> : IEnumerable<T>
{
    public Node<T> Head { get; private set; }
    public Node<T> Tail { get; private set; }

    public int Count { get; private set; }

    public bool IsEmpty => Count == 0;

    public IEnumerator<T> GetEnumerator()
    {
        var current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }


    public void AddFirst(T value)
    {
        AddFirst(new Node<T>(value));
    }

    private void AddFirst(Node<T> node)
    {
        // Save off the current head
        var tmp = Head;
        Head = node;
        // Shifting the former head
        Head.Next = tmp;

        Count++;

        if (Count == 1) Tail = Head;
    }

    public void AddLast(T value)
    {
        AddLast(new Node<T>(value));
    }

    private void AddLast(Node<T> node)
    {
        if (IsEmpty)
            Head = node;
        else
            Tail.Next = node;
        Tail = node;
        Count++;
    }

    public void RemoveFirst()
    {
        if (IsEmpty)
            throw new InvalidOperationException();

        Head = Head.Next;

        if (Count == 1)
            Tail = null;

        Count--;
    }

    public void RemoveLast()
    {
        if (IsEmpty)
            throw new InvalidOperationException();

        if (Count == 1)
        {
            Head = Tail = null;
        }
        else
        {
            // find the penultimate node
            var current = Head;
            while (current.Next != Tail) current = current.Next;
            current.Next = null;
            Tail = current;
        }

        Count--;
    }
}