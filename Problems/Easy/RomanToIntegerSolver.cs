using TestRunAnything.Contracts;

namespace TestRunAnything.Problems.Easy;

public sealed class RomanToIntegerSolver : IProblemSolver<string, int>
{
    private static readonly Dictionary<char, int> Values = new()
    {
        ['I'] = 1,
        ['V'] = 5,
        ['X'] = 10,
        ['L'] = 50,
        ['C'] = 100,
        ['D'] = 500,
        ['M'] = 1000,
    };

    public string Name => "Roman To Integer";

    public int Solve(string input)
    {
        int result = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (i + 1 < input.Length && Values[input[i]] < Values[input[i + 1]])
            {
                result -= Values[input[i]];
            }
            else
            {
                result += Values[input[i]];
            }
        }

        return result;
    }
}
