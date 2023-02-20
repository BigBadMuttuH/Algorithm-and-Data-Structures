namespace Algorithm_and_Data_Structures;

public class DoublyLinkedNode<T>
{
    public DoublyLinkedNode(T value)
    {
        Value = value;
    }

    public DoublyLinkedNode<T> Next { get; internal set; }
    public DoublyLinkedNode<T> Previous { get; internal set; }

    public T Value { get; set; }
}