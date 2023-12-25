using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStrategy;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Modes.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Modes.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;

public abstract class FileSystemState
{
    protected FileSystemState(IFileSystemStrategy strategy, FileSystem context)
    {
        Strategy = strategy;
        Context = context;
    }

    public IFileSystemStrategy Strategy { get; protected set; }

    public FileSystem Context { get; protected set; }

    public abstract CommandResult Connect(string address, FileSystemMode mode);

    public abstract CommandResult Disconnect();

    public abstract CommandResult TreeGoTo(string path);

    public abstract CommandResult TreeList(int depth, ITreeListVisitor visitor);

    public abstract void SetCurrentDirectory(string path);

    public abstract CommandResult DeleteFile(string path);

    public abstract CommandResult CopyFile(string sourcePath, string destinationPath);

    public abstract CommandResult ShowFile(string path, OutputMode mode);

    public abstract CommandResult MoveFile(string sourcePath, string destinationPath);
    public abstract CommandResult RenameFile(string path, string filename);
    protected abstract void ChangeStrategy(IFileSystemStrategy fileSystemStrategy);
}