using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRunAnything
{
    internal class WordBreak
    {
        public IList<string> Break(string s, IList<string> wordDict)
        {
            List<string>[] dp = new List<string>[s.Length + 1];
            dp[0] = new List<string>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dp[i] == null) continue;

                foreach (string word in wordDict)
                {
                    int len = word.Length;
                    int end = i + len;

                    if (end > s.Length) continue;
                    if (s.Substring(i, len) == word)
                    {
                        if (dp[end] == null)
                        {
                            dp[end] = new List<string>();
                        }
                        dp[end].Add(s.Substring(i, len));
                    }
                }
            }
            List<string> result = new List<string>();
            if (dp[^1] == null)
            {
                return result;
            }

            List<string> temp = new List<string>();
            dfs(dp, s.Length, result, temp);
            return result;

        }

        private void dfs(List<string>[] dp, int end, List<string> result, List<string> temp)
        {
            if (end <= 0)
            {
                string path = temp[^1];
                for (int i = temp.Count - 2; i >= 0; i--)
                {
                    path += " " + temp[i];
                }
                result.Insert(0, path);
                return;
            }
            foreach (string word in dp[end])
            {
                temp.Add(word);
                dfs(dp, end - word.Length, result, temp);
                temp.Remove(word);
            }
        }
    }
}
