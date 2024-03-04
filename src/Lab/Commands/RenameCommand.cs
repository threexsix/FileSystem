using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class RenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _name;

    public RenameCommand(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public OperationResult Execute(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);

        return fileSystem.FileRename(_path, _name);
    }
}