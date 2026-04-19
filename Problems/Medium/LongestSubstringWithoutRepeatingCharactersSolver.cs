using TestRunAnything.Contracts;

namespace TestRunAnything.Problems.Medium;

public sealed class LongestSubstringWithoutRepeatingCharactersSolver : IProblemSolver<string, int>
{
    public string Name => "#3. Longest Substring Without Repeating Characters";

    public int Solve(string input)
    {
        int maxLength = 0;
        int left = 0;
        Dictionary<char, int> lastSeen = [];

        for (int right = 0; right < input.Length; right++)
        {
            char current = input[right];
            if (lastSeen.TryGetValue(current, out int previousIndex))
            {
                left = Math.Max(left, previousIndex + 1);
            }

            lastSeen[current] = right;
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}
