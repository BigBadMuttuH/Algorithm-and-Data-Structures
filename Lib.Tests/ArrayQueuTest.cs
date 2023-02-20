using Algorithm_and_Data_Structures;
using NUnit.Framework;

namespace Lib.Tests;

[TestFixture]
public class ArrayQueuTest
{
    [Test]
    public void Capacity_EnqueueManyItems_DoubleCapacity()
    {
        var queue = new ArrayQueue<int>();
        queue.Enqueu(1);
        queue.Enqueu(2);
        queue.Enqueu(3);
        queue.Enqueu(4);
        queue.Enqueu(5);

        Assert.AreEqual(8, queue.Capacity);
    }

    [Test]
    public void IsEmpty_EmptyQueue_RetursTrue()
    {
        var queue = new ArrayQueue<int>();
        Assert.IsTrue(queue.IsEmpty);
    }

    [Test]
    public void Count_EnqueueOneItem_ReturnsOne()
    {
        var queue = new ArrayQueue<int>();
        queue.Enqueu(1);
        Assert.AreEqual(1, queue.Count);
        Assert.IsFalse(queue.IsEmpty);
    }

    [Test]
    public void Dequeue_EmptyQueue_ThrowsExeption()
    {
        var queue = new ArrayQueue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Test]
    public void Peek_EnqueueTwoItems_ReturnsHeadItem()
    {
        var queue = new ArrayQueue<int>();
        queue.Enqueu(1);
        queue.Enqueu(2);

        Assert.AreEqual(1, queue.Peek());
    }

    [Test]
    public void Peek_EnqueueTwoItemsAndDequeue_ReturnsHeadElement()
    {
        var queue = new ArrayQueue<int>();
        queue.Enqueu(1);
        queue.Enqueu(2);

        queue.Dequeue();

        Assert.AreEqual(2, queue.Peek());
    }
}