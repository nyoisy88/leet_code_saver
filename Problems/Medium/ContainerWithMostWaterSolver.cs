namespace TestRunAnything;

public sealed class ContainerWithMostWaterSolver : IProblemSolver<int[], int>
{
    public string Name => "Container With Most Water";

    public int Solve(int[] heights)
    {
        int left = 0;
        int right = heights.Length - 1;
        int maxArea = 0;

        while (left < right)
        {
            int width = right - left;
            int height = Math.Min(heights[left], heights[right]);

            maxArea = Math.Max(maxArea, width * height);

            if (heights[left] < heights[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }
}
