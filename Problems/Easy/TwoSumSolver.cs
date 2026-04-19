using TestRunAnything.Contracts;

namespace TestRunAnything.Problems.Easy;
public sealed record TwoSumInput(int[] Numbers, int Target);

public sealed class TwoSumSolver : IProblemSolver<TwoSumInput, int[]>
{
    public string Name => "Two Sum";

    public int[] Solve(TwoSumInput input)
    {
        Dictionary<int, int> indicesByValue = [];

        for (int index = 0; index < input.Numbers.Length; index++)
        {
            int complement = input.Target - input.Numbers[index];
            if (indicesByValue.TryGetValue(complement, out int matchIndex))
            {
                return [matchIndex, index];
            }

            indicesByValue[input.Numbers[index]] = index;
        }

        return [];
    }
}
