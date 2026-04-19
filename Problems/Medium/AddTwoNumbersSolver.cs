using TestRunAnything.Common;
using TestRunAnything.Contracts;

namespace TestRunAnything.Problems.Medium;

public sealed record AddTwoNumbersInput(ListNode? Left, ListNode? Right);

public sealed class AddTwoNumbersSolver : IProblemSolver<AddTwoNumbersInput, ListNode?>
{
    public string Name => "#2. Add Two Numbers";

    public ListNode? Solve(AddTwoNumbersInput input)
    {
        ListNode dummyHead = new();
        ListNode current = dummyHead;
        int carry = 0;
        ListNode? left = input.Left;
        ListNode? right = input.Right;

        while (left is not null || right is not null || carry != 0)
        {
            int leftValue = left?.Value ?? 0;
            int rightValue = right?.Value ?? 0;
            int sum = leftValue + rightValue + carry;

            carry = sum / 10;
            current.Next = new ListNode(sum % 10);
            current = current.Next;

            left = left?.Next;
            right = right?.Next;
        }

        return dummyHead.Next;
    }
}
