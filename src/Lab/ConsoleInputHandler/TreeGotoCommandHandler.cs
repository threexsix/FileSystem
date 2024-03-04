using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleInputHandler;

public class TreeGotoCommandHandler : BaseCommandHandler
{
    public override ICommand? Handle(string[] request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (request.Length > 1 && request[0] == "tree" && request[1] == "goto")
        {
            string address = request.Length > 2 ? request[2] : string.Empty;

            return new GotoCommand(address);
        }

        return base.Handle(request);
    }
}