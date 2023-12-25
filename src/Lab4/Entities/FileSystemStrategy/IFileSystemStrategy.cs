using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemUnits;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Modes.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStrategy;

public interface IFileSystemStrategy
{
    public string WorkingDirectory { get; set; }
    public Folder RootFolder { get; protected set; }
    CommandResult TreeGoTo(string path);
    CommandResult TreeList(int depth, ITreeListVisitor visitor);
    CommandResult DeleteFile(string path);
    CommandResult CopyFile(string sourcePath, string destinationPath);
    CommandResult ShowFile(string path, OutputMode mode);
    CommandResult MoveFile(string sourcePath, string destinationPath);
    CommandResult RenameFile(string path, string filename);
}