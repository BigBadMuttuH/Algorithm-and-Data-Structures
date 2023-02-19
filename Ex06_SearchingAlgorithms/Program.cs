namespace Algorithm_and_Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerList = new List<Customer>()
            {
                new Customer { Age = 3, Name = "Ann" },
                new Customer { Age = 16, Name = "Bill" },
                new Customer { Age = 20, Name = "Rose" },
                new Customer { Age = 14, Name = "Rob" },
                new Customer { Age = 28, Name = "Bill" },
                new Customer { Age = 14, Name = "John" },
            };
            var intList = new List<int>() { 1, 4, 2, 7, 5, 9, 12, 3, 2, 1 };

            bool contains = intList.Contains(3);
            // CustomerComparer - как сравнивать, иначе сравниваются ссылки в памяти
            bool contains2 = customerList.Contains(new Customer { Age = 14, Name = "Rob" }, new CustomerComparer());

            bool exists = customerList.Exists(customer => customer.Age == 28);

            int min = intList.Min();
            int max = intList.Max();

            int youngestCustomerAge = customerList.Min(customer => customer.Age);

            Customer bill = customerList.Find(customer => customer.Name == "Bill");
            Customer lastBill = customerList.FindLast(customer => customer.Name == "Bill");
            Customer lastBill2 = customerList.Last(customer => customer.Name == "Bill");

            List<Customer> customers = customerList.FindAll(customer => customer.Age > 18);
            IEnumerable<Customer> whereAge = customerList.Where(customer => customer.Age > 18);

            int index1 = customerList.FindIndex(customer => customer.Age == 14);
            int lastIndex = customerList.FindLastIndex(customer => customer.Age > 18);

            int indexOf = intList.IndexOf(2);
            int indexOf2 = intList.LastIndexOf(2);

            // from list
            // вернет тру, только если у всех в листе возраст больше 10
            bool isTrueForAll = customerList.TrueForAll(customer => customer.Age > 10);
            
            // form linq
            bool all = customerList.All(customer => customer.Age > 18);

            bool areThenAny = customerList.Any(customer => customer.Age == 3);


            // linq count
            int count = customerList.Count(customer => customer.Age > 18);
            Customer firsBill = customerList.First(customer => customer.Name == "Bill");
            Customer singleAnn = customerList.Single(customer => customer.Name == "Ann");
        }

        // Линейный поиск
        private static bool Exists(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number) return true; 
            }

            return false;
        }

        // Линейный поиск
        private static int IndexOf(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number) return i; 
            }

            return -1;
        }
    }

    internal class CustomerComparer : IEqualityComparer<Customer>
    {
        public bool Equals(Customer x, Customer y) => x.Age == y.Age && x.Name == y.Name;

        public int GetHashCode(Customer obj) => obj.GetHashCode();
    }
}
