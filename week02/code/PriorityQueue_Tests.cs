using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue and dequeue a single item
    // Expected Result: The same item should be dequeued
    public void TestPriorityQueue_EnqueueDequeueSingle()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 5);
        var result = queue.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Dequeue highest priority among several
    // Expected Result: Should return item with highest priority
    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Low", 1);
        queue.Enqueue("High", 10);
        queue.Enqueue("Medium", 5);

        var result = queue.Dequeue();  // Should return "High"
        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Multiple items with same highest priority
    // Expected Result: Should return the one added first (FIFO)
    public void TestPriorityQueue_EqualPriorityFIFO()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("First", 10);
        queue.Enqueue("Second", 10);
        queue.Enqueue("Third", 5);

        var result1 = queue.Dequeue();  // First with highest priority
        var result2 = queue.Dequeue();  // Second with same priority
        Assert.AreEqual("First", result1);
        Assert.AreEqual("Second", result2);
    }

    [TestMethod]
    // Scenario: Dequeue on empty queue
    // Expected Result: Should throw InvalidOperationException
    public void TestPriorityQueue_DequeueEmptyThrows()
    {
        var queue = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Priority at the end is the highest
    // Expected Result: Last enqueued (with highest priority) is dequeued
    public void TestPriorityQueue_HighestAtEnd()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("X", 1);
        queue.Enqueue("Y", 2);
        queue.Enqueue("Z", 3);

        var result = queue.Dequeue(); // Z has highest priority
        Assert.AreEqual("Z", result);
    }
}
