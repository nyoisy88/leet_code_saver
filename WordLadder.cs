using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestRunAnything
{
    internal class WordLadder
    {
        public int LadderLength(string begin, string end, IList<string> wordList)
        {
            HashSet<string> wordSet = new HashSet<string>(wordList);
            if (wordList.Count == 0 && !wordSet.Contains(end))
            {
                return 0;
            }
            Queue<string> wordQueue = new Queue<string>();
            int distance = 0;
            HashSet<string> visited = new HashSet<string>();

            wordQueue.Enqueue(begin);
            visited.Add(begin);
            distance = 1;

            while (wordQueue.Count != 0)
            {
                for (int i =0; i < wordQueue.Count; i++)
                {
                    string currWord = wordQueue.Dequeue();
                    if (currWord == end)
                    {
                        return distance;
                    }

                    for (int j = 0; j < currWord.Length; j++)
                    {

                        char[] charArr = currWord.ToCharArray();
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            if (c == charArr[j])
                            {
                                continue;
                            }
                            charArr[j] = c;
                            string newWord = new(charArr);
                            if (wordSet.Contains(newWord) && !visited.Contains(newWord))
                            {
                                wordQueue.Enqueue(newWord);
                                visited.Add(newWord);
                            }
                        }
                    }
                }
                ++distance;
            }

            return 0;
        }
    }
}
