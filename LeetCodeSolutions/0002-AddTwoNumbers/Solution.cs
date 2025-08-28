namespace AddTwoNumbers0002;
/* 
Problem: Add Two Numbers (LeetCode #2)
Link: https://leetcode.com/problems/add-two-numbers/description/

Approach:
- Implement resultList to hold added numbers
- Have a tempSave number for carrying across numbers larger than 10
- Allow for both l1 and l2 to iterate
- Set numbers to 0 if list is expended
- Set num to temp save to auto add it
- Add numbers
- Carry and save logic for numbers larger than 10 or set reset the tempSave
- Insert number to list
- Try to move forward but again handle cases where list is expended
- Add last tempSave to list
- Initialize a finalNode with leading head
- Iterate the resultList to implement finalNode to be returned 

Complexities:
- Time: O((n + m)²)
- Space: O(n + m)

Notes:
- first medium LeetCode
- approach solved all test cases but is not efficient 
- resultList ended up being extra work
- could improve with dummy head + tail pointer pattern
*/
public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var resultList = new List<int>();
        var tempSave = 0;

        while (l1 != null || l2 != null)
        {
            // safely assign numeric value
            int l1Num = l1 == null ? 0 : l1.val;
            int l2Num = l2 == null ? 0 : l2.val;

            var num = tempSave;
            num += (l1Num + l2Num);

            // for sums larger than 10
            if (num >= 10)
            {
                tempSave = (int)(num / 10);
                num -= tempSave * 10;
            }
            else
            {
                tempSave = 0;
            }

            resultList.Insert(0, num);

            // safely move pointers
            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
        }

        // add final tempSave if necessary
        if (tempSave != 0) resultList.Insert(0, tempSave);

        // build finalNode from resultList 
        // (NOTE: similar logic could have been integrated in the while loop)
        ListNode finalNode = new ListNode(resultList[0]);
        for (int i = 1; i < resultList.Count; i++)
        {
            finalNode = new ListNode(resultList[i], finalNode);
        }

        return finalNode;
    }
}

// NOTE: Test methods are either the three inital test cases or cases that failed during submission requests
[TestClass]
public class SolutionTest
{
    [TestMethod]
    public void AddTwoNumbers_ShouldReturnReverseArray_When_832_921()
    {
        var solution = new Solution();
        var l1 = new ListNode(8, new ListNode(3, new ListNode(2)));
        var l2 = new ListNode(9, new ListNode(2, new ListNode(1)));
        var expected = new ListNode(7, new ListNode(6, new ListNode(3)));

        var actual = solution.AddTwoNumbers(l1, l2);

        Console.WriteLine(string.Join(", ", ToArray(actual)));
        CollectionAssert.AreEqual(
            ToArray(expected),
            ToArray(actual)
        );
    }

    [TestMethod]
    public void AddTwoNumbers_ShouldReturnReverseArray_When_243_564()
    {
        var solution = new Solution();
        var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
        var expected = new ListNode(7, new ListNode(0, new ListNode(8)));

        var actual = solution.AddTwoNumbers(l1, l2);

        Console.WriteLine(string.Join(", ", ToArray(actual)));
        CollectionAssert.AreEqual(
            ToArray(expected),
            ToArray(actual)
        );
    }

    [TestMethod]
    public void AddTwoNumbers_ShouldReturnReverseArray_When_0_0()
    {
        var solution = new Solution();
        var l1 = new ListNode(0);
        var l2 = new ListNode(0);
        var expected = new ListNode(0);

        var actual = solution.AddTwoNumbers(l1, l2);

        Console.WriteLine(string.Join(", ", ToArray(actual)));
        CollectionAssert.AreEqual(
            ToArray(expected),
            ToArray(actual)
        );
    }

    [TestMethod]
    public void AddTwoNumbers_ShouldReturnReverseArray_When_9_9()
    {
        var solution = new Solution();
        var l1 = new ListNode(9);
        var l2 = new ListNode(9);
        var expected = new ListNode(8, new ListNode(1));

        var actual = solution.AddTwoNumbers(l1, l2);

        Console.WriteLine(string.Join(", ", ToArray(actual)));
        CollectionAssert.AreEqual(
            ToArray(expected),
            ToArray(actual)
        );
    }

    [TestMethod]
    public void AddTwoNumbers_ShouldReturnReverseArray_When_9999999_9999()
    {
        var solution = new Solution();
        var l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
        var l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));
        var expected = new ListNode(8, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1))))))));

        var actual = solution.AddTwoNumbers(l1, l2);

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
            head = head.next;
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