using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_and_Data_Structures
{
    public class Customer
    {
        public string Name { get; set; }
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
            List<int> list = new List<int>();
            LogCountAndCapacity(list);

            for (int i = 0; i < 16; i++)
            {
                list.Add(i);
                LogCountAndCapacity(list);
            }

            for (int i = 10; i > 0; i--)
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
            var list = new List<int>() {1, 0, 5, 3, 4 };
            list.Sort();

            int indexBinSearch = list.BinarySearch(3);

            list.Reverse();

            ReadOnlyCollection<int> readOnlyList = list.AsReadOnly();

            int[] array = list.ToArray();

            var listCustomer = new List<Customer>()
            {
                new Customer {BirthDate = new DateTime(1988, 08, 12), Name = "Elias"},
                new Customer {BirthDate = new DateTime(1990, 06, 09), Name = "Maria"},
                new Customer {BirthDate = new DateTime(2015, 06, 09), Name = "Anna"},
            };

            listCustomer.Sort((left, right) =>
            {
                if (left.BirthDate > right.BirthDate) { return 1; };
                if (right.BirthDate > left.BirthDate) { return -1; };
                return 0;
            });
            
            

        }
        private static void LogCountAndCapacity(List<int> list)
        {
            Console.WriteLine($"Count={list.Count}. Capacity={list.Capacity}");
        }
    }
}
