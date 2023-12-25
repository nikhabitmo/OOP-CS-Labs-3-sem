using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemUnits;

public interface IFileSystemUnit
{
    void Accept(ITreeListVisitor visitor, int depth);
}