using System.Text;
using TestRunAnything.Contracts;

namespace TestRunAnything.Problems.Medium;

public sealed record GenerateParenthesesOutput(IList<string> Output)
{
    public override string ToString()
    {
        return $"[{string.Join(", ", Output)}]";
    }
}

public sealed class GenerateParenthesesSolver : IProblemSolver<int, GenerateParenthesesOutput>
{
    public string Name => "#22. Generate Parentheses";

    public GenerateParenthesesOutput Solve(int input)
    {
        List<string> ans = new();
        StringBuilder s = new();
        DFS(ans, s, 0, 0, input);
        return new GenerateParenthesesOutput(ans);
    }

    private void DFS(List<string> ans, StringBuilder s, int left, int right, int n)
    {
        if (left == n && right == n)
        {
            ans.Add(s.ToString());
            return;
        }
        if (left < n)
        {
            DFS(ans, s.Append('('), left + 1, right, n);
            s.Length--;
        }
        if (right < left)
        {
            DFS(ans, s.Append(')'), left, right + 1, n);
            s.Length--;
        }
    }
}
