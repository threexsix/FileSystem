using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.TreeOutputConfigurators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Apps;

public static class App
{
    public static void Run()
    {
        TreeOutputConfigurator treeOutputConfigurator = new()
        {
            DirectoryIcon = "X_X",
            FileIcon = ">_<",
        };

        ParseHandlerChain parseHandlerChain = new();
        LocalFileSystem localFileSystem = new(treeOutputConfigurator);

        while (true)
        {
            Console.Write("Enter command: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            if (input == "exit")
            {
                break;
            }

            string[] commandArgs = input.Split(" ");

            ICommand? command = parseHandlerChain.Start.Handle(commandArgs);

            OperationResultHandler.Handle(command?.Execute(localFileSystem));
        }
    }
}