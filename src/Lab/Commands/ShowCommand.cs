using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ShowCommand : ICommand
{
    private readonly string _path;
    private readonly string _mode;

    public ShowCommand(string path, string mode)
    {
        _path = path;
        _mode = mode;
    }

    public OperationResult Execute(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);

        return fileSystem.FileShow(_path, _mode);
    }
}