namespace TestRunAnything;

static class Program
{
    static void Main(string[] args)
    {
        // Test three sum solver
        var solver = new ThreeSumSolver();
        WriteSolverResult(solver, [-1,-1,-1,-1, 0, 1, 2, -1,-1,-1, -4]);
    }

    private static void RunMedianOfTwoSortedArraysSolver()
    {
        IProblemSolver<MedianOfTwoSortedArraysInput, double> solver = new MedianOfTwoSortedArraysSolver();
        MedianOfTwoSortedArraysInput input = new([1, 2], [3, 4]);
        WriteSolverResult(solver, input);
    }

    private static void RunRomanToIntegerSolver()
    {
        IProblemSolver<string, int> solver = new RomanToIntegerSolver();
        RunRepeatableSolver(solver, "Enter Roman numeral: ", ReadRequiredLine);
    }

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

    private static void RunPalindromeNumber()
    {
        IProblemSolver<int, bool> solver = new PalindromeNumberSolver();
        RunSolverOnce(solver, "Enter number to check: ", ReadIntLine);
    }

    private static void RunWordLadder()
    {
        IProblemSolver<WordLadderInput, int> solver = new WordLadderSolver();
        WordLadderInput input = new("hit", "cog", ["hot", "dot", "dog", "lot", "log", "cog"]);
        WriteSolverResult(solver, input);
    }

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
