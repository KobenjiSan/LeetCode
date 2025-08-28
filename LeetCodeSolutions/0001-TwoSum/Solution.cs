namespace TwoSum0001;
/* 
Problem: Two Sum (LeetCode #1)
Link: https://leetcode.com/problems/two-sum/description/

Approach:
- iterate over each element in nums
- track current index manually
- find index of element that complements target - current number
- if index isn't the current index and doesnt = -1 (i.e. complement exists) 
  return the current index and the complements index
- if all cases fail return empty string

Complexities:
- Time: O(n^2) worst case (Array.IndexOf is O(n))
- Space: O(1)

Notes:
- time could be improved with dictionary (map)
- could have used generic for loop to keep track of index automatically but didn't
*/
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        int curIndex = -1;
        foreach (int number in nums)
        {
            curIndex++;
            int indexToFind = Array.IndexOf(nums, target - number);
            if (indexToFind != curIndex && indexToFind != -1) return [curIndex, indexToFind];

        }
        return []; // No solution
    }
}

[TestClass]
public class SolutionTest
{
    [TestMethod]
    public void TwoSum_ShouldReturnIndices_WhenTargetIs9()
    {
        var solution = new Solution();
        var nums = new int[] { 2, 7, 11, 15 };
        var expected = new int[] { 0, 1 };

        var actual = solution.TwoSum(nums, 9);

        Console.WriteLine(string.Join(", ", actual));
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [TestMethod]
    public void TwoSum_ShouldReturnIndices_WhenTargetIs6_1()
    {
        var solution = new Solution();
        var nums = new int[] { 3, 2, 4 };
        var expected = new int[] { 1, 2 };

        var actual = solution.TwoSum(nums, 6);

        Console.WriteLine(string.Join(", ", actual));
        CollectionAssert.AreEquivalent(expected, actual);
        
    }

    [TestMethod]
    public void TwoSum_ShouldReturnIndices_WhenTargetIs6_2()
    {
        var solution = new Solution();
        var nums = new int[] { 3, 3 };
        var expected = new int[] { 0, 1 };

        var actual = solution.TwoSum(nums, 6);

        Console.WriteLine(string.Join(", ", actual));
        CollectionAssert.AreEquivalent(expected, actual);
    }
}