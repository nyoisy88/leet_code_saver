namespace TestRunAnything;

public sealed record WordBreakInput(string Text, IList<string> WordDictionary);

public sealed class WordBreakSolver : IProblemSolver<WordBreakInput, IList<string>>
{
    public string Name => "Word Break";

    public IList<string> Solve(WordBreakInput input)
    {
        List<string>?[] combinationsByIndex = new List<string>[input.Text.Length + 1];
        combinationsByIndex[0] = [];

        for (int index = 0; index < input.Text.Length; index++)
        {
            if (combinationsByIndex[index] is null)
            {
                continue;
            }

            foreach (string word in input.WordDictionary)
            {
                int end = index + word.Length;
                if (end > input.Text.Length)
                {
                    continue;
                }

                if (input.Text.Substring(index, word.Length) != word)
                {
                    continue;
                }

                combinationsByIndex[end] ??= [];
                combinationsByIndex[end]!.Add(word);
            }
        }

        List<string> result = [];
        if (combinationsByIndex[^1] is null)
        {
            return result;
        }

        List<string> currentPath = [];
        BuildSentences(combinationsByIndex, input.Text.Length, result, currentPath);
        return result;
    }

    private static void BuildSentences(List<string>?[] combinationsByIndex, int end, List<string> result, List<string> currentPath)
    {
        if (end <= 0)
        {
            string sentence = currentPath[^1];
            for (int index = currentPath.Count - 2; index >= 0; index--)
            {
                sentence += " " + currentPath[index];
            }

            result.Insert(0, sentence);
            return;
        }

        foreach (string word in combinationsByIndex[end]!)
        {
            currentPath.Add(word);
            BuildSentences(combinationsByIndex, end - word.Length, result, currentPath);
            currentPath.RemoveAt(currentPath.Count - 1);
        }
    }
}
