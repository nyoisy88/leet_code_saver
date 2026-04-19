using TestRunAnything.Contracts;
using TestRunAnything.Problems.Easy;
using TestRunAnything.Problems.Hard;
using TestRunAnything.Problems.Medium;

namespace TestRunAnything;

static class Program
{
    static void Main(string[] args)
    {
        RunCombinationSumSolver();
    }

    #region Easy

    private static void RunRomanToIntegerSolver()
    {
        IProblemSolver<string, int> solver = new RomanToIntegerSolver();
        RunRepeatableSolver(solver, "Enter Roman numeral: ", ReadRequiredLine);
    }

    private static void RunPalindromeNumber()
    {
        IProblemSolver<int, bool> solver = new PalindromeNumberSolver();
        RunSolverOnce(solver, "Enter number to check: ", ReadIntLine);
    }

    #endregion

    #region Medium

    private static void RunStringToIntegerAtoiSolver()
    {
        IProblemSolver<string, int> solver = new StringToIntegerAtoiSolver();
        RunRepeatableSolver(solver, "Enter string: ", ReadRequiredLine);
    }

    private static void RunReverseIntegerSolver()
    {
        IProblemSolver<int, int> solver = new ReverseIntegerSolver();
        RunRepeatableSolver(solver, "Enter Int Number to reverse: ", ReadIntLine);
    }

    // #17. Letter Combinations of a Phone Number
    private static void RunLetterCombinationsOfAPhoneNumberSolver()
    {
        IProblemSolver<string, LetterCombinationsOfAPhoneNumberOutput> solver = new LetterCombinationsOfAPhoneNumberSolver();
        RunRepeatableSolver(solver, "Enter digits: ", ReadRequiredLine);
    }

    // #22. Generate Parentheses
    private static void RunGenerateParenthesesSolver()
    {
        IProblemSolver<int, GenerateParenthesesOutput> solver = new GenerateParenthesesSolver();
        RunRepeatableSolver(solver, "Enter n: ", ReadIntLine);
    }

    // #39. Combination Sum
    private static void RunCombinationSumSolver()
    {
        IProblemSolver<CombinationSumInput, CombinationSumOutput> solver = new CombinationSumSolver();
        CombinationSumInput input = new([2, 3, 6, 7], 7);
        WriteSolverResult(solver, input);
    }

    #endregion

    #region Hard

    private static void RunMedianOfTwoSortedArraysSolver()
    {
        IProblemSolver<MedianOfTwoSortedArraysInput, double> solver = new MedianOfTwoSortedArraysSolver();
        MedianOfTwoSortedArraysInput input = new([1, 2], [3, 4]);
        WriteSolverResult(solver, input);
    }

    private static void RunWordLadder()
    {
        IProblemSolver<WordLadderInput, int> solver = new WordLadderSolver();
        WordLadderInput input = new("hit", "cog", ["hot", "dot", "dog", "lot", "log", "cog"]);
        WriteSolverResult(solver, input);
    }

    #endregion

    private static void RunRepeatableSolver<TInput, TOutput>(
        IProblemSolver<TInput, TOutput> solver,
        string prompt,
        Func<string, TInput> readInput)
    {
        while (true)
        {
            TInput input = readInput(prompt);
            WriteSolverResult(solver, input);

            if (ShouldStop())
            {
                break;
            }

            Console.WriteLine();
        }
    }

    private static void RunSolverOnce<TInput, TOutput>(
        IProblemSolver<TInput, TOutput> solver,
        string prompt,
        Func<string, TInput> readInput)
    {
        TInput input = readInput(prompt);
        WriteSolverResult(solver, input);
    }

    private static void WriteSolverResult<TInput, TOutput>(IProblemSolver<TInput, TOutput> solver, TInput input)
    {
        Console.WriteLine($"{solver.Name}: {solver.Solve(input)}");
    }

    private static bool ShouldStop()
    {
        return Console.ReadKey(true).Key == ConsoleKey.Escape;
    }

    private static string ReadRequiredLine(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
        }
    }

    private static int ReadIntLine(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int value))
            {
                return value;
            }
        }
    }
}
