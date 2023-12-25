using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStrategy;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Modes.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Modes.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class FileSystem
{
    private FileSystemState _currentState;

    public FileSystem(IFileSystemStrategy strategy)
    {
        _currentState = new DisconnectedFileSystem(strategy, this);
    }

    public void ChangeState(FileSystemState newState)
    {
        _currentState = newState;
    }

    public void SetCurrentDirectory(string path)
    {
        _currentState.SetCurrentDirectory(path);
    }

    public CommandResult Connect(string address, FileSystemMode mode)
    {
        return _currentState.Connect(address, mode);
    }

    public CommandResult Disconnect()
    {
        return _currentState.Disconnect();
    }

    public CommandResult TreeGoTo(string path)
    {
        return _currentState.TreeGoTo(path);
    }

    public CommandResult TreeList(int depth, ITreeListVisitor visitor)
    {
        return _currentState.TreeList(depth, visitor);
    }

    public CommandResult DeleteFile(string filename)
    {
        return _currentState.DeleteFile(filename);
    }

    public CommandResult CopyFile(string sourcePath, string destinationPath)
    {
        return _currentState.CopyFile(sourcePath, destinationPath);
    }

    public CommandResult ShowFile(string path, OutputMode mode)
    {
        return _currentState.ShowFile(path, mode);
    }

    public CommandResult MoveFile(string filename, string directory)
    {
        return _currentState.MoveFile(filename, directory);
    }
}