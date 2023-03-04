using System.Runtime.InteropServices.ComTypes;

namespace Algorithm_and_Data_Structures;

public class BinarySearchSt<TKey, TValue>
{
    private const int DefaultCapacity = 4;

    private readonly IComparer<TKey> _comparer;
    // один массив для хранения ключей, другой для хранения значений
    private TKey[] _keys;
    private TValue[] _values;
    public int Count { get; private set; }
    public int Capacity => _keys.Length;
    public bool IsEmpty => Count == 0;

    public BinarySearchSt(int capacity, IComparer<TKey> comparer)
    {
        _keys = new TKey[capacity];
        _values = new TValue[capacity];
        _comparer = comparer ?? throw new ArgumentNullException("Comparer can`t be null.");
    }

    public BinarySearchSt(int capacity) : this(capacity, Comparer<TKey>.Default)
    {
    }

    public BinarySearchSt() : this(DefaultCapacity)
    {
    }

    // метод определения ранга
    public int Rank(TKey key)
    {
        var low = 0;
        // вычитаем 1, чтобы при запросе ключа не уйти за границы массива
        var high = Count - 1;

        while (low <= high)
        {
            var mid = low + (high - low) / 2;
            var cmp = _comparer.Compare(key, _keys[mid]);
            if (cmp <= 0)
                high = mid - 1;
            else if (cmp > 0)
                low = mid + 1;
            else
                return mid;
        }

        return low;
    }

    public TValue GetValueOrDefault(TKey key)
    {
        if (IsEmpty)
            return default;

        var rank = Rank(key);
        if (rank < Count && _comparer.Compare(_keys[rank], key) == 0) return _values[rank];

        return default;
    }

    public void Add(TKey key, TValue value)
    {
        if (key == null)
            throw new ArgumentNullException("key can`t be null");

        var rank = Rank(key);
        if (rank < Count && _comparer.Compare(_keys[rank], key) == 0)
        {
            _values[rank] = value;
            return;
        }

        if (Count == Capacity) Resize(Capacity * 2);

        for (var j = Count; j > rank; j--)
        {
            _keys[j] = _keys[j - 1];
            _values[j] = _values[j - 1];
        }

        _keys[rank] = key;
        _values[rank] = value;

        Count++;
    }

    public void Remove(TKey key)
    {
        if (key == null)
            throw new ArgumentNullException("key can`t be null");

        if (IsEmpty) return;

        var r = Rank(key);
        if (r == Count || _comparer.Compare(_keys[r], key) != 0)
            return;

        for (var j = r; j < Count - 1; j++)
        {
            _keys[j] = _keys[j + 1];
            _values[j] = _values[j + 1];
        }

        Count--;
        _keys[Count] = default(TKey);
        _values[Count] = default(TValue);

        // resize if 1/4 full
        // if (Count > 0 && Count == keys.Length / 4) Resize(_keys.Length / 2 );
    }

    public bool Contains(TKey key)
    {
        int r = Rank(key);
        if (r < Count && _comparer.Compare(_keys[r], key) == 0)
            return true;
        return false;
    }

    public IEnumerable<TKey> Keys()
    {
        foreach (var key in _keys)
        {
            yield return key;
        }
    }

    private void Resize(int capacity)
    {
        var keysTmp = new TKey[capacity];
        var valuesTmp = new TValue[capacity];

        for (var i = 0; i < Count; i++)
        {
            keysTmp[i] = _keys[i];
            valuesTmp[i] = _values[i];
        }

        _values = valuesTmp;
        _keys = keysTmp;
    }

    public TKey Min()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Table is empty");
        return _keys[0];
    }

    public TKey Max()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Table is empty");
        return _keys[Count - 1];
    }

    public void RemoveMin()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Table is empty");
        Remove(Min());
    }
    public void RemoveMax()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Table is empty");
        Remove(Max());
    }
    public TKey Select(int index)
    {
        if(index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException("Can't select since index is out of range");
        return _keys[index];
    }

    public TKey Ceiling(TKey key)
    {
        if(key == null)
            throw new ArgumentNullException("Argument to ceiling() in null");

        int r = Rank(key);
        if (r == Count)
            return default(TKey);
        else
            return _keys[r];
    }

    public TKey Floor(TKey key)
    {
        if (key == null)
            throw new ArgumentNullException("Argumrnt to Floor() is null");

        int r = Rank(key);
        if (r < Count && _comparer.Compare(_keys[r], key) == 0)
            return _keys[r];
        if (r == 0)
            return default(TKey);
        else
            return _keys[r - 1];
    }

    public IEnumerable<TKey> Range(TKey left, TKey right)
    {
        var q = new LinkedQueue<TKey>();
        int low = Rank(left);
        int high = Rank(right);

        for (int i = low; i < high; i++)
        {
            q.Enqueu(_keys[i]);
        }
        if(Contains(right))
            q.Enqueu(_keys[Rank(right)]);

        return q;
    }
}