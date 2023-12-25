using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStrategy;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemUnits;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Modes.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Modes.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;

public class ConnectedFileSystem : FileSystemState
{
    public ConnectedFileSystem(IFileSystemStrategy strategy, FileSystem fileSystem)
        : base(strategy, fileSystem)
    {
    }

    public override CommandResult Disconnect()
    {
        Context.ChangeState(new DisconnectedFileSystem(Strategy, Context));
        return new CommandResultSuccess();
    }

    public override CommandResult TreeGoTo(string path)
    {
        return Strategy.TreeGoTo(path);
    }

    public override CommandResult TreeList(int depth, ITreeListVisitor visitor)
    {
        return Strategy.TreeList(depth, visitor);
    }

    public override CommandResult Connect(string address, FileSystemMode mode)
    {
        if (mode is LocalFileSystemMode)
        {
            ChangeStrategy(new LocalFileSystemStrategy(new Folder { Name = address }));
        }

        return new CommandResultSuccess();
    }

    public override void SetCurrentDirectory(string path)
    {
        Strategy.WorkingDirectory = path;
    }

    public override CommandResult DeleteFile(string path)
    {
        return Strategy.DeleteFile(path);
    }

    public override CommandResult CopyFile(string sourcePath, string destinationPath)
    {
        return Strategy.CopyFile(sourcePath, destinationPath);
    }

    public override CommandResult ShowFile(string path, OutputMode mode)
    {
        return Strategy.ShowFile(path, mode);
    }

    public override CommandResult MoveFile(string sourcePath, string destinationPath)
    {
        return Strategy.MoveFile(sourcePath, destinationPath);
    }

    public override CommandResult RenameFile(string path, string filename)
    {
        return Strategy.RenameFile(path, filename);
    }

    protected override void ChangeStrategy(IFileSystemStrategy fileSystemStrategy)
    {
        Strategy = fileSystemStrategy;
    }
}