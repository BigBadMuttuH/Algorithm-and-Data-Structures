namespace Algorithm_and_Data_Structures;

public class Bst<T> where T : IComparable<T>
{
    private TreeNode<T> _root;

    public void Remove(T value)
    {
        // присваиваем руту новый узел
        _root = Remove(_root, value);
    }

    public TreeNode<T> Remove(TreeNode<T> subtreeRoot, T value)
    {
        // выход из рекурсии
        if (subtreeRoot == null)
            return null;
        var compareTo = value.CompareTo(subtreeRoot.Value);
        if (compareTo < 0)
        {
            subtreeRoot.Left = Remove(subtreeRoot.Left, value);
        }
        else if (compareTo > 0)
        {
            subtreeRoot.Right = Remove(subtreeRoot.Right, value);
        }
        // нашли то, что искали
        else
        {
            if (subtreeRoot.Left == null) return subtreeRoot.Right;
            if (subtreeRoot.Right == null) return subtreeRoot.Left;

            subtreeRoot.Value = subtreeRoot.Right.Min();
            subtreeRoot.Right = Remove(subtreeRoot.Right, subtreeRoot.Value);
        }

        return subtreeRoot;
    }

    public TreeNode<T> Get(T value)
    {
        return _root?.Get(value);
    }

    public T Min()
    {
        if (_root == null)
            throw new InvalidOperationException("Empty tree.");
        return _root.Min();
    }

    public T Max()
    {
        if (_root == null)
            throw new InvalidOperationException("Empty tree.");
        return _root.Max();
    }

    public void Insert(T value)
    {
        if (_root == null)
            _root = new TreeNode<T>(value);
        else
            _root.Insert(value);
    }

    public IEnumerable<T> TraversInOrder()
    {
        if (_root != null)
            return _root.TraversInOrder();

        return Enumerable.Empty<T>();
    }
}