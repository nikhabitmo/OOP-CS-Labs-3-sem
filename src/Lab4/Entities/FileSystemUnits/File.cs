using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemUnits;

public class File : IFileSystemUnit
{
    public string Name { get; set; } = string.Empty;
    public IList<object>? Content { get; private set; }
    public void Accept(ITreeListVisitor visitor, int depth)
    {
        visitor?.VisitFile(this, depth);
    }
}