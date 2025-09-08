namespace ClimbingStairs0070;
/* 
Problem: Climbin gStairs (LeetCode #70)
Link: https://leetcode.com/problems/climbing-stairs/description/

Approach:
- init total
- init base cases
- iterate up to step 'n'
- using previous solves add number of combinations
- switch 'prev1' to 'prev2' and 'prev2' to 'total' (move 'pointers')
- return total after reaching 'n'

Complexities:
- Time: O(n)
- Space: O(1)

Notes:
- Original was not optimized but works just the same
- Reduces space from O(n) -> O(1) by only storing last two states
*/
public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n <= 1) return 1;
        int total = 0, prev1 = 1, prev2 = 1;
        for (int i = 2; i <= n; i++)
        {
            total = prev1 + prev2;
            prev1 = prev2;
            prev2 = total;
        }
        return total;
    }

    /*
    FIRST SOLUTION
    Approach:
    - use dictionary to hold data
    - set base case 0 & 1
    - iterate up to step 'n'
    - using previous solves add number of combinations
    - return total 
    Complexities:
    - Time: O(n)
    - Space: O(n)
    */
    public int ClimbStairs_1(int n)
    {
        var dp = new Dictionary<int, int>();
        dp[0] = 1;
        dp[1] = 1;
        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        return dp[n];
    }
}

[TestClass]
public class SolutionTest
{
    [TestMethod]
    public void ClimbStairs_ShouldReturn2_WhenInputIs2()
    {
        var solution = new Solution();
        var expected = 2;
        var actual = solution.ClimbStairs(2);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ClimbStairs_ShouldReturn3_WhenInputIs3()
    {
        var solution = new Solution();
        var expected = 3;
        var actual = solution.ClimbStairs(3);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ClimbStairs_ShouldReturn5_WhenInputIs4()
    {
        var solution = new Solution();
        var expected = 5;
        var actual = solution.ClimbStairs(4);
        Assert.AreEqual(expected, actual);
    }

}