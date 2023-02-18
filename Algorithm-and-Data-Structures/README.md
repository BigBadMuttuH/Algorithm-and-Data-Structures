Как работает **Array.Sort**:
 ```CSharp
    List<T>.Sort eventually calls Array.Sort<T>()
    // Если сортируемые элементы примитивные типы, то 
    if T is primitive -> TrySZSort() - native implementation
    // Если ссылочные типы, то поведение будет зависеть от платформы
    if(platform == .Net Core || platform >= .Net Framework 4.5)
    {
        // combination of inserting sort, heap sort, QSort
        // если сортируемых элементов <= 16 insertionSort
        // если > 2LogN то Пирамидальная сортировка
        // иначе - QuickSort
        IntroSort();
    } else {
        // actually IntroSort as well
        // QSort with 32-max recursion depth, if exceeded switches to HeapSort
        DepthLimitedQuickSort();
    }
```

### List
    - Backed up by an array internally
    - Add - O(1) if enough space, O(N) if not enough
    - Remove - O(N)
    - RemoveAt - O(N)
    - Reverse - O(N)
    - ToArray - O(N) - based on Array.Copy
    - Contains, IndexOf etc. - O(N)
    - Sort - O(n^2),  θ(n log n)
**DO NOT USE _ArrayList_. Use _List\<object>_ instead.**