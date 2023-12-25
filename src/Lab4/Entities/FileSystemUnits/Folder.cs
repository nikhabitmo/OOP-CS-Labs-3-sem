using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemUnits;

public class Folder : IFileSystemUnit
{
    public string Name { get; set; } = string.Empty;
    public IList<IFileSystemUnit> Contents { get; private set; } = new List<IFileSystemUnit>();
    public void Accept(ITreeListVisitor visitor, int depth)
    {
        if (visitor == null) return;

        visitor.VisitFolder(this, depth);
        foreach (IFileSystemUnit unit in Contents)
        {
            unit.Accept(visitor, depth + 1);
        }
    }
}