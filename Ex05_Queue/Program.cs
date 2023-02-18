namespace Algorithm_and_Data_Structures
{
    class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>(128);
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            Console.WriteLine($"Should print out 1:{q.Peek()}");
            q.Dequeue();    
            Console.WriteLine($"Should print out 2:{q.Peek()}");
            Console.WriteLine($"Contains 3? Answer:{q.Contains(3)}");
        }
    }
}
