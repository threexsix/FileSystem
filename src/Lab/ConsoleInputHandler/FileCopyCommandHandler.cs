using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleInputHandler;

public class FileCopyCommandHandler : BaseCommandHandler
{
    public override ICommand? Handle(string[] request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (request.Length > 1 && request[0] == "file" && request[1] == "copy")
        {
            string sourcePath = request.Length > 2 ? request[2] : string.Empty;
            string destinationPath = request.Length > 3 ? request[3] : string.Empty;

            return new CopyCommand(sourcePath, destinationPath);
        }

        return base.Handle(request);
    }
}