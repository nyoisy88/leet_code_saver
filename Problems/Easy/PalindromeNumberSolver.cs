namespace TestRunAnything;

public sealed class PalindromeNumberSolver : IProblemSolver<int, bool>
{
    public string Name => "Palindrome Number";

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
