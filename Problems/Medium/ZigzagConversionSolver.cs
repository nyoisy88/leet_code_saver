using System.Text;

namespace TestRunAnything;

public sealed record ZigzagConversionInput(string S, int NumRows);
public sealed class ZigzagConversionSolver : IProblemSolver<ZigzagConversionInput, string>
{
    public string Name => "#6. Zigzag Conversion";

    public string Solve(ZigzagConversionInput input)
    {
        if (input.NumRows == 1) return input.S;
        List<StringBuilder> zigzag = [];
        for (int i = 1; i <= input.NumRows; i++)
        {
            zigzag.Add(new StringBuilder());
        }
        int direction = 1;
        int currentRow = 0;
        foreach (var @char in input.S)
        {
            zigzag[currentRow].Append(@char);
            currentRow += direction;
            if (currentRow == input.NumRows - 1 || currentRow == 0)
            {
                direction *= -1;
            }
        }
        StringBuilder result = new();
        foreach (var row in zigzag)
        {
            result.Append(row);
        }
        return result.ToString();
    }
}
