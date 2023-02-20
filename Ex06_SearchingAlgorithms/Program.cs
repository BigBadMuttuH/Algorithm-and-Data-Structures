namespace Algorithm_and_Data_Structures;

internal class Program
{
    private static void Main(string[] args)
    {
        var customerList = new List<Customer>
        {
            new() { Age = 3, Name = "Ann" },
            new() { Age = 16, Name = "Bill" },
            new() { Age = 20, Name = "Rose" },
            new() { Age = 14, Name = "Rob" },
            new() { Age = 28, Name = "Bill" },
            new() { Age = 14, Name = "John" }
        };
        var intList = new List<int> { 1, 4, 2, 7, 5, 9, 12, 3, 2, 1 };

        var contains = intList.Contains(3);
        // CustomerComparer - как сравнивать, иначе сравниваются ссылки в памяти
        var contains2 = customerList.Contains(new Customer { Age = 14, Name = "Rob" }, new CustomerComparer());

        var exists = customerList.Exists(customer => customer.Age == 28);

        var min = intList.Min();
        var max = intList.Max();

        var youngestCustomerAge = customerList.Min(customer => customer.Age);

        var bill = customerList.Find(customer => customer.Name == "Bill");
        var lastBill = customerList.FindLast(customer => customer.Name == "Bill");
        var lastBill2 = customerList.Last(customer => customer.Name == "Bill");

        var customers = customerList.FindAll(customer => customer.Age > 18);
        var whereAge = customerList.Where(customer => customer.Age > 18);

        var index1 = customerList.FindIndex(customer => customer.Age == 14);
        var lastIndex = customerList.FindLastIndex(customer => customer.Age > 18);

        var indexOf = intList.IndexOf(2);
        var indexOf2 = intList.LastIndexOf(2);

        // from list
        // вернет тру, только если у всех в листе возраст больше 10
        var isTrueForAll = customerList.TrueForAll(customer => customer.Age > 10);

        // form linq
        var all = customerList.All(customer => customer.Age > 18);

        var areThenAny = customerList.Any(customer => customer.Age == 3);


        // linq count
        var count = customerList.Count(customer => customer.Age > 18);
        var firsBill = customerList.First(customer => customer.Name == "Bill");
        var singleAnn = customerList.Single(customer => customer.Name == "Ann");
    }

    // Линейный поиск
    private static bool Exists(int[] array, int number)
    {
        for (var i = 0; i < array.Length; i++)
            if (array[i] == number)
                return true;

        return false;
    }

    // Линейный поиск
    private static int IndexOf(int[] array, int number)
    {
        for (var i = 0; i < array.Length; i++)
            if (array[i] == number)
                return i;

        return -1;
    }
}

internal class CustomerComparer : IEqualityComparer<Customer>
{
    public bool Equals(Customer x, Customer y)
    {
        return x.Age == y.Age && x.Name == y.Name;
    }

    public int GetHashCode(Customer obj)
    {
        return obj.GetHashCode();
    }
}