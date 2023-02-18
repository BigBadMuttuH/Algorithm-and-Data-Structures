﻿using System.Collections;

namespace Algorithm_and_Data_Structures
{
    public class ArrayQueue<T> : IEnumerable<T>
    {
        private T[] _queue;
        private int _head;
        private int _tail;
        public int Count => _tail - _head;
        public bool IsEmpty => Count == 0;

        public double Capacity => _queue.Length;

        public ArrayQueue()
        {
            const int defultCapacity = 4;
            _queue = new T[defultCapacity];
        }
        public ArrayQueue(int capacity)
        {
            _queue = new T[capacity];
        }


        public void Enqueu(T item)
        {
            if (_queue.Length == _tail)
            {
                T[] lagerArray = new T[Count * 2];
                Array.Copy(_queue, lagerArray, Count);
                _queue = lagerArray;
            }
            _queue[_tail++] = item;
        }
        public void Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            _queue[_head++] = default(T);

            if (IsEmpty)
                _head = _tail = 0;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            return _queue[_head];
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _head; i < _tail; i++)
            {
                yield return _queue[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
