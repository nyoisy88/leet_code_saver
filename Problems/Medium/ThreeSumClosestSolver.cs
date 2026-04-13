namespace TestRunAnything;

public sealed record ThreeSumClosestInput(int[] nums, int target);
public sealed class ThreeSumClosestSolver : IProblemSolver<ThreeSumClosestInput, int>
{
    public string Name => "#16. 3 Sum Closest";

    public int Solve(ThreeSumClosestInput input)
    {
        return FindMinDifference(input.nums, input.target);
        
    }

    private int FindMinDifference(int[] nums, int target)
    { 
        int n = nums.Length;
        Array.Sort(nums);
        int closestSum = nums[0] + nums[1]+ nums[2]; // Initial best guess
        for (int i = 0; i < n - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            int j = i + 1;
            int k = n - 1;
            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];
                if (Math.Abs(target - sum) < Math.Abs(target - closestSum))
                {
                    closestSum = sum;
                }
                if (target == sum) return sum;
                if (target > sum)
                {
                    j++;
                }
                else
                {
                    k--;
                }

            }
        }

        return closestSum;
    }
}
