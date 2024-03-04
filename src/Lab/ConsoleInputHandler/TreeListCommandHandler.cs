using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleInputHandler;

public class TreeListCommandHandler : BaseCommandHandler
{
    public override ICommand? Handle(string[] request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (request.Length > 1 && request[0] == "tree" && request[1] == "list")
        {
            int depth;
            if (request.Length > 3 && request[2] == "-d")
            {
                if (int.TryParse(request[3], out depth))
                {
                    return new TreeListCommand(depth);
                }
            }
            else
            {
                depth = 1;
                return new TreeListCommand(depth);
            }
        }

        return base.Handle(request);
    }
}