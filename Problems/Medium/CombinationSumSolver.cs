using TestRunAnything.Contracts;

namespace TestRunAnything.Problems.Medium;

public sealed record CombinationSumInput(int[] Candidates, int Target);
public sealed record CombinationSumOutput(IList<IList<int>> Combinations)
{
    public override string ToString()
    {
        return string.Join(", ", Combinations.Select(c => $"[{string.Join(", ", c)}]"));
    }
}
public sealed class CombinationSumSolver : IProblemSolver<CombinationSumInput, CombinationSumOutput>
{
    public string Name => "#39. Combination Sum";

    public CombinationSumOutput Solve(CombinationSumInput input)
    {
        return new CombinationSumOutput(CombinationSum(input.Candidates, input.Target));
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<IList<int>> ans = new();
        List<int> temp = new();
        Backtrack(ans, temp, candidates, target, 0);
        return ans;
    }

    private void Backtrack(List<IList<int>> ans, IList<int> temp, int[] candidates, int target, int index)
    {
        // Time Complexity: O(N^T/M) where N is the number of candidates, T is the target value,
        // and M is the minimum value among the candidates. This is because in the worst case,
        // we can have T/M numbers in a combination (when we use the smallest candidate), and
        // there are N choices for each number in the combination.
        // Space Complexity: O(T/M) for the recursion stack and the temporary list, where T is the target value
        // and M is the minimum value among the candidates. This is because in the worst case, we can
        // have T/M numbers in a combination (when we use the smallest candidate).
        if (target < 0) return;
        if (target == 0)
        {
            ans.Add(temp.ToArray());
            return;
        }
        for (int i = index; i < candidates.Length; i++)
        {
            int candidate = candidates[i];
            temp.Add(candidate);
            Backtrack(ans, temp, candidates, target - candidate, i);
            temp.Remove(candidate);
        }
    }
}
