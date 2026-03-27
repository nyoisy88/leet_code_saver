namespace TestRunAnything;

public sealed record WordLadderInput(string BeginWord, string EndWord, IList<string> WordList);

public sealed class WordLadderSolver : IProblemSolver<WordLadderInput, int>
{
    public string Name => "Word Ladder";

    public int Solve(WordLadderInput input)
    {
        HashSet<string> wordSet = [.. input.WordList];
        if (input.WordList.Count == 0 || !wordSet.Contains(input.EndWord))
        {
            return 0;
        }

        Queue<string> pendingWords = [];
        HashSet<string> visited = [];

        pendingWords.Enqueue(input.BeginWord);
        visited.Add(input.BeginWord);
        int distance = 1;

        while (pendingWords.Count != 0)
        {
            int currentLevelCount = pendingWords.Count;
            for (int i = 0; i < currentLevelCount; i++)
            {
                string currentWord = pendingWords.Dequeue();
                if (currentWord == input.EndWord)
                {
                    return distance;
                }

                for (int letterIndex = 0; letterIndex < currentWord.Length; letterIndex++)
                {
                    char[] chars = currentWord.ToCharArray();
                    for (char nextChar = 'a'; nextChar <= 'z'; nextChar++)
                    {
                        if (nextChar == chars[letterIndex])
                        {
                            continue;
                        }

                        chars[letterIndex] = nextChar;
                        string nextWord = new(chars);
                        if (wordSet.Contains(nextWord) && visited.Add(nextWord))
                        {
                            pendingWords.Enqueue(nextWord);
                        }
                    }
                }
            }

            distance++;
        }

        return 0;
    }
}
