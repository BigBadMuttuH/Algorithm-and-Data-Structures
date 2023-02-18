namespace Algorithm_and_Data_Structures
{
    class Program
    {
        public static void Main(String[] args)
        {
            Node<int> first = new Node<int>(5);
            Node<int> second = new Node<int>(1);

            first.Next = second;

            Node<int> third = new Node<int>(3);
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
}



