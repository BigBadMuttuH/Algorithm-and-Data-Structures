namespace SortingAlgorithms
{
    class Program
    {
        public static void Main(string[] args)
        {
            int result1 = Sorting.IterativeFactorial(40);
            int result2 = Sorting.RecursiveFactorial(40);
            Console.WriteLine($"{result1} {result2}");
        }
    }
}