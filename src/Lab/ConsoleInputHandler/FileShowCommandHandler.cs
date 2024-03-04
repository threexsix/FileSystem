using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleInputHandler;

public class FileShowCommandHandler : BaseCommandHandler
{
    public override ICommand? Handle(string[] request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (request.Length > 1 && request[0] == "file" && request[1] == "show")
        {
            string path = request.Length > 2 ? request[2] : string.Empty;
            string mode = request.Length > 3 ? request[3] : string.Empty;

            return new ShowCommand(path, mode);
        }

        return base.Handle(request);
    }
}