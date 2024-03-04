using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ConsoleInputHandler;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParseCommandTest
{
    [Fact]
    public void SuccessStringParseIntoCommand()
    {
        // Assign
        ConnectCommandHandler connectHandler = new();
        DisconnectCommandHandler disconnectCommandHandler = new();
        TreeGotoCommandHandler treeGotoCommandHandler = new();
        TreeListCommandHandler treeListCommandHandler = new();
        FileShowCommandHandler fileShowCommandHandler = new();
        FileMoveCommandHandler fileMoveCommandHandler = new();
        FileCopyCommandHandler fileCopyCommandHandler = new();
        FileDeleteCommandHandler fileDeleteCommandHandler = new();
        FileRenameCommandHandler fileRenameCommandHandler = new();

        connectHandler.AddNext(disconnectCommandHandler);
        disconnectCommandHandler.AddNext(treeGotoCommandHandler);
        treeGotoCommandHandler.AddNext(treeListCommandHandler);
        treeListCommandHandler.AddNext(fileShowCommandHandler);
        fileShowCommandHandler.AddNext(fileMoveCommandHandler);
        fileMoveCommandHandler.AddNext(fileCopyCommandHandler);
        fileCopyCommandHandler.AddNext(fileDeleteCommandHandler);
        fileDeleteCommandHandler.AddNext(fileRenameCommandHandler);

        string input = @"connect C:\Users\Leogri3x6\Desktop\c# labs";

        // Act
        string[] commandArgs = input.Split(" ");
        ICommand? command = connectHandler.Handle(commandArgs);

        // Assert
        Assert.True(command is ConnectCommand);
    }

    [Fact]
    public void NotSuccessStringParseIntoCommand()
    {
        // Assign
        ConnectCommandHandler connectHandler = new();
        DisconnectCommandHandler disconnectCommandHandler = new();
        TreeGotoCommandHandler treeGotoCommandHandler = new();
        TreeListCommandHandler treeListCommandHandler = new();
        FileShowCommandHandler fileShowCommandHandler = new();
        FileMoveCommandHandler fileMoveCommandHandler = new();
        FileCopyCommandHandler fileCopyCommandHandler = new();
        FileDeleteCommandHandler fileDeleteCommandHandler = new();
        FileRenameCommandHandler fileRenameCommandHandler = new();

        connectHandler.AddNext(disconnectCommandHandler);
        disconnectCommandHandler.AddNext(treeGotoCommandHandler);
        treeGotoCommandHandler.AddNext(treeListCommandHandler);
        treeListCommandHandler.AddNext(fileShowCommandHandler);
        fileShowCommandHandler.AddNext(fileMoveCommandHandler);
        fileMoveCommandHandler.AddNext(fileCopyCommandHandler);
        fileCopyCommandHandler.AddNext(fileDeleteCommandHandler);
        fileDeleteCommandHandler.AddNext(fileRenameCommandHandler);

        string input = @"disconnect";

        // Act
        string[] commandArgs = input.Split(" ");
        ICommand? command = connectHandler.Handle(commandArgs);

        // Assert
        Assert.False(command is ConnectCommand);
    }
}