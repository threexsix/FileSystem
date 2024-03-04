using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleInputHandler;

public interface ICommandHandler
{
    void AddNext(ICommandHandler link);
    ICommand? Handle(string[] request);
}