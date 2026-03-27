namespace TestRunAnything;

public interface IProblemSolver<in TInput, out TOutput>
{
    string Name { get; }

    TOutput Solve(TInput input);
}
