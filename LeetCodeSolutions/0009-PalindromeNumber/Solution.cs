namespace PalindromeNumber0009;
/* 
Problem: Palindrome Number (LeetCode #9)
Link: https://leetcode.com/problems/palindrome-number/description/

Approach:
- convert input (x) to something iterable (string) 
- iterate x
- check if both ends are equal each iteration
- return if false if not equal
- return true if iterates fully without a false

Complexities:
- Time: O(n)
- Space: O(1)

Notes:
- Since it is an 'easy' problem, I decided to push for a more optimal solution
*/
public class Solution
{
    public bool IsPalindrome(int x)
    {
        string num = x.ToString();
        for (int i = 0; i < num.Length / 2; i++)
        {
            if (num[0 + i] != num[num.Length - 1 - i])
            {
                return false;
            }
        }
        return true;
    }

    /* 
    FIRST SOLUTION 
    Approach:
    - convert input (x) to something iterable (string) 
    - initialize a comparison string (flipped)
    - iterate x backwards to build flipped 
    - return if x and flipped are equal
    Complexities:
    - Time: O(n²)
    - Space: O(n)
    */
    public bool IsPalindrome_1(int x)
    {
        string num = x.ToString();
        string flipped = "";
        for (int i = num.Length - 1; i >= 0; i--)
        {
            flipped += num[i];
        }
        return num.Equals(flipped);
    }
}

[TestClass]
public class SolutionTest
{
    [TestMethod]
    public void IsPalindrome_ShouldReturnTrue_WhenInputIs121()
    {
        var solution = new Solution();
        var expected = true;
        var actual = solution.IsPalindrome(121);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsPalindrome_ShouldReturnFalse_WhenInputIsMinus121()
    {
        var solution = new Solution();
        var expected = false;
        var actual = solution.IsPalindrome(-121);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsPalindrome_ShouldReturnFalse_WhenInputIs10()
    {
        var solution = new Solution();
        var expected = false;
        var actual = solution.IsPalindrome(10);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsPalindrome_ShouldReturnTrue_WhenInputIs1221()
    {
        var solution = new Solution();
        var expected = true;
        var actual = solution.IsPalindrome(1221);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsPalindrome_ShouldReturnTrue_WhenInputIs0()
    {
        var solution = new Solution();
        var expected = true;
        var actual = solution.IsPalindrome(0);
        Assert.AreEqual(expected, actual);
    }
}