### Символьные таблицы
- Быстрый доступ к данным - почти необходимое условие нашего существования сегодня. Нужны структуры данных, эффективные для операций вставки и поиска.
- Символьные таблицы позволяют добавлять значения по ключу и затем извлекать их по тому же ключу.
- Зачастую, символьные таблицы называют **словарями**. 

- Ключ не обязан быть целым числом
- Словарь состоит из пар ключ/значение и их типы не обязанны совпадать
- Есть четыре основных реализации словаря, три из которых конкурентоспособны, а одна служит демонстрационным целям (тривиальная).

Бывают: **упорядоченные / неупорядоченные**
- Упорядоченные словари поддерживают возможности, которые не поддерживаются неупорядоченными словарями
- 

#### Symbol Table API
- A default constructor and a constructor which allows a client to pass a custom keys comparer
- bool TryGet(TKey key) - returns true if a value was found, otherwise false
- void Add(TKey key, TValue val) - inserts a key-value pair into a table
- bool Remove(TKey) - explicitly removes a key-value pair
- bool Contains(TKey key) - checks if a certain key is presented in a table
- bool IsEmpty() - auxiliary method which returns true if there are no keys and false otherwise
- int Count() - Count returns the number of key-value pairs in a table
- IEnumerable \<TKey Keys> Keys() - returns all the keys from a table

#### Упорядоченные Symbol Tables
- TKey Min()
- TKey Max()
- void RemoveMin()
- void RemoveMax()
- TKey Floor(TKey key) - get the greatest key which is less or equals the requested key
- TKey Ceiling(TKey key) - get the least key which is greater or equals the requested key
- int Rank(TKey key) - counts the number of keys which are less the requested key
- TKey Select(int k) - searches for a key with a specific rank. So, the following expressions will be true: ```i == Rank(Select(i)) and key == Select(Rank(key))```
- int Range(TKey a, TKey b) - allows to quickly get the number of keys between a and b -> [a..b]