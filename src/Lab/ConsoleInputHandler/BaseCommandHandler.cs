using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleInputHandler;

public abstract class BaseCommandHandler : ICommandHandler
{
    private ICommandHandler? _nextHandler;

    public void AddNext(ICommandHandler link)
    {
        if (_nextHandler is null)
        {
            _nextHandler = link;
        }
        else
        {
            _nextHandler.AddNext(link);
        }
    }

    public virtual ICommand? Handle(string[] request)
    {
        return _nextHandler?.Handle(request);
    }
}