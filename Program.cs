
namespace TestRunAnything
{
    static class Program
    {
        static void Main(string[] args)
        {
            //string s = "catsanddog";
            //List<string> wordDict = ["cat", "cats", "and", "sand", "dog"];

            SolveReserveInteger();
        }

        private static void SolveReserveInteger()
        {
            do
            {
                int x = ReadIntLine();
                int rev = Medium.ReserveInteger(x);
                Console.WriteLine($"Reserve Integer: {rev}");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void RunPalindromeNumber()
        {
            PalindromeNumber_Easy palindrome = new PalindromeNumber_Easy();
            string? input = null;
            while (string.IsNullOrEmpty(input))
            {
                input = Console.ReadLine();
            }
            int x = int.Parse(input);
            Console.WriteLine(palindrome.IsPalindrome(x));
        }

        static void RunWordLadder()
        {
            string start = "hit", end = "cog";
            string[] wordList = ["hot", "dot", "dog", "lot", "log", "cog"];
            WordLadder wordLadder = new WordLadder();
            int result = wordLadder.LadderLength(start, end, wordList.ToList());

            Console.WriteLine(result);
        }

        static int ReadIntLine()
        {
            string? input = null;
            while (string.IsNullOrEmpty(input))
            {
                Console.Write("Enter Int: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out int x))
                {
                    return x;
                }
                input = null;
            }
            return 0;
        }
    }
}