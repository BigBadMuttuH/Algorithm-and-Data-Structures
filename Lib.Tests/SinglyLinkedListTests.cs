using Algorithm_and_Data_Structures;
using NUnit.Framework;

namespace Lib.Tests;

[TestFixture]
public class SinglyLinkedListTests
{
    [SetUp]
    public void Init()
    {
        _list = new SinglyLinkedList<int>();
    }

    private SinglyLinkedList<int> _list;

    [Test]
    public void CreateEmptyList_CorrectState()
    {
        Assert.IsTrue(_list.IsEmpty);
        Assert.IsNull(_list.Head);
        Assert.IsNull(_list.Tail);
    }

    [Test]
    public void AddFirst_and_AddLast_OneItem_CorrectState()
    {
        _list.AddFirst(1);
        CheckStateWithSingleNode(_list);
    }

    [Test]
    public void AddRemoveToGetToStateWithSingleNode_CorrectState()
    {
        _list.AddFirst(1);
        _list.AddFirst(2);
        _list.RemoveFirst();

        CheckStateWithSingleNode(_list);

        _list.AddFirst(2);
        _list.RemoveLast();

        CheckStateWithSingleNode(_list);
    }


    private void CheckStateWithSingleNode(SinglyLinkedList<int> list)
    {
        Assert.AreEqual(1, list.Count);
        Assert.IsFalse(list.IsEmpty);
        Assert.AreSame(list.Head, list.Tail);
    }

    [Test]
    public void AddFirst_and_AddLast_AddItemInCorrectOrder()
    {
        _list.AddFirst(1);
        _list.AddFirst(2);

        Assert.AreEqual(2, _list.Head.Value);
        Assert.AreEqual(1, _list.Tail.Value);

        _list.AddLast(3);
        Assert.AreEqual(3, _list.Tail.Value);
    }

    [Test]
    public void RemoveFirst_EmptyList_Throws()
    {
        Assert.Throws<InvalidOperationException>(() => _list.RemoveFirst());
    }

    [Test]
    public void RemoveLast_EmptyList_Throws()
    {
        Assert.Throws<InvalidOperationException>(() => _list.RemoveLast());
    }

    [Test]
    public void RemoveFirst_RemoveLast_CorrectState()
    {
        _list.AddFirst(1);
        _list.AddFirst(2);
        _list.AddFirst(3);
        _list.AddFirst(4);

        _list.RemoveFirst();
        _list.RemoveLast();

        Assert.AreEqual(3, _list.Head.Value);
        Assert.AreEqual(2, _list.Tail.Value);
    }
}