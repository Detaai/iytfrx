using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LinkedListTests
{
    [TestMethod]
    public void InsertHead_InsertTail_PreserveOrder()
    {
        var list = new LinkedList();

        list.InsertHead(2);
        list.InsertHead(1);
        list.InsertTail(3);

        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, list.ToArray());
    }

    [TestMethod]
    public void RemoveHead_And_RemoveTail_WorkOnMultiItemList()
    {
        var list = new LinkedList();
        list.InsertTail(1);
        list.InsertTail(2);
        list.InsertTail(3);

        list.RemoveHead();
        list.RemoveTail();

        CollectionAssert.AreEqual(new[] { 2 }, list.ToArray());
    }

    [TestMethod]
    public void RemoveHead_And_RemoveTail_LeaveEmptyListWhenSingleItem()
    {
        var list = new LinkedList();
        list.InsertTail(10);

        list.RemoveHead();

        Assert.IsTrue(list.HeadAndTailAreNull());

        list.InsertTail(20);
        list.RemoveTail();

        Assert.IsTrue(list.HeadAndTailAreNull());
    }

    [TestMethod]
    public void InsertAfter_InsertsAfterFirstOccurrenceOnly()
    {
        var list = new LinkedList();
        list.InsertTail(1);
        list.InsertTail(2);
        list.InsertTail(2);
        list.InsertTail(3);

        list.InsertAfter(2, 9);

        CollectionAssert.AreEqual(new[] { 1, 2, 9, 2, 3 }, list.ToArray());
    }

    [TestMethod]
    public void Remove_RemovesFirstOccurrenceOnly()
    {
        var list = new LinkedList();
        list.InsertTail(1);
        list.InsertTail(2);
        list.InsertTail(2);
        list.InsertTail(3);

        list.Remove(2);

        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, list.ToArray());
    }

    [TestMethod]
    public void Replace_ReplacesAllOccurrences()
    {
        var list = new LinkedList();
        list.InsertTail(1);
        list.InsertTail(2);
        list.InsertTail(1);
        list.InsertTail(3);

        list.Replace(1, 8);

        CollectionAssert.AreEqual(new[] { 8, 2, 8, 3 }, list.ToArray());
    }

    [TestMethod]
    public void Reverse_IteratesBackwards()
    {
        var list = new LinkedList();
        list.InsertTail(4);
        list.InsertTail(5);
        list.InsertTail(6);

        CollectionAssert.AreEqual(new[] { 6, 5, 4 }, list.Reverse().Cast<int>().ToArray());
    }
}
