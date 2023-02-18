namespace Algorithm_and_Data_Structures
{
    class Program
    {
        public static void Main(string[] args)
        {
            var stack = new ArrayStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Console.WriteLine($"Should print out 4:{stack.Peek()}");

            stack.Pop();

            Console.WriteLine($"Should print out 3:{stack.Peek()}");

            Console.WriteLine("Iterate over the stack.");

            foreach (var cur in stack)
            {
                Console.WriteLine(cur);
            }

            var lstack = new ArrayStack<int>();
            lstack.Push(1);
            lstack.Push(2);
            lstack.Push(3);
            lstack.Push(4);

            Console.WriteLine($"Should print out 4:{lstack.Peek()}");

            lstack.Pop();

            Console.WriteLine($"Should print out 3:{lstack.Peek()}");

            Console.WriteLine("Iterate over the stack.");

            foreach (var cur in lstack)
            {
                Console.WriteLine(cur);
            }
        }
    }
}