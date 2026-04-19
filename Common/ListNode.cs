namespace TestRunAnything.Common;

public sealed class ListNode
{
    public int Value { get; set; }

    public ListNode? Next { get; set; }

    public ListNode(int value = 0, ListNode? next = null)
    {
        Value = value;
        Next = next;
    }
}
