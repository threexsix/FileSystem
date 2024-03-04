using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

public static class OperationResultHandler
{
    public static void Handle(OperationResult? result)
    {
        if (result is OperationResult.Failure)
        {
            Console.WriteLine("The command was executed with an error");
        }

        if (result is OperationResult.Success)
        {
            Console.WriteLine("The command was executed successfully");
        }
    }
}