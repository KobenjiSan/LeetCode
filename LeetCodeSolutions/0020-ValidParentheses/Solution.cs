namespace ValidParentheses0020;
/* 
Problem: Valid Parentheses (LeetCode #20)
Link: https://leetcode.com/problems/valid-parentheses/

Approach:
- create a stack to utilize LIFO
- iterate the string (s)
- if current char is opener push it
- else validate stack isnt empty 
- then validate the top char corresponds with the closing char
- if they correspond, pop, otherwise, return false
- return final stack count (0 = valid, !0 = invalid)

Complexities:
- Time: O(n)
- Space: O(n)

Notes:
- it has been a while since I have used a stack
- initial thought was to do something similar to Palindrome Number (quickly realized that wasnt logical)
- initially was using strStack.Contains() (again, realized that wasnt logical after failed submission)
- second submission doesnt improve complexities 
*/
public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> strStack = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                strStack.Push(s[i]);
            else
            {
                if (strStack.Count == 0) return false;

                if ((strStack.Peek() == '(' && s[i] == ')') ||
                    (strStack.Peek() == '[' && s[i] == ']') ||
                    (strStack.Peek() == '{' && s[i] == '}')
                )
                    strStack.Pop();
                else
                    return false;
            }
        }
        return strStack.Count == 0;
    }

    /*
    FIRST SOLUTION
    Approach:
    - create a stack to utilize LIFO
    - iterate the string (s)
    - if stack is empty automatically push and skip cycle
    - check if top of stack corresponds with current char
    - if it does pop, otherwise push (assumes it is adding an opening char)
    - return final stack count (0 = valid, !0 = invalid)
    Complexities:
    - Time: O(n)
    - Space: O(n)
    */
    public bool IsValid_1(string s)
    {
        Stack<char> strStack = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (strStack.Count == 0)
            {
                strStack.Push(s[i]);
                continue;
            }

            if ((strStack.Peek() == '(' && s[i] == ')') ||
                (strStack.Peek() == '[' && s[i] == ']') ||
                (strStack.Peek() == '{' && s[i] == '}')
            )
                strStack.Pop();
            else
                strStack.Push(s[i]);

        }
        return strStack.Count() == 0;
    }
}

[TestClass]
public class SolutionTest
{
    [TestMethod]
    public void IsValid_ShouldReturnTrue_WhenExample1()
    {
        var solution = new Solution();
        var s = "()";
        var expected = true;

        var actual = solution.IsValid(s);

        Console.WriteLine(actual);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsValid_ShouldReturnTrue_WhenExample2()
    {
        var solution = new Solution();
        var s = "()[]{}";
        var expected = true;

        var actual = solution.IsValid(s);

        Console.WriteLine(actual);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsValid_ShouldReturnFalse_WhenExample3()
    {
        var solution = new Solution();
        var s = "(]";
        var expected = false;

        var actual = solution.IsValid(s);

        Console.WriteLine(actual);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsValid_ShouldReturnTrue_WhenExample4()
    {
        var solution = new Solution();
        var s = "([])";
        var expected = true;

        var actual = solution.IsValid(s);

        Console.WriteLine(actual);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsValid_ShouldReturnFalse_WhenExample5()
    {
        var solution = new Solution();
        var s = "([)]";
        var expected = false;

        var actual = solution.IsValid(s);

        Console.WriteLine(actual);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsValid_ShouldReturnFalse_WhenExample6()
    {
        var solution = new Solution();
        var s = "({{{{}}}))";
        var expected = false;

        var actual = solution.IsValid(s);

        Console.WriteLine(actual);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsValid_ShouldReturnFalse_WhenExample7()
    {
        var solution = new Solution();
        var s = "(){}}{";
        var expected = false;

        var actual = solution.IsValid(s);

        Console.WriteLine(actual);
        Assert.AreEqual(expected, actual);
    }

}