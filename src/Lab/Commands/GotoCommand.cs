using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class GotoCommand : ICommand
{
    private readonly string _path;

    public GotoCommand(string path)
    {
        _path = path;
    }

    public OperationResult Execute(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);

        return fileSystem.TreeGoto(_path);
    }
}