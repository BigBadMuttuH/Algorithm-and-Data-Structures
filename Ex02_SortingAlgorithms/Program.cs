namespace SortingAlgorithms;

internal class Program
{
    public static void Main(string[] args)
    {
        var result1 = Sorting.IterativeFactorial(40);
        var result2 = Sorting.RecursiveFactorial(40);
        Console.WriteLine($"{result1} {result2}");
    }
}