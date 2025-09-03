namespace MaxDepthOfBinaryTree0104;
/* 
Problem: Maximum Depth of Binary Tree (LeetCode #104)
Link: https://leetcode.com/problems/maximum-depth-of-binary-tree/description/

Approach:
- Initially planned to do iterative approach but a recursive
  approach made more sense
- Recursive functions always require a base "out" which in 
  this case is null; meaning the current depth doesnt exist
- We are looking for a total (depth), therefore we need to
  compare total to the totals below in the sequence, add the
  maximum to the current depth, and return the total. 

Complexities:
- Time: O(n)
    - each node is visited once
- Space: O(h) -> O(n) worst, O(log n) best
    - “height” of the tree (h) = how many levels from top to bottom.
    - Worst case: the tree is just a straight line (like a linked list). 
      The stack has to remember every single node -> O(n).   
    - Best case: the tree is balanced (like a pyramid). 
      The stack only has to remember about log₂(n) nodes at a time -> O(log n)

Notes:
- Had to refresh myself on binary tree syntax 
  since it has been about a year since working 
  with them
*/
public class Solution
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;
        else return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }

    /* 
    FIRST SOLUTION 
    NOTE: Same logic as above; just not as consise 
    */
    public int MaxDepth_1(TreeNode root)
    {
        int total = 0;
        if (root == null) return 0;
        else
        {
            total++;
            int maxLeft = MaxDepth(root.left);
            int maxRight = MaxDepth(root.right);
            total += maxLeft > maxRight ? maxLeft : maxRight;
        }
        return total;
    }
}

[TestClass]
public class SolutionTest
{
    [TestMethod]
    public void MaxDepth_ShouldReturn3_WhenCase1()
    {
        var solution = new Solution();
        TreeNode root = new TreeNode(3,
            new TreeNode(9),
            new TreeNode(20,
                new TreeNode(15),
                new TreeNode(7)
            )
        );
        int expected = 3;

        var actual = solution.MaxDepth(root);

        Console.WriteLine(actual);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MaxDepth_ShouldReturn2_WhenCase2()
    {
        var solution = new Solution();
        TreeNode root = new TreeNode(1,
            null,
            new TreeNode(2)
        );
        int expected = 2;

        var actual = solution.MaxDepth(root);

        Console.WriteLine(actual);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MaxDepth_ShouldReturn0_WhenRootNull()
    {
        var solution = new Solution();
        TreeNode root = null;
        int expected = 0;

        var actual = solution.MaxDepth(root);

        Console.WriteLine(actual);
        Assert.AreEqual(expected, actual);
    }
}

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}