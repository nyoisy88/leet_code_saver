namespace TestRunAnything;

public sealed record RegularExpressionMatchingInput(string Text, string Pattern);

public sealed class RegularExpressionMatchingSolver : IProblemSolver<RegularExpressionMatchingInput, bool>
{
    public string Name => "Regular Expression Matching";

    public bool Solve(RegularExpressionMatchingInput input)
    {
        return Match(input.Text, input.Pattern);
    }

    private static bool Match(string text, string pattern)
    {
        if (pattern.Length == 0)
        {
            return text.Length == 0;
        }

        bool firstMatch = text.Length > 0 && (pattern[0] == '.' || pattern[0] == text[0]);

        if (pattern.Length >= 2 && pattern[1] == '*')
        {
            return Match(text, pattern[2..]) || (firstMatch && Match(text[1..], pattern));
        }

        return firstMatch && Match(text[1..], pattern[1..]);
    }
}
