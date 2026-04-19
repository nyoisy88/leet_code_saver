using TestRunAnything.Contracts;

namespace TestRunAnything.Problems.Medium;
public sealed class LongestPalindromeSubstringSolver : IProblemSolver<string, string>
{
    public string Name => "#5. Longest Palindrome Substring";

    /// <summary>
    /// Given a string s, return the longest palindromic substring in s.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string Solve(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        int start = 0;
        int maxLength = 1;
        for (int i = 0; i < s.Length; i++)
        {
            // Odd length palindromes
            ExpandAroundCenter(s, i, i, ref start, ref maxLength);
            // Even length palindromes
            ExpandAroundCenter(s, i, i + 1, ref start, ref maxLength);
        }
        return s.Substring(start, maxLength);

    }

    private void ExpandAroundCenter(string s, int i1, int i2, ref int start, ref int maxLength)
    {
        while (i1 >= 0 && i2 < s.Length && s[i1] == s[i2])
        {
            int currentLength = i2 - i1 + 1;
            if (currentLength > maxLength)
            {
                start = i1;
                maxLength = currentLength;
            }
            i1--;
            i2++;
        }
    }
}
