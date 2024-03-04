using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class ConnectToFileSystemException : Exception
{
    public ConnectToFileSystemException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ConnectToFileSystemException(string message)
        : base(message)
    {
    }

    public ConnectToFileSystemException()
    {
    }
}