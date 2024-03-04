using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _address;
    private readonly string _mode;

    public ConnectCommand(string address, string mode)
    {
        ArgumentNullException.ThrowIfNull(address);
        ArgumentNullException.ThrowIfNull(mode);

        _address = address;
        _mode = mode;
    }

    public OperationResult Execute(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);

        if (fileSystem is LocalFileSystem && _mode != "local")
        {
            throw new ConnectToFileSystemException("not supported connection mode");
        }

        return fileSystem.Connect(_address, _mode);
    }
}