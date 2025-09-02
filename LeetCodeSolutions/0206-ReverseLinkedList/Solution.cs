namespace ReverseLinkedList0206;
/* 
Problem: Reverse Linked List (LeetCode #206)
Link: https://leetcode.com/problems/reverse-linked-list/

Approach:
- previous ListNode begins at null
- current ListNode starts at head
- iterate current ListNode
- temp holds next values (used to push current Node forward)
- replace whatever is after current with reversed Nodes (previous)
- previous is updated as current (is now reversed up to current pos)
- current pointer is moved forward with temp
- head ListNode is updated to reversed ListNode and returned

Complexities:
- Time: O(n)
- Space: O(1)

Notes:
- decided to push for optimal solution.
- included visualized solution to better 
  understand solution.
*/
public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        if (head == null) return head!;
        ListNode previous = null!;
        ListNode current = head;
        while (current != null)
        {
            ListNode temp = current.next!;
            current.next = previous;
            previous = current;
            current = temp;
        }
        head = previous!;
        return head;
    }

    /*
    FIRST SOLUTION
    Approach:
    - since singly list I cannot reverse directly
      easiest solution to reason about is putting 
      ListNode to a list, then flip the list while
      creating a new ListNode.
    - solution is fast, but not space O(1) like is
      expected, nor is it an in-place solution.
    Complexities:
    - Time: O(n)
    - Space: O(n)
    */
    public ListNode ReverseList_1(ListNode head)
    {
        if (head == null) return head!;
        var resultList = new List<int>();
        while (head != null)
        {
            resultList.Add(head.val);
            head = head.next!;
        }
        var resultNode = new ListNode(resultList[0]);
        for (int i = 1; i < resultList.Count; i++)
        {
            resultNode = new(resultList[i], resultNode);
        }

        return resultNode;
    }
}

[TestClass]
public class SolutionTest
{
    [TestMethod]
    public void ReverseList_ShouldReturnReverse_When12345()
    {
        var solution = new Solution();
        var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        var expected = new ListNode(5, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(1)))));

        var actual = solution.ReverseList(head);

        Console.WriteLine(string.Join(", ", ToArray(actual)));
        CollectionAssert.AreEqual(
            ToArray(expected),
            ToArray(actual)
        );
    }

    [TestMethod]
    public void ReverseList_ShouldReturnReverse_When12()
    {
        var solution = new Solution();
        var head = new ListNode(1, new ListNode(2));
        var expected = new ListNode(2, new ListNode(1));

        var actual = solution.ReverseList(head);

        Console.WriteLine(string.Join(", ", ToArray(actual)));
        CollectionAssert.AreEqual(
            ToArray(expected),
            ToArray(actual)
        );
    }

    [TestMethod]
    public void ReverseList_ShouldReturnReverse_When_()
    {
        var solution = new Solution();
        var head = new ListNode();
        var expected = new ListNode();

        var actual = solution.ReverseList(head);

        Console.WriteLine(string.Join(", ", ToArray(actual)));
        CollectionAssert.AreEqual(
            ToArray(expected),
            ToArray(actual)
        );
    }

    /*
    Method: ToArray
    converts a ListNode into a tangable list
    used in CollectionAssert.AreEqual()
    @input - ListNode
    @ouput - int[]
    */
    public int[] ToArray(ListNode head)
    {
        var list = new List<int>();
        while (head != null)
        {
            list.Add(head.val);
            head = head.next!;
        }
        return list.ToArray();
    }
}

/*
Singly-linked list
*/
public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}