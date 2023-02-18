### LinkedList
Node Chains

![NodeChains](Images/NodeChains.png "NodeChains")

     - Head - первый элемент
     - Tail - последний узел
     - Операции:
       - Add
       - Remove
       - Find
       - Enumerate


### Singly-Linked List
AddFirst
![AddFirst](Images/AddFirst.png "AddFirst")
AddLast
![AddLast](Images/AddLast.png "AddLast")
RemoveLast
![RemoveLast](Images/RemoveLast.png)
RemoveFirst
![RemoveFirst](Images/RemoveFirst.png)

### Doubly-Linked List
![DoublyLinkedList](Images/DoublyLinkedList.png "DoublyLinkedList")

### Встроенный LinkedList это:
    - Doubly-Linked Circular List
    - AddFirst/AddLast - O(1)
    - AddBefore/AddAfter - O(1)
    (if you know the node, otherwise you'll have to search at first for O(N))
    - Remove O(N) - searching
    - RemoveFirst/RemoveLast O(1) 
    - Contains, Find/FindLast O(N)
    - CopyTo - O(N)
    - Clear - O(N) // чтобы зачистить все ссылки