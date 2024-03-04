using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleInputHandler;

public class FileDeleteCommandHandler : BaseCommandHandler
{
    public override ICommand? Handle(string[] request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (request.Length > 1 && request[0] == "file" && request[1] == "delete")
        {
            string path = request.Length > 2 ? request[2] : string.Empty;

            return new DeleteCommand(path);
        }

        return base.Handle(request);
    }
}