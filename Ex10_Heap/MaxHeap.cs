namespace Algorithm_and_Data_Structures;

public class MaxHeap<T> where T : IComparable<T>
{
    private const int DefaultCapacity = 4;
    private T[] _heap;

    public MaxHeap() : this(DefaultCapacity)
    {
    }

    private MaxHeap(int capacity)
    {
        _heap = new T[capacity];
    }

    public int Count { get; private set; }
    public bool IsFull => Count == _heap.Length;
    public bool IsEmpty => Count == 0;

    public void Insert(T value)
    {
        if (IsFull)
        {
            var newHeap = new T[_heap.Length * 2];
            Array.Copy(_heap, 0, newHeap, 0, _heap.Length);
            _heap = newHeap;
        }

        _heap[Count] = value;

        //восстанавливаем пирамиду.
        Swim(Count);
        Count++;
    }

    private void Swim(int indexOfSwimmingItem)
    {
        var newValue = _heap[indexOfSwimmingItem];
        // смещаем родительские элементы вниз
        while (indexOfSwimmingItem > 0 && IsParentLess(indexOfSwimmingItem))
        {
            _heap[indexOfSwimmingItem] = GetParent(indexOfSwimmingItem);
            indexOfSwimmingItem = ParentIndex(indexOfSwimmingItem);
        }

        // вставка в корректное место
        _heap[indexOfSwimmingItem] = newValue;

        bool IsParentLess(int swimmingItemIndex)
        {
            return newValue.CompareTo(GetParent(swimmingItemIndex)) > 0;
        }
    }

    private T GetParent(int index)
    {
        return _heap[ParentIndex(index)];
    }

    private int ParentIndex(int index)
    {
        return (index - 1) / 2;
    }

    // Возвращаем все значения
    public IEnumerable<T> Values()
    {
        for (var index = 0; index < Count; index++) yield return _heap[index];
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException();
        return _heap[0];
    }

    public T Remove()
    {
        return Remove(0);
    }

    public T Remove(int index)
    {
        if (IsEmpty)
            throw new InvalidOperationException();

        var removedValue = _heap[index];
        _heap[index] = _heap[Count - 1];
        // если корневой узел или если замещающее значение меньше родительского
        if (index == 0 || _heap[index].CompareTo(GetParent(index)) < 0)
            Sink(index, Count - 1);
        else
            Swim(index);

        Count--;
        return removedValue;
    }

    private void Sink(int indexOfSinkingItem, int lastHeapIndex)
    {
        while (indexOfSinkingItem <= lastHeapIndex)
        {
            var leftChildIndex = LeftChildIndex(indexOfSinkingItem);
            var rightChildIndex = RightChildIndex(indexOfSinkingItem);

            // проверим не заходим ли мы за границы
            if (leftChildIndex > lastHeapIndex)
                break;

            var childIndexToSwap = GetChildIndexToSwap(leftChildIndex, rightChildIndex);

            if (SinkingIsLessThan(childIndexToSwap))
                Exchange(indexOfSinkingItem, childIndexToSwap);
            else
                break;

            indexOfSinkingItem = childIndexToSwap;
        }

        bool SinkingIsLessThan(int childToSwap)
        {
            return _heap[indexOfSinkingItem].CompareTo(_heap[childToSwap]) < 0;
        }

        int GetChildIndexToSwap(int leftChildIndex, int rightChildIndex)
        {
            int childToSwap;
            if (rightChildIndex > lastHeapIndex)
            {
                childToSwap = leftChildIndex;
            }
            else
            {
                var compareTo = _heap[leftChildIndex].CompareTo(_heap[rightChildIndex]);
                childToSwap = compareTo > 0 ? leftChildIndex : rightChildIndex;
            }

            // возвращавшем индекс
            return childToSwap;
        }
    }

    private void Exchange(int leftIndex, int rightIndex)
    {
        var tmp = _heap[leftIndex];
        _heap[leftIndex] = _heap[rightIndex];
        _heap[rightIndex] = tmp;
    }

    private int RightChildIndex(int parentIndex)
    {
        return 2 * parentIndex + 2;
    }

    private int LeftChildIndex(int parentIndex)
    {
        return 2 * parentIndex + 1;
    }

    public void Sort()
    {
        var lastHeapIndex = Count - 1;
        for (var i = 0; i < lastHeapIndex; i++)
        {
            // сдвигаем границы
            Exchange(0, lastHeapIndex - i);
            // вычитаем 1 т.к. в lastHeapIndex будет самое большое число
            Sink(0, lastHeapIndex - i - 1);
        }
    }
}