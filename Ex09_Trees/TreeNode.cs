namespace Algorithm_and_Data_Structures;

public class TreeNode<T> where T : IComparable<T>
{
    public TreeNode(T value)
    {
        Value = value;
    }

    public T Value { get; set; }
    public TreeNode<T> Left { get; set; }
    public TreeNode<T> Right { get; set; }

    public void Insert(T newValue)
    {
        var compare = newValue.CompareTo(Value);

        if (compare == 0) return;

        if (compare < 0)
        {
            if (Left == null)
                Left = new TreeNode<T>(newValue);
            else
                Left.Insert(newValue);
        }
        else
        {
            if (Right == null)
                Right = new TreeNode<T>(newValue);
            else
                Right.Insert(newValue);
        }
    }

    public TreeNode<T> Get(T value)
    {
        var compare = value.CompareTo(Value);

        if (compare == 0) return this;

        if (compare < 0)
        {
            if (Left != null)
                return Left.Get(value);
        }
        else
        {
            if (Right != null)
                return Right.Get(value);
        }

        return null;
    }

    public IEnumerable<T> TraversInOrder()
    {
        var list = new List<T>();
        InnerTravers(list);
        return list;
    }

    private void InnerTravers(List<T> list)
    {
        if (Left != null)
            Left.InnerTravers(list);

        list.Add(Value);

        if (Right != null)
            Right.InnerTravers(list);
    }

    public T Min()
    {
        if (Left != null)
            return Left.Min();
        return Value;
    }

    public T Max()
    {
        if (Right != null)
            return Right.Max();
        return Value;
    }
}