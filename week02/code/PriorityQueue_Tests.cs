using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add multiple items with different priorities and remove one item.
    // Expected Result: The item with the highest priority should be removed first.
    // Defect(s) Found: Initially the dequeue logic did not properly identify the
    // highest priority item because the loop ignored the final element and did
    // not correctly compare priorities. After correcting the loop and comparison,
    // the highest priority item is correctly removed.
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Sue", 5);
        priorityQueue.Enqueue("Tim", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Sue", result);
    }

    [TestMethod]
    // Scenario: Add multiple items with the same priority and remove one item.
    // Expected Result: The item that was added first (FIFO order) should be removed.
    // Defect(s) Found: The initial implementation replaced the earlier item when
    // priorities were equal, violating FIFO order. After fixing the comparison
    // logic, the queue correctly removes the earliest item with the highest priority.
    public void TestPriorityQueue_FIFOWhenSamePriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 3);
        priorityQueue.Enqueue("Sue", 3);
        priorityQueue.Enqueue("Tim", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Bob", result);
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown with the
    // message "The queue is empty."
    // Defect(s) Found: The queue must properly detect when it is empty and
    // throw the required exception. After verifying the implementation, the
    // correct exception and message are produced.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
