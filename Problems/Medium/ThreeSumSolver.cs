namespace TestRunAnything;

public sealed record ThreeSumOutput(IList<IList<int>> output)
{
    public override string ToString()
    {
        return string.Join(", ", output.Select(triplet => $"[{string.Join(", ", triplet)}]"));
    }
}
public sealed class ThreeSumSolver : IProblemSolver<int[], ThreeSumOutput>
{
    public string Name => "#15. 3 Sum";

    /*
     * Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, 
     * and nums[i] + nums[j] + nums[k] == 0.
     * Notice that the solution set must not contain duplicate triplets.
     */

    public ThreeSumOutput Solve(int[] input)
    {
        // Review: This is a classic problem that can be solved using the two-pointer technique after sorting the array.
        List<IList<int>> res = new();
        int numsLength = input.Length;
        Array.Sort(input);
        for (int i = 0; i < input.Length; i++)
        {
            if (i > 0 && input[i] == input[i - 1]) continue;
            int j = i + 1;
            int k = numsLength - 1;
            while (j < k)
            {
                int sum = input[i] + input[j] + input[k];
                if (sum == 0)
                {
                    res.Add(new[] { input[i], input[j], input[k] });
                    j++;
                    while (input[j] == input[j - 1] && j < k)
                    {
                        j++;
                    }
                    continue;
                }
                if (sum > 0)
                {
                    k--;
                }
                else
                {
                    j++;
                }
                
            }
        }
        return new ThreeSumOutput(res);

    }

    private IList<IList<int>> BruteForce(int[] input)
    {
        HashSet<string> seen = new();
        List<IList<int>> res = [];
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = i + 1; j < input.Length; j++)
            {
                for (int k = j + 1; k < input.Length; k++)
                {
                    if (input[i] + input[j] + input[k] == 0)
                    {
                        int[] triplet = new[] { input[i], input[j], input[k] };
                        Array.Sort(triplet);
                        string key = string.Join(",", triplet);
                        if (!seen.Contains(key))
                        {
                            seen.Add(key);
                            res.Add(triplet);
                        }
                    }
                }
            }
        }
        return res;
    }
}
