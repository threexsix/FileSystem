namespace Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

public abstract record OperationResult
{
    private OperationResult() { }
    internal sealed record Success : OperationResult;
    internal sealed record Failure : OperationResult;
}