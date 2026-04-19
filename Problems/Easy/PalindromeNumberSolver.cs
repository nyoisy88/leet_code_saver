using TestRunAnything.Contracts;

namespace TestRunAnything.Problems.Easy;

public sealed class PalindromeNumberSolver : IProblemSolver<int, bool>
{
    public string Name => "#9. Palindrome Number";

    public bool Solve(int value)
    {
        if (value < 0)
        {
            return false;
        }

        int original = value;
        int reversed = 0;

        while (value > 0)
        {
            reversed = (reversed * 10) + (value % 10);
            value /= 10;
        }

        return reversed == original;
    }
}
