using TestRunAnything.Contracts;

namespace TestRunAnything.Problems.Medium;

public sealed record LetterCombinationsOfAPhoneNumberOutput(IList<string> output)
{
    public override string ToString()
    {
        return $"[{string.Join(", ", output)}]";
    }
}
public sealed class LetterCombinationsOfAPhoneNumberSolver : IProblemSolver<string, LetterCombinationsOfAPhoneNumberOutput>
{
    public string Name => "#17. Letter Combinations of a Phone Number";

    public LetterCombinationsOfAPhoneNumberOutput Solve(string input)
    {
        string[] phoneMap = { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
        List<string> result = new();
        Backtrack(0, input, phoneMap, result, "");
        return new LetterCombinationsOfAPhoneNumberOutput(result);
    }

    private void Backtrack(int index, string input, string[] phoneMap, List<string> result, string temp)
    {
        // base case: if we have processed all digits, add the current combination to the result
        if (index == input.Length)
        {
            result.Add(temp);
            return;
        }
        // recursive case: iterate through the characters mapped to the current digit and backtrack
        foreach (char ch in phoneMap[input[index] - '0'])
        {
            // append the current character to the combination and move to the next digit
            Backtrack(index + 1, input, phoneMap, result, temp + ch);
        }
    }
}
