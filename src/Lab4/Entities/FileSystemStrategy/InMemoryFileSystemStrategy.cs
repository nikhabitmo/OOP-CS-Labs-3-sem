using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemUnits;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Modes.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStrategy;

public class InMemoryFileSystemStrategy : IFileSystemStrategy
{
    public string WorkingDirectory { get; set; } = string.Empty;
    public Folder RootFolder { get; set; } = new Folder();
    public IList<string> ListFiles()
    {
        throw new NotImplementedException();
    }

    public CommandResult Connect(string address, string mode)
    {
        throw new NotImplementedException();
    }

    public CommandResult Disconnect()
    {
        throw new NotImplementedException();
    }

    public CommandResult TreeGoTo(string path)
    {
        throw new NotImplementedException();
    }

    public CommandResult TreeList(int depth, ITreeListVisitor visitor)
    {
        throw new NotImplementedException();
    }

    public CommandResult DeleteFile(string path)
    {
        throw new NotImplementedException();
    }

    public CommandResult CopyFile(string sourcePath, string destinationPath)
    {
        throw new NotImplementedException();
    }

    public CommandResult ShowFile(string path, OutputMode mode)
    {
        throw new NotImplementedException();
    }

    public CommandResult MoveFile(string sourcePath, string destinationPath)
    {
        throw new NotImplementedException();
    }

    public CommandResult RenameFile(string path, string filename)
    {
        throw new NotImplementedException();
    }
}