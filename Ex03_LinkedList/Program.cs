namespace Algorithm_and_Data_Structures;

internal class Program
{
    public static void Main(string[] args)
    {
        var first = new Node<int>(5);
        var second = new Node<int>(1);

        first.Next = second;

        var third = new Node<int>(3);
        second.Next = third;

        PrinntOutLinkedList(first);
    }

    private static void PrinntOutLinkedList(Node<int> node)
    {
        while (node != null)
        {
            Console.WriteLine(node.Value);
            node = node.Next;
        }
    }
}