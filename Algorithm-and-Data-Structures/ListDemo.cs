namespace Algorithm_and_Data_Structures;

public class Customer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }

    public string ToString(string format)
    {
        return $"{Name}, {BirthDate}";
    }
}

public class ListDemo
{
    public static void Run()
    {
        var list = new List<int>();
        LogCountAndCapacity(list);

        for (var i = 0; i < 16; i++)
        {
            list.Add(i);
            LogCountAndCapacity(list);
        }

        for (var i = 10; i > 0; i--)
        {
            list.Remove(i - 1);
            LogCountAndCapacity(list);
        }

        list.TrimExcess();
        LogCountAndCapacity(list);
        list.Add(1);
        LogCountAndCapacity(list);
    }

    public static void ApiMembers()
    {
        var list = new List<int> { 1, 0, 5, 3, 4 };
        list.Sort();

        var indexBinSearch = list.BinarySearch(3);

        list.Reverse();

        var readOnlyList = list.AsReadOnly();

        var array = list.ToArray();

        var listCustomer = new List<Customer>
        {
            new() { BirthDate = new DateTime(1988, 08, 12), Name = "Elias" },
            new() { BirthDate = new DateTime(1990, 06, 09), Name = "Maria" },
            new() { BirthDate = new DateTime(2015, 06, 09), Name = "Anna" }
        };

        listCustomer.Sort((left, right) =>
        {
            if (left.BirthDate > right.BirthDate) return 1;
            ;
            if (right.BirthDate > left.BirthDate) return -1;
            ;
            return 0;
        });
    }

    private static void LogCountAndCapacity(List<int> list)
    {
        Console.WriteLine($"Count={list.Count}. Capacity={list.Capacity}");
    }
}