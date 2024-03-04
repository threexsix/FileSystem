using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystem
{
    public OperationResult Connect(string path, string mode);
    public OperationResult Disconnect();
    public OperationResult TreeGoto(string path);
    public OperationResult TreeList(int depth);
    public OperationResult FileShow(string path, string mode);
    public OperationResult FileMove(string sourcePath, string destinationPath);
    public OperationResult FileCopy(string sourcePath, string destinationPath);
    public OperationResult FileDelete(string path);
    public OperationResult FileRename(string path, string name);
}