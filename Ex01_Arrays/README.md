**Массивы** в памяти. (Все массивы ссылочные типы)

![Ex01_Arrays](./Images/Ex01_arrays.png "Arrays1")

    - SyncBlockIndex (4 bytes) + ref to method table (4 bytes) + Length (4 bytes)
    - Массивы 4-х целых чисел ест (4*4 bytes + 12 bytes) = 28 bytes
    - Массив ссылочных типов также содержит TypeHandle, т.о. пустой массив строк съест: SyncBlockIndex (4 bytes) + method table ref (4 bytes) + Length (4 bytes) + TypeHandle (4 bytes) = 16 bytes

Узнать адрес в памяти элемента массива

![Ex02_Arrays](./Images/Ex02_arrays.png "Arrays2")

Самые часты операции с массивами:
 - Доступ к элементу: или прямой если возможно, или с предварительным поиском
 - Добавление элемента: в начало, в конец
 - Вставка элемента
 - Обновление элемента
 - Удаление элемента

![Ex03_Arrays](./Images/Ex03_arrays.png "Arrays3")