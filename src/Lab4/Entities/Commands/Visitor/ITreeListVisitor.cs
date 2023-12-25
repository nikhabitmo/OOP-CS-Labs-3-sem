using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemUnits;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Visitor;

public interface ITreeListVisitor
{
    void VisitFile(File file, int depth);
    void VisitFolder(Folder folder, int depth);
}