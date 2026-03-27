namespace TestRunAnything;

public sealed record MedianOfTwoSortedArraysInput(int[] Left, int[] Right);

public sealed class MedianOfTwoSortedArraysSolver : IProblemSolver<MedianOfTwoSortedArraysInput, double>
{
    public string Name => "#4. Median Of Two Sorted Arrays";

    public double Solve(MedianOfTwoSortedArraysInput input)
    {
        int totalLength = input.Left.Length + input.Right.Length;
        int middle = totalLength / 2;

        if (totalLength % 2 == 0)
        {
            return (FindKth(input.Left, input.Right, 0, input.Left.Length - 1, 0, input.Right.Length - 1, middle) +
                FindKth(input.Left, input.Right, 0, input.Left.Length - 1, 0, input.Right.Length - 1, middle - 1)) / 2d;
        }

        return FindKth(input.Left, input.Right, 0, input.Left.Length - 1, 0, input.Right.Length - 1, middle);
    }

    private static double FindKth(int[] left, int[] right, int leftStart, int leftEnd, int rightStart, int rightEnd, int k)
    {
        if (leftStart > leftEnd)
        {
            return right[k - leftStart];
        }

        if (rightStart > rightEnd)
        {
            return left[k - rightStart];
        }

        int leftIndex = (leftStart + leftEnd) / 2;
        int rightIndex = (rightStart + rightEnd) / 2;
        int leftValue = left[leftIndex];
        int rightValue = right[rightIndex];

        if (leftIndex + rightIndex < k)
        {
            if (leftValue < rightValue)
            {
                return FindKth(left, right, leftIndex + 1, leftEnd, rightStart, rightEnd, k);
            }

            return FindKth(left, right, leftStart, leftEnd, rightIndex + 1, rightEnd, k);
        }

        if (leftValue < rightValue)
        {
            return FindKth(left, right, leftStart, leftEnd, rightStart, rightIndex - 1, k);
        }

        return FindKth(left, right, leftStart, leftIndex - 1, rightStart, rightEnd, k);
    }
}
