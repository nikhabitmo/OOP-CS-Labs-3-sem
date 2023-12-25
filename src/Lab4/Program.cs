using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStrategy;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemUnits;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4;

internal class Program
{
    public static void Main()
    {
        var rootFolder = new Folder { Name = "C" };
        var localFileSystemStrategy = new LocalFileSystemStrategy(rootFolder);

        var fileSystemState =
            new DisconnectedFileSystem(localFileSystemStrategy, new FileSystem(localFileSystemStrategy));

        var fileSystemManager = new FileSystemManager(fileSystemState, new ParserCommands());

        var subFolder1 = new Folder { Name = "Folder1" };
        subFolder1.Contents.Add(new File { Name = "File1.txt" });
        subFolder1.Contents.Add(new File { Name = "File2.txt" });

        var subFolder2 = new Folder { Name = "Folder2" };
        subFolder2.Contents.Add(new File { Name = "File3.txt" });

        rootFolder.Contents.Add(subFolder1);
        rootFolder.Contents.Add(subFolder2);

        while (true)
        {
            Console.Write("Enter a command: ");
            string? inputCommand = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputCommand))
            {
                Console.WriteLine("Please enter a valid command.");
                continue;
            }

            CommandResult result = fileSystemManager.ParseCommand(inputCommand);

            Console.WriteLine(result.Message);
        }
    }

    // Folder: Root
    //     Folder: Folder1
    //     File: File1.txt
    //     File: File2.txt
    //     Folder: Folder2
    //     File: File3.txt
}