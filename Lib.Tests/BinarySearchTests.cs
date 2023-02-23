using Algorithm_and_Data_Structures;
using NUnit.Framework;

namespace Lib.Tests;

[TestFixture]
public class BinarySearchTests
{
    [Test]
    public void BinarySearch_SortedInput_Returns_CorrectIndex()
    {
        int[] input = { 0, 3, 4, 7, 8, 12, 15, 22 };

        Assert.AreEqual(2, Searching.BinarySearch(input, 4));
        Assert.AreEqual(0, Searching.BinarySearch(input, 0));
        Assert.AreEqual(4, Searching.BinarySearch(input, 8));
        Assert.AreEqual(7, Searching.BinarySearch(input, 22));
        Assert.AreEqual(-1, Searching.BinarySearch(input, 5));

        Assert.AreEqual(2, Searching.RecursiveBinarySearch(input, 4));
        Assert.AreEqual(0, Searching.RecursiveBinarySearch(input, 0));
        Assert.AreEqual(4, Searching.RecursiveBinarySearch(input, 8));
        Assert.AreEqual(7, Searching.RecursiveBinarySearch(input, 22));
        Assert.AreEqual(-1, Searching.RecursiveBinarySearch(input, 5));
    }
}