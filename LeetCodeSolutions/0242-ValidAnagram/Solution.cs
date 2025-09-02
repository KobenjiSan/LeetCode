namespace ValidAnagram0242;
/* 
Problem: Valid Anagram (LeetCode #242)
Link: https://leetcode.com/problems/valid-anagram/description/

Approach:
- validate s & t are the same length
- build a dictionary to hold counts per char (with the right length)
- add letter counts from s
- remove letter counts from t / validate it isnt less than 0 / validate t doesnt have any obscure letters
- return true if all cases are valid

Complexities:
- Time: O(n) - single pass add + single pass remvoe
- Space: O(k) - number of unique characters

Notes:
- initial thought: just see if strings include the characters of the other
- use a dictonary for faster lookups
*/
public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        Dictionary<char, int> counts = new Dictionary<char, int>(s.Length);
        foreach (char letter in s)
        {
            if (counts.ContainsKey(letter)) counts[letter]++;
            else counts[letter] = 1;
        }
        foreach (char letter in t)
        {
            if (counts.ContainsKey(letter))
            {
                counts[letter]--;
                if (counts[letter] < 0) return false;
            }
            else return false;
        }
        return true;
    }

    /* 
    FIRST SOLUTION 
    Approach:
    - validate s & t are the same length
    - while iterating s
    - validate if t contains the current char
    - get the index that matches in t
    - remove the char within t
    - return true if no false is thrown
    Complexities:
    - Time: O(n²)
    - Space (aux): O(1) NOTE: creates lots of garbage strings, inefficient with up to O(n²) of garbage
                              because t.Remove() creates a new string each time 
    */
    public bool IsAnagram_1(string s, string t)
    {
        if (s.Length != t.Length) return false;

        foreach (char letter in s)
        {
            if (!t.Contains(letter)) return false;
            var temp = t.IndexOf(letter);
            t = t.Remove(temp, 1);
        }
        return true;
    }

}

[TestClass]
public class SolutionTest
{
    [TestMethod]
    public void IsAnagram_ShouldReturnTrue_WhenS_anagram_T_nagaram()
    {
        var solution = new Solution();
        var s = "anagram";
        var t = "nagaram";
        var expected = true;

        var actual = solution.IsAnagram(s, t);

        Console.WriteLine(actual);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsAnagram_ShouldReturnFalse_WhenS_rat_T_car()
    {
        var solution = new Solution();
        var s = "rat";
        var t = "car";
        var expected = false;

        var actual = solution.IsAnagram(s, t);

        Console.WriteLine(actual);
        Assert.AreEqual(expected, actual);
    }
}