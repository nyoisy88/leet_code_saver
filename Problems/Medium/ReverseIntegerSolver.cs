namespace TestRunAnything;

public sealed class ReverseIntegerSolver : IProblemSolver<int, int>
{
    public string Name => "#7. Reverse Integer";

    public int Solve(int value)
    {
        int reversed = 0;

        while (value != 0)
        {
            int digit = value % 10;
            value /= 10;

            if (reversed > int.MaxValue / 10 || (reversed == int.MaxValue / 10 && digit > 7))
            {
                return 0;
            }

            if (reversed < int.MinValue / 10 || (reversed == int.MinValue / 10 && digit < -8))
            {
                return 0;
            }

            reversed = (reversed * 10) + digit;
        }

        return reversed;
    }
}
