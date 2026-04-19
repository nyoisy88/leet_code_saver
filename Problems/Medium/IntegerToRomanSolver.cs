using TestRunAnything.Contracts;

namespace TestRunAnything.Problems.Medium;
public sealed class IntegerToRomanSolver : IProblemSolver<int, string>
{
    public string Name => "#12. Integer to Roman";

    private static readonly Dictionary<int, string> Values = new()
    {
        [1000] = "M",
        [900] = "CM",
        [500] = "D",
        [400] = "CD",
        [100] = "C",
        [90] = "XC",
        [50] = "L",
        [40] = "XL",
        [10] = "X",
        [9] = "IX",
        [5] = "V",
        [4] = "IV",
        [1] = "I"
    };

    public string Solve(int input)
    {
        List<string> res = [];
        foreach (var pair in Values)
        {
            if (input == 0) break;
            int count = input / pair.Key;
            input -= pair.Key * count;
            for (int i = 0; i < count; i++)
            {
                res.Add(pair.Value);
            }
        }
        return string.Join("", res);
    }
}
