using System.Collections;

namespace Algorithm_and_Data_Structures;

public class CircularQueue<T> : IEnumerable<T>
{
    private int _head;
    private T[] _queue;
    private int _tail;

    public CircularQueue()
    {
        const int defultCapacity = 4;
        _queue = new T[defultCapacity];
    }

    public CircularQueue(int capacity)
    {
        _queue = new T[capacity];
    }

    public int Count => _head <= _tail
        ? _tail - _head
        : _tail - _head + _queue.Length;

    public bool IsEmpty => Count == 0;

    public int Capacity => _queue.Length;

    public IEnumerator<T> GetEnumerator()
    {
        if (_head <= _tail)
        {
            for (var i = _head; i < _tail; i++) yield return _queue[i];
        }
        else
        {
            for (var i = _head; i < _queue.Length; i++) yield return _queue[i];
            for (var i = 0; i < _tail; i++) yield return _queue[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    public void Enqueu(T item)
    {
        if (Count == _queue.Length - 1)
        {
            var countPriorResize = Count;
            var newArray = new T[2 * _queue.Length];

            Array.Copy(_queue, _head, newArray, 0, _queue.Length - _head);
            Array.Copy(_queue, 0, newArray, _queue.Length - _head, _tail);

            _queue = newArray;

            _head = 0;
            _tail = countPriorResize;
        }

        _queue[_tail] = item;
        if (_tail < _queue.Length - 1)
            _tail++;
        else
            _tail = 0;
    }

    public void Dequeue()
    {
        if (IsEmpty)
            throw new InvalidOperationException();

        _queue[_head++] = default;
        if (IsEmpty)
            _head = _tail = 0;
        else if (_head == _queue.Length) _head = 0;
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException();
        return _queue[_head];
    }
}