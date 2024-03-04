using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.TreeOutputConfigurators;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class LocalFileSystem : IFileSystem
{
    private const int StartDepth = 0;
    private string? _currentPath;
    private TreeOutputConfigurator _treeCfg;

    public LocalFileSystem(TreeOutputConfigurator treeCfg)
    {
        _currentPath = null;
        _treeCfg = treeCfg;
    }

    public TreeOutputConfigurator TreeOutputConfigurators => _treeCfg;

    public OperationResult Connect(string path, string? mode)
    {
        if (!Directory.Exists(ToAbsolutePath(path)))
            return new OperationResult.Failure();

        _currentPath = path;
        return new OperationResult.Success();
    }

    public OperationResult Disconnect()
    {
        _currentPath = null;

        return new OperationResult.Success();
    }

    public OperationResult TreeGoto(string path)
    {
        if (Directory.Exists(ToAbsolutePath(path)))
            _currentPath = path;

        return new OperationResult.Success();
    }

    public OperationResult TreeList(int depth)
    {
        ArgumentNullException.ThrowIfNull(_currentPath);
        Console.WriteLine(_currentPath);
        ListFiles(_currentPath, StartDepth, depth);

        return new OperationResult.Success();
    }

    public OperationResult FileShow(string path, string mode)
    {
        ArgumentNullException.ThrowIfNull(path);
        ArgumentNullException.ThrowIfNull(mode);

        path = ToAbsolutePath(path);

        if (!File.Exists(path))
            return new OperationResult.Failure();

        string content = File.ReadAllText(path);
        Console.WriteLine($"File content : ('{path}') :\n{content}");

        return new OperationResult.Success();
    }

    public OperationResult FileMove(string sourcePath, string destinationPath)
    {
        ArgumentNullException.ThrowIfNull(sourcePath);
        ArgumentNullException.ThrowIfNull(destinationPath);

        sourcePath = ToAbsolutePath(sourcePath);
        destinationPath = ToAbsolutePath(destinationPath);

        if (!File.Exists(sourcePath) || !Directory.Exists(destinationPath))
            return new OperationResult.Failure();

        string destinationFilePath = Path.Combine(destinationPath, Path.GetFileName(sourcePath));

        if (!File.Exists(destinationFilePath))
        {
            File.Move(sourcePath, destinationFilePath);
        }
        else
        {
            File.Delete(destinationFilePath);
            File.Move(sourcePath, destinationFilePath);
        }

        return new OperationResult.Success();
    }

    public OperationResult FileRename(string path, string name)
    {
        ArgumentNullException.ThrowIfNull(path);
        ArgumentNullException.ThrowIfNull(name);

        path = ToAbsolutePath(path);
        if (!File.Exists(path))
            return new OperationResult.Failure();

        string renamePath = Path.Combine(
            Path.GetDirectoryName(path) ?? throw new InvalidOperationException(),
            name);

        if (!File.Exists(renamePath))
        {
            File.Move(path, renamePath);
        }
        else
        {
            string uniqueFileName = Path.Combine(
                Path.GetDirectoryName(renamePath) ?? throw new InvalidOperationException(),
                $"{Path.GetFileNameWithoutExtension(name)}_{Path.GetExtension(name)}");

            File.Move(path, uniqueFileName);
        }

        return new OperationResult.Success();
    }

    public OperationResult FileCopy(string sourcePath, string destinationPath)
    {
        ArgumentNullException.ThrowIfNull(sourcePath);
        ArgumentNullException.ThrowIfNull(destinationPath);

        sourcePath = ToAbsolutePath(sourcePath);
        destinationPath = ToAbsolutePath(destinationPath);

        if (!File.Exists(sourcePath) || !Directory.Exists(destinationPath))
            return new OperationResult.Failure();

        string copyPath = Path.Combine(destinationPath, Path.GetFileName(sourcePath));

        if (File.Exists(copyPath))
        {
            destinationPath = Path.Combine(
                Path.GetDirectoryName(copyPath) ?? throw new InvalidOperationException(),
                $"{Path.GetFileNameWithoutExtension(copyPath)}_{Guid.NewGuid()}{Path.GetExtension(copyPath)}");
        }
        else
        {
            destinationPath = Path.Combine(destinationPath, Path.GetFileName(sourcePath));
        }

        File.Copy(sourcePath, destinationPath);

        return new OperationResult.Success();
    }

    public OperationResult FileDelete(string path)
    {
        ArgumentNullException.ThrowIfNull(path);

        path = ToAbsolutePath(path);

        if (!File.Exists(path))
            return new OperationResult.Failure();

        File.Delete(path);

        return new OperationResult.Success();
    }

    private string ToAbsolutePath(string path)
    {
        if (Path.IsPathRooted(path))
        {
            return path;
        }
        else
        {
            ArgumentNullException.ThrowIfNull(_currentPath);

            return Path.Combine(_currentPath, path);
        }
    }

    private void ListFiles(string path, int currentDepth, int maxDepth)
    {
        if (currentDepth > maxDepth)
        {
            return;
        }

        string spacing = new string(' ', currentDepth * _treeCfg.BranchLenght) + _treeCfg.BranchLine;
        string fileSpacing = new string(' ', (currentDepth + 1) * _treeCfg.BranchLenght) + _treeCfg.BranchLine;

        if (currentDepth == 0)
        {
            spacing = string.Empty;
        }

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine($"{spacing} [{_treeCfg.DirectoryIcon}] {Path.GetFileName(path)}");

        try
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                ListFiles(directory, currentDepth + 1, maxDepth);
            }

            foreach (string file in Directory.GetFiles(path))
            {
                Console.WriteLine($"{fileSpacing} [{_treeCfg.FileIcon}] {Path.GetFileName(file)}");
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"{fileSpacing} [{_treeCfg.NoAccessIcon}] No access");
        }
    }
}