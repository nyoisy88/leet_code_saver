namespace TestRunAnything;

public sealed class StringToIntegerAtoiSolver : IProblemSolver<string, int>
{
    public string Name => "#8. String To Integer (atoi)";

    public int Solve(string input)
    {
        int index = 0;
        int sign = 1;
        int result = 0;

        while (index < input.Length && char.IsWhiteSpace(input[index]))
        {
            index++;
        }

        if (index < input.Length && (input[index] == '+' || input[index] == '-'))
        {
            sign = input[index] == '-' ? -1 : 1;
            index++;
        }

        while (index < input.Length && char.IsDigit(input[index]))
        {
            int digit = input[index] - '0';

            if (result > (int.MaxValue - digit) / 10)
            {
                return sign == -1 ? int.MinValue : int.MaxValue;
            }

            result = (result * 10) + digit;
            index++;
        }

        return result * sign;
    }
}
