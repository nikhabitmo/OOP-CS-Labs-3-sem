using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStrategy;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemUnits;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Modes.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Modes.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;

public class DisconnectedFileSystem : FileSystemState
{
    public DisconnectedFileSystem(IFileSystemStrategy strategy, FileSystem context)
        : base(strategy, context)
    {
    }

    public override CommandResult Disconnect()
    {
        return new CommandResultDisconnectedFileSystemError();
    }

    public override CommandResult TreeGoTo(string path)
    {
        return new CommandResultDisconnectedFileSystemError();
    }

    public override CommandResult TreeList(int depth, ITreeListVisitor visitor)
    {
        throw new System.NotImplementedException();
    }

    public override CommandResult Connect(string address, FileSystemMode mode)
    {
        if (mode is LocalFileSystemMode)
        {
            ChangeStrategy(new LocalFileSystemStrategy(new Folder { Name = address }));
        }

        Context.ChangeState(new ConnectedFileSystem(Strategy, Context));
        return new CommandResultSuccess();
    }

    public override void SetCurrentDirectory(string path)
    {
        Strategy.WorkingDirectory = path;
    }

    public override CommandResult DeleteFile(string path)
    {
        return new CommandResultDisconnectedFileSystemError();
    }

    public override CommandResult CopyFile(string sourcePath, string destinationPath)
    {
        return new CommandResultDisconnectedFileSystemError();
    }

    public override CommandResult ShowFile(string path, OutputMode mode)
    {
        return new CommandResultDisconnectedFileSystemError();
    }

    public override CommandResult MoveFile(string sourcePath, string destinationPath)
    {
        return new CommandResultDisconnectedFileSystemError();
    }

    public override CommandResult RenameFile(string path, string filename)
    {
        return new CommandResultDisconnectedFileSystemError();
    }

    protected override void ChangeStrategy(IFileSystemStrategy fileSystemStrategy)
    {
        Strategy = fileSystemStrategy;
    }
}