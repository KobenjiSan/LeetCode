namespace MoveZeroes0283;
/* 
Problem: Move Zeroes (LeetCode #283)
Link: https://leetcode.com/problems/move-zeroes/description/

Approach:
- two pointers
- initialize placer
- iterate the array with scanner
- check if scanner is on an element with a non-zero number
- check if the placer and scanner are on the same element
- if not swap the current element (scanner) with placer
- move both pointers forward

Complexities:
- Time: O(n)
- Space: O(1)

Notes:
- Skipping consecutive zeroes gave me the most trouble
- Starting to understand two pointers
*/
public class Solution
{

    public int[] MoveZeroes(int[] nums)
    {
        if (nums.Length == 1) return nums;

        int placer = 0;     // next spot to place non-zero
        for (int scanner = 0; scanner < nums.Length; scanner++)
        {
            if (nums[scanner] != 0)
            {
                if (placer != scanner)  // avoid self-swapping
                {
                    int temp = nums[placer];
                    nums[placer] = nums[scanner];
                    nums[scanner] = temp;
                }
                placer++;
            }
        }
        return nums;
    }

    /* 
    FIRST SOLUTION 
    Approach:
    - iterate each element
    - if current element is zero
    - iterate until you find a non-zero element and replace it
    - repeat for every element
    Complexities:
    - Time: O(n²)
    - Space: O(n)
    */
    public int[] MoveZeroes_1(int[] nums)
    {
        if (nums.Length == 1) return nums;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] == 0)
            {
                for (int j = 1; j < nums.Length - i; j++)
                {
                    if (nums[i + j] != 0)
                    {
                        nums[i] = nums[i + j];
                        nums[i + j] = 0;
                        break;
                    }
                }
            }
        }
        return nums;
    }
}

[TestClass]
public class SolutionTest
{
    [TestMethod]
    public void TwoSum_ShouldReturn1_3_12_0_0_WhenNumsIs0_1_0_3_12()
    {
        var solution = new Solution();
        var nums = new int[] { 0, 1, 0, 3, 12 };
        var expected = new int[] { 1, 3, 12, 0, 0 };

        var actual = solution.MoveZeroes(nums);

        Console.WriteLine(string.Join(", ", actual));
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TwoSum_ShouldReturn0_WhenNumsIs0()
    {
        var solution = new Solution();
        var nums = new int[] { 0 };
        var expected = new int[] { 0 };

        var actual = solution.MoveZeroes(nums);

        Console.WriteLine(string.Join(", ", actual));
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TwoSum_ShouldReturn1_3_12_0_0_0_0_WhenNumsIs0_1_0_0_3_12_0()
    {
        var solution = new Solution();
        var nums = new int[] { 0, 1, 0, 0, 3, 12, 0 };
        var expected = new int[] { 1, 3, 12, 0, 0, 0, 0 };

        var actual = solution.MoveZeroes(nums);

        Console.WriteLine(string.Join(", ", actual));
        CollectionAssert.AreEqual(expected, actual);
    }
}