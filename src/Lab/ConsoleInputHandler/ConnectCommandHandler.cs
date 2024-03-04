using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleInputHandler;

public class ConnectCommandHandler : BaseCommandHandler
{
    public override ICommand? Handle(string[] request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (request.Length > 0 && request[0] == "connect")
        {
            string address = request.Length > 1 ? request[1] : string.Empty;
            string mode = request.Length > 2 ? request[2] : "local";

            return new ConnectCommand(address, mode);
        }

        return base.Handle(request);
    }
}