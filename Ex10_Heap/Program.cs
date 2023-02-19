namespace Algorithm_and_Data_Structures
{
    partial class Program
    {
        public static void Main(string[] args)
        {
            var heap = new MaxHeap<int>();
            heap.Insert(24);
            heap.Insert(37);
            heap.Insert(17);
            heap.Insert(28);
            heap.Insert(31);
            heap.Insert(29);
            heap.Insert(15);
            heap.Insert(12);
            heap.Insert(20);

            heap.Sort();


          //Console.WriteLine(heap.Peek());
          //Console.WriteLine(heap.Remove());
          //Console.WriteLine(heap.Peek());
          //heap.Insert(40);
          //Console.WriteLine(heap.Peek());

            foreach (var val in heap.Values())
            {
                Console.Write($"{val} ");
            }
        }
    }
}