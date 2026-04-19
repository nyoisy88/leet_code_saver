using TestRunAnything.Contracts;

namespace TestRunAnything.Problems.Easy;

public sealed class ValidParenthesesSolver : IProblemSolver<string, bool>
{
    public string Name => "#20. Valid Parentheses";

    public bool Solve(string s)
    {
        Stack<char> opens = new();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] is '(' or '{' or '[')
            {
                opens.Push(s[i]);
            }
            else
            {
                if (opens.Count == 0 || !IsValid(opens.Pop(), s[i])) return false;
            }
        }
        return opens.Count <= 0;
    }

    private bool IsValid(char last, char current)
    {
        return (last == '(' && current == ')')
            || (last == '{' && current == '}')
            || (last == '[' && current == ']');
    }
}
