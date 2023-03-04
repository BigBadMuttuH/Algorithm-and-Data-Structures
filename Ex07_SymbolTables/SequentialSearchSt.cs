namespace Algorithm_and_Data_Structures;

public class SequentialSearchSt<TKey, TValue>
{
    private class Node
    {
        public TKey Key { get; }
        public TValue Value { get; set; }
        public Node Next { get; set; }

        public Node(TKey key, TValue value, Node next)
        {
            Key = key;
            Value = value;
            Next = next;
        }
    }

    private Node _first;
    private readonly IEqualityComparer<TKey> _comparer;

    public int Count { get; private set; }

    public SequentialSearchSt()
    {
        _comparer = EqualityComparer<TKey>.Default;
    }

    public SequentialSearchSt(IEqualityComparer<TKey> comparer)
    {
        _comparer = comparer ?? throw new ArgumentNullException();
    }
    
    public bool TryGet(TKey key, out TValue val)
    {
        for (Node x = _first; x != null; x = x.Next)
        {
            if (_comparer.Equals(key, x.Key))
            {
                val = x.Value;
                return true;
            }
        }
        val = default(TValue);
        return false;
    }

    public void Add(TKey key, TValue val)
    {
        if (key == null)
            throw new ArgumentNullException("key can`t be null");

        for (Node x = _first; x != null; x = x.Next)
        {
            if (_comparer.Equals(key, x.Key))
            {
                x.Value = val;
                return;
            }
        }

        _first = new Node(key, val, _first);
        Count++;
    }

    public bool Contains(TKey key)
    {
        for (Node x = _first; x != null; x = x.Next)
        {
            if (_comparer.Equals(key, x.Key))
            {
                return true;
            }
        }

        return false;
    }
    public IEnumerable<TKey> Keys()
    {
        for (Node x = _first; x != null; x = x.Next)
        {
            yield return x.Key;
        }
    }
    
    public bool Remove(TKey key)
    {
        // Null key is not allowed
        if (key == null)
            throw new ArgumentNullException("Key can`t be null.");
        // Counter should be adjusted properly
        // It should remove a key - value pair entirely
        // It should return false if the requested key was not found, otherwise true;

        if (Count == 1 && _comparer.Equals(_first.Key, key))
        {
            _first = null;
            Count--;
            return true;
        }

        Node prev = null;
        Node cur = _first;

        while (cur != null)
        {

            if (_comparer.Equals(cur.Key, key))
            {
                if (prev == null)
                {
                    _first = cur.Next;
                }
                else
                {
                    prev.Next = cur.Next;
                }

                Count--;
                return true;
            }

            prev = cur;
            cur = cur.Next;
        }

        return false;
    }
}