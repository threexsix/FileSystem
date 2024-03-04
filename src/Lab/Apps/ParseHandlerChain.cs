using Itmo.ObjectOrientedProgramming.Lab4.ConsoleInputHandler;

namespace Itmo.ObjectOrientedProgramming.Lab4.Apps;

public class ParseHandlerChain
{
    public ParseHandlerChain()
    {
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

        Start = connectHandler;
    }

    public ICommandHandler Start { get; }
}