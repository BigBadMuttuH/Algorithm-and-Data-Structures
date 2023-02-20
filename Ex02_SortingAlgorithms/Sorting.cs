namespace SortingAlgorithms;

public class Sorting
{
    // Swap
    private static void Swap(int[] arrya, int i, int j)
    {
        if (i == j) return;
        var temp = arrya[i];
        arrya[i] = arrya[j];
        arrya[j] = temp;
    }

    // BubbleSort (partIndex - стена) 
    public static void BubbleSort(int[] array)
    {
        for (var partIndex = array.Length - 1; partIndex > 0; partIndex--)
        for (var i = 0; i < partIndex; i++)
            if (array[i] > array[i + 1])
                Swap(array, i, i + 1);
    }

    // SelectionSort
    public static void SelectionSort(int[] array)
    {
        for (var partIndex = array.Length - 1; partIndex > 0; partIndex--)
        {
            var largestAt = 0;
            for (var i = 1; i <= partIndex; i++)
                if (array[i] > array[largestAt])
                    largestAt = i;
            Swap(array, largestAt, partIndex);
        }
    }

    //InsertingSort
    public static void InsertingSort(int[] array)
    {
        for (var partIndex = 1; partIndex < array.Length; partIndex++)
        {
            var curUnsorted = array[partIndex];
            var i = 0;
            for (i = partIndex; i > 0 && array[i - 1] > curUnsorted; i--) array[i] = array[i - 1];
            array[i] = curUnsorted;
        }
    }

    // ShellSort O(n^3/2)
    public static void ShellSort(int[] array)
    {
        var gap = 1;
        while (gap < array.Length / 3) gap = 3 * gap + 1;
        while (gap >= 1)
        {
            // InsertionSort
            for (var i = gap; i < array.Length; i++)
            for (var j = i; j >= gap && array[j] < array[j - gap]; j -= gap)
                Swap(array, j, j - gap);

            gap /= 3;
        }
    }

    // MergeSort
    public static void MergeSort(int[] array)
    {
        // вспомогательный массив
        var aux = new int[array.Length];

        Sort(0, array.Length - 1);

        void Sort(int low, int high)
        {
            if (high <= low) return;

            var mid = (high + low) / 2;
            Sort(low, mid);
            Sort(mid + 1, high);

            Merge(low, mid, high);
        }

        void Merge(int low, int mid, int high)
        {
            if (array[mid] <= array[mid + 1]) return; // оптимизация

            var i = low;
            var j = mid + 1;

            Array.Copy(array, low, aux, low, high - low + 1);

            for (var k = low; k <= high; k++)
                if (i > mid) array[k] = aux[j++];
                else if (j > high) array[k] = aux[i++];
                else if (aux[j] < aux[i])
                    array[k] = aux[j++];
                else
                    array[k] = aux[i++];
        }
    }

    // QuickSort
    public static void QuickSort(int[] array)
    {
        Sort(0, array.Length - 1);

        void Sort(int low, int high)
        {
            if (high <= low) return;
            var j = Partition(low, high);

            Sort(low, j - 1);
            Sort(j + 1, high);
        }

        int Partition(int low, int high)
        {
            var i = low;
            var j = high + 1;

            var pivot = array[low];
            while (true)
            {
                while (array[++i] < pivot)
                    if (i == high)
                        break;
                while (pivot < array[--j])
                    if (j == low)
                        break;
                if (i >= j) break;

                Swap(array, i, j);
            }

            Swap(array, low, j);
            return j;
        }
    }


    public static int IterativeFactorial(int number)
    {
        if (number == 0) return 1;
        var factorial = 1;

        for (var i = 1; i <= number; i++) factorial *= i;
        return factorial;
    }

    //1! = 1 * 0! = 1
    //2! = 2 * 1 = 2 * 1!
    //3! = 3 * 2 * 1 = 3 * 2!
    //4! = 4 * 3 * 2 * 1 = 4 * 3!
    //n! = n * (n - 1)!
    public static int RecursiveFactorial(int n)
    {
        if (n == 0) return 1;
        return n * RecursiveFactorial(n - 1);
    }
}