namespace KthLargestElemInAStream0703;
/* 
Problem: Kth Largest Element in a Stream (LeetCode #703)
Link: https://leetcode.com/problems/kth-largest-element-in-a-stream/description/

Approach:
- Queue can be prioritied by value
- Init k and add all nums to queue
- If queue is greater than k then 
  remove lowest values
- To add, add to queue, remove lowest 
  value, return left over lowest

Complexities:
- Time: O(log k)
- Space: O(k)

Notes:
- Has been over a year since I worked 
  with queues / heaps
- Initial solution was overly complex 
  and I scrapped the whole thing
*/
public class KthLargest
{
    private readonly int k;
    private readonly PriorityQueue<int, int> queue = new();

    public KthLargest(int k, int[] nums)
    {
        this.k = k;
        foreach (var n in nums)
        {
            queue.Enqueue(n, n);
            if (queue.Count > k) queue.Dequeue();
        }
    }

    public int Add(int val)
    {
        queue.Enqueue(val, val); 
        if (queue.Count > k) queue.Dequeue();
        return queue.Peek();  
    }
}

[TestClass]
public class SolutionTest
{
    [TestMethod]
    public void KthLargest_ShouldReturn8_WhenCase1()
    {
        KthLargest kthLargest = new KthLargest(3, [4, 5, 8, 2]);
        int expected = 8;

        int param_1 = kthLargest.Add(3);
        int param_2 = kthLargest.Add(5);
        int param_3 = kthLargest.Add(10);
        int param_4 = kthLargest.Add(9);

        var actual = kthLargest.Add(4);

        Console.WriteLine(new { param_1, param_2, param_3, param_4, actual });
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void KthLargest_ShouldReturn9_WhenCase2()
    {
        KthLargest kthLargest = new KthLargest(4, [7, 7, 7, 7, 8, 3]);
        int expected = 8;

        int param_1 = kthLargest.Add(2);
        int param_2 = kthLargest.Add(10);
        int param_3 = kthLargest.Add(9);

        var actual = kthLargest.Add(9);

        Console.WriteLine(new { param_1, param_2, param_3, actual });
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void KthLargest_ShouldReturn4_WhenCase3()
    {
        KthLargest kthLargest = new KthLargest(1, []);
        int expected = 4;

        int param_1 = kthLargest.Add(-3);
        int param_2 = kthLargest.Add(-2);
        int param_3 = kthLargest.Add(-4);
        int param_4 = kthLargest.Add(0);

        var actual = kthLargest.Add(4);

        Console.WriteLine(new { param_1, param_2, param_3, param_4, actual });
        Assert.AreEqual(expected, actual);
    }    
}