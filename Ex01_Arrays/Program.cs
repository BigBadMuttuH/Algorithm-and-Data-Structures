namespace Arrays;

internal class Program
{
    public static void Main(string[] args)
    {
        // JaggedArraysDemo();
        // Test1BasedArray();
        // ArraysDemo();

        IterateOver(new[] { 1, 2, 3 });
        Console.WriteLine();
    }

    // Object не используют, он тут для примера
    private static void ArrayTimeComplexity(object[] array)
    {
        // access by index O(1)
        Console.WriteLine(array[0]);

        var length = array.Length;
        var elementINeedToFind = new object();

        // searching for an element O(n)
        for (var i = 0; i < length; i++)
            if (array[i] == elementINeedToFind)
                Console.WriteLine("Exist/Found");

        // add to a full array
        var bigArray = new int[length * 2];
        Array.Copy(array, bigArray, length);
        bigArray[length + 1] = 10;

        // add to the end when there`s some space
        // O(1)
        array[length - 1] = 10;

        // O(1)
        array[6] = null;
    }

    // только для примера
    private static void RemoveAt(object[] array, int index)
    {
        var newArray = new object[array.Length - 1];
        Array.Copy(array, 0, newArray, 0, index);
        Array.Copy(array, index + 1, newArray, index, array.Length - 1 - index);
    }


    // массивы в памяти находятся непрерывно
    // пройдемся по элементам используя математику 
    private static unsafe void IterateOver(int[] array)
    {
        fixed (int* b = array)
        {
            // придется создавать еще одни, так как b фиксированный
            var p = b;
            for (var i = 0; i < array.Length; i++)
            {
                Console.WriteLine(*p);
                p++;
            }
        }
    }

    private static void ArraysDemo()
    {
        // обзор массивов
        int[] a1; // нулевая ссылка
        a1 = new int[5];
        var a2 = new int[5];
        var a3 = new int[5] { 1, 2, 3, 4, 5 };
        int[] a4 = { 1, 2, 3, 4, 5 };

        for (var i = 0; i < a3.Length; i++) Console.Write($"{a3[i]} ");
        Console.WriteLine();

        foreach (var el in a4) Console.Write($"{el} ");
        Console.WriteLine();

        // так на самом деле происходит:
        Array myArray1 = new int[5];
        var myArray2 = Array.CreateInstance(typeof(int), 5);
        myArray2.SetValue(1, 0);

        Console.Read();
    }

    private static void Test1BasedArray()
    {
        // массив может начинаться по индексу не только с 0, но и от туда, от куда захотим
        // вот так можно это сделать
        var myArray = Array.CreateInstance(typeof(int), new[] { 4 }, new[] { 1 });

        myArray.SetValue(2019, 1);
        myArray.SetValue(2020, 2);
        myArray.SetValue(2021, 3);
        myArray.SetValue(2022, 4);

        Console.WriteLine($"Starting index: {myArray.GetLowerBound(0)}");
        Console.WriteLine($"Starting index: {myArray.GetUpperBound(0)}");

        // Если мы не знаем границы, то может их вычислить.
        for (var i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++)
            Console.WriteLine($"{myArray.GetValue(i)} at index {i}");
    }

    private static void MultiDimArrays()
    {
        var r1 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
        int[,] r2 = { { 1, 2, 3 }, { 4, 5, 6 } };

        for (var i = 0; i < r2.GetLength(0); i++)
        {
            for (var j = 0; j < r1.GetLength(1); j++) Console.WriteLine($"{r2[i, j]}");
            Console.WriteLine();
        }
    }

    private static void JaggedArraysDemo()
    {
        var jaggedArray = new int[4][];
        jaggedArray[0] = new int[1];
        jaggedArray[1] = new int[3];
        jaggedArray[2] = new int[2];
        jaggedArray[3] = new int[4];

        Console.WriteLine("Enter the numbers for a jagged array");

        for (var i = 0; i < jaggedArray.Length; i++)
        for (var j = 0; j < jaggedArray[i].Length; j++)
        {
            var st = Console.ReadLine();
            jaggedArray[i][j] = int.Parse(st);
        }

        Console.WriteLine();
        for (var i = 0; i < jaggedArray.Length; i++)
        {
            for (var j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j]);
                Console.Write("\0");
            }

            Console.WriteLine();
        }
    }
}